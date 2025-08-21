using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customers
{
    public class ViewModel : INotifyPropertyChanged
    {
        private List<Customer> customers;
        public int CustomerListCount { get => customers is null ? 0 : customers.Count; }
        private int currentCustomer;
        public int CurrentCustomerIndex { get => currentCustomer + 1; }

        public Command SearchCustomers { get; private set; }
        public Command RunQuery { get; private set; }
        public Command CancelSearch { get; private set; }
        public Command NextCustomer { get; private set; }
        public Command PreviousCustomer { get; private set; }
        public Command FirstCustomer { get; private set; }
        public Command LastCustomer { get; private set; }
        public Command MoreCustomers { get; private set; }
        public Command Reset { get; private set; }
        public Command AddCustomer { get; private set; }
        public Command EditCustomer { get; private set; }
        public Command DiscardChanges { get; private set; }
        public Command SaveChanges { get; private set; }

        private const string ServerUrl = "https://adventureworksservice.azurewebsites.net/";
        private int offset = 0;
        private int count = 0;
        private HttpClient client = null;
        private JsonSerializerOptions options = new() 
        {
            PropertyNameCaseInsensitive = true
        };

        public ViewModel()
        {
            this.currentCustomer = 0;
            this.IsAtStart = true;
            this.IsAtEnd = false;
            this.SearchCustomers = new Command(this.Search,
                () => this.CanBrowse);
            this.RunQuery = new Command(this.View,
                () => this.CanSearch);
            this.CancelSearch = new Command(this.Cancel,
                () => this.CanSearch);
            this.NextCustomer = new Command(this.Next, 
                () => this.CanBrowse && 
                      this.customers is not null && !this.IsAtEnd);
            this.PreviousCustomer = new Command(this.Previous, 
                () => this.CanBrowse && 
                      this.customers is not null && !this.IsAtStart);
            this.FirstCustomer = new Command(this.First, 
                () => this.CanBrowse && 
                      this.customers is not null && !this.IsAtStart);
            this.LastCustomer = new Command(this.Last,
                () => this.CanBrowse && 
                      this.customers is not null && !this.IsAtEnd);
            this.MoreCustomers = new Command(async () => await this.More(),
                () => this.CanBrowse);
            this.Reset = new Command(async () => { this.customers = null;
                                                   await this.GetDataAsync(0, MainPage.BatchSize); },
                () => this.CanBrowse);            
            this.AddCustomer = new Command(this.Add,
                () => this.CanBrowse);
            this.EditCustomer = new Command(this.Edit,
                () => this.CanBrowse);
            this.DiscardChanges = new Command(this.Discard,
                () => this.CanSaveOrDiscardChanges);
            this.SaveChanges = new Command(this.SaveAsync, 
                () => this.CanSaveOrDiscardChanges);

            this.customers = null;
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(ServerUrl);
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region Methods for fetching and updating data

        // Create a new (empty) customer 
        // and put the form into Adding mode
        private void Add()
        {
            Customer newCustomer = new Customer() { CustomerID = 0 };
            this.customers.Insert(currentCustomer, newCustomer);
            this.IsAdding = true;
            this.OnPropertyChanged(nameof(Current));
            this.OnPropertyChanged(nameof(CustomerListCount));
        }

        // Edit the current customer 
        // - save the existing details of the customer
        //   and put the form into Editing mode
        private Customer oldCustomer;

        private void Edit()
        {
            this.oldCustomer = this.Current;
            this.IsEditing = true;
        }

        // Discard changes made while in Adding or Editing mode
        // and return the form to Browsing mode
        private void Discard()
        {
            // If the user was adding a new customer, then remove it
            if (this.IsAdding)
            {
                this.customers.Remove(this.Current);
                this.OnPropertyChanged(nameof(Current));
                this.OnPropertyChanged(nameof(CustomerListCount));
            }

            // If the user was editing an existing customer, 
            // then restore the saved details
            if (this.IsEditing)
            {
                this.Current = this.oldCustomer;
            }

            this.IsBrowsing = true;
            this.LastError = String.Empty;
        }

        // Save the new or updated customer back to the web service
        // and return the form to Browsing mode
        private async void SaveAsync()
        {
            // Validate the details of the Customer
            if (this.ValidateCustomer(this.Current))
            {
                // Only continue if the customer details are valid
                this.IsBusy = true;
                try
                {
                    // Convert the current customer into HTTP request format with a JSON payload
                    var serializedData = JsonSerializer.Serialize(this.Current);
                    StringContent content =
                        new StringContent(serializedData, Encoding.UTF8, "text/json");

                    // If the user is adding a new customer,
                    // send an HTTP POST request to the web service with the details
                    if (this.IsAdding)
                    {
                        var response = await client.PostAsync("api/customers", content);
                        if (response.IsSuccessStatusCode)
                        {
                            // Get the ID of the newly created customer and display it
                            Uri customerUri = response.Headers.Location;
                            var newCust = await this.client.GetAsync(customerUri);
                            if (newCust.IsSuccessStatusCode)
                            {
                                var customerData = await newCust.Content.ReadAsStringAsync();
                                this.Current = JsonSerializer.Deserialize<Customer>(customerData, options);
                                this.IsAdding = false;
                                this.IsBrowsing = true;
                                this.LastError = String.Empty;
                            }
                            else
                            {
                                // TODO: Handle GET failure
                                this.LastError = response.ReasonPhrase;
                            }
                        }
                        // TODO: Handle POST failure
                        else
                        {
                            this.LastError = response.ReasonPhrase;
                        }
                    }
                    // The user must be editing an existing customer,
                    // so send the details by using a PUT request 
                    else
                    {
                        string path = $"api/customers/{this.Current.CustomerID}";

                        var response = await client.PutAsync(path, content);
                        if (response.IsSuccessStatusCode)
                        {
                            this.IsEditing = false;
                            this.IsBrowsing = true;
                            this.LastError = String.Empty;
                        }
                        // TODO: Handle PUT failure
                        else
                        {
                            this.LastError = response.ReasonPhrase;
                        }
                    }
                }
                catch (Exception e)
                {
                    // TODO: Handle exceptions
                    this.LastError = e.Message;
                }
                finally
                {
                    this.OnPropertyChanged(nameof(CustomerListCount));
                    this.IsBusy = false;
                }
            }
        }

        // Helper method to validate customer details
        private bool ValidateCustomer(Customer customer)
        {
            string validationErrors = string.Empty;
            bool hasErrors = false;

            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                hasErrors = true;
                validationErrors = "First Name must not be empty\n";
            }

            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                hasErrors = true;
                validationErrors += "Last Name must not be empty\n";
            }

            // Email address is a series of characters that do not include a space or @
            // followed by @
            // followed by a series of characters that do not include a space or @
            // followed by .
            // followed by a series of characters that do not include a space or @
            Regex emailRegex = new Regex(@"^[^@ ]+@[^@ ]+\.[^@ ]+$");
            if (string.IsNullOrWhiteSpace(customer.EmailAddress) ||
                !emailRegex.IsMatch(customer.EmailAddress))
            {
                hasErrors = true;
                validationErrors += "Invalid Email Address\n";
            }

            // Phone number is a series of digits, brackets, spaces, +, and - characters
            Regex phoneRegex = new Regex(@"^[0-9\(\)\/+ \-]+$");
            if (string.IsNullOrWhiteSpace(customer.Phone) ||
                !phoneRegex.IsMatch(customer.Phone))
            {
                hasErrors = true;
                validationErrors += "Invalid Phone Number\n";
            }

            this.LastError = validationErrors;
            return !hasErrors;
        }

        public async Task GetDataAsync(int offset, int count)
        {
            this.offset = offset;
            this.count = count;
            try
            {
                this.IsBusy = true;
                var response = await this.client.GetAsync($"api/customers?offset={offset}&count={count}");
                if (response.IsSuccessStatusCode)
                {
                    var customersJsonString = await response.Content.ReadAsStringAsync();
                    var customersData = JsonSerializer.Deserialize<List<Customer>>(customersJsonString, options);
                    if (this.customers is null)
                    {
                        this.customers = customersData;
                        this.First();
                    }
                    else
                    {
                        this.customers.AddRange(customersData);
                    }
                }
                else
                {
                    this.LastError = response.ReasonPhrase;
                }
            }
            catch (Exception e)
            {
                this.LastError = e.Message;
            }
            finally
            {
                this.OnPropertyChanged(nameof(CustomerListCount));
                this.IsBusy = false;
            }
        }

        #endregion

        #region Properties for "busy" and error message handling

        private bool _isBusy;
        public bool IsBusy
        {
            get => this._isBusy;
            set 
            {
                this._isBusy = value;
                this.OnPropertyChanged(nameof(IsBusy));
            }
        }

        private string _lastError = null;
        public string LastError
        {
            get => this._lastError;
            private set
            {
                this._lastError = value;
                this.OnPropertyChanged(nameof(LastError));
            }
        }

        #endregion

        #region Properties for managing the edit and search mode

        // Manage the edit mode of the form - is the user browsing, adding a customer, or editing a customer
        private enum EditMode { Browsing, Adding, Editing, Searching };
        private EditMode editMode;
        public bool IsBrowsing
        {
            get => this.editMode == EditMode.Browsing;
            private set
            {
                if (value)
                {
                    this.editMode = EditMode.Browsing;
                }
                this.OnPropertyChanged(nameof(IsBrowsing));
                this.OnPropertyChanged(nameof(IsAdding));
                this.OnPropertyChanged(nameof(IsEditing));
                this.OnPropertyChanged(nameof(IsSearching));
                this.OnPropertyChanged(nameof(IsAddingOrEditing));
                this.OnPropertyChanged(nameof(IsAddingEditingOrSearching));
            }
        }

        public bool IsAdding
        {
            get => this.editMode == EditMode.Adding;
            private set
            {
                if (value)
                {
                    this.editMode = EditMode.Adding;
                }
                this.OnPropertyChanged(nameof(IsBrowsing));
                this.OnPropertyChanged(nameof(IsAdding));
                this.OnPropertyChanged(nameof(IsEditing));
                this.OnPropertyChanged(nameof(IsSearching));
                this.OnPropertyChanged(nameof(IsAddingOrEditing));
                this.OnPropertyChanged(nameof(IsAddingEditingOrSearching));
            }
        }

        public bool IsEditing
        {
            get => this.editMode == EditMode.Editing;
            private set
            {
                if (value)
                {
                    this.editMode = EditMode.Editing;
                }
                this.OnPropertyChanged(nameof(IsBrowsing));
                this.OnPropertyChanged(nameof(IsAdding));
                this.OnPropertyChanged(nameof(IsEditing));
                this.OnPropertyChanged(nameof(IsSearching));
                this.OnPropertyChanged(nameof(IsAddingOrEditing));
                this.OnPropertyChanged(nameof(IsAddingEditingOrSearching));
            }
        }

        public bool IsAddingOrEditing
        {
            get => this.IsAdding || this.IsEditing; 
        }
        

        private bool CanBrowse
        {
            get => this.IsBrowsing &&
                   this.client is not null;
        }

        private bool CanSaveOrDiscardChanges
        {
            get => this.IsAddingOrEditing &&
                   this.client is not null;
        }

        #endregion

        #region Methods and properties for navigation commands

        private bool _isAtStart;
        public bool IsAtStart
        {
            get => this._isAtStart; 
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged(nameof(IsAtStart));
            }
        }

        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get => this._isAtEnd; 
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged(nameof(IsAtEnd));
            }
        }

        public Customer Current
        {
            get => this.customers is null || this.customers.Count == 0 ? null : this.customers[currentCustomer];
            set => this.customers[currentCustomer] = value;
        }

        private void Next()
        {
            if (this.customers.Count - 1 > this.currentCustomer)
            {
                this.currentCustomer++;
                this.OnPropertyChanged(nameof(Current));
                this.OnPropertyChanged(nameof(CurrentCustomerIndex));
                this.IsAtStart = false;
                this.IsAtEnd = (this.customers.Count == 0 || this.customers.Count - 1 == this.currentCustomer);
            }
        }

        private void Previous()
        {
            if (this.currentCustomer > 0)
            {
                this.currentCustomer--;
                this.OnPropertyChanged(nameof(Current));
                this.OnPropertyChanged(nameof(CurrentCustomerIndex));
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentCustomer == 0);
            }
        }

        private void First()
        {
            this.currentCustomer = 0;
            this.OnPropertyChanged(nameof(Current));
            this.OnPropertyChanged(nameof(CurrentCustomerIndex));
            this.IsAtStart = true;
            this.IsAtEnd = (this.customers.Count <= 1);
        }

        private void Last()
        {
            this.currentCustomer = this.customers.Count - 1;
            this.OnPropertyChanged(nameof(Current));
            this.OnPropertyChanged(nameof(CurrentCustomerIndex));
            this.IsAtEnd = true;
            this.IsAtStart = (this.customers.Count <= 1);
        }

        private async Task More()
        {
            await this.GetDataAsync(this.offset + this.count, this.count);
            this.currentCustomer = this.customers.Count > offset ? offset : this.customers.Count - 1;
            this.OnPropertyChanged(nameof(Current));
            this.IsAtStart = (this.currentCustomer == 0);
            this.IsAtEnd = (this.customers.Count == 0 || this.customers.Count - 1 == this.currentCustomer);
        }

        #endregion

        #region Methods and properties for search commands

        public bool IsAddingEditingOrSearching
        {
            get => this.IsAdding || this.IsEditing || this.IsSearching;
        }

        public bool IsSearching
        {
            get { return this.editMode == EditMode.Searching; }
            private set
            {
                if (value)
                {
                    this.editMode = EditMode.Searching;
                }
                this.OnPropertyChanged(nameof(IsBrowsing));
                this.OnPropertyChanged(nameof(IsAdding));
                this.OnPropertyChanged(nameof(IsEditing));
                this.OnPropertyChanged(nameof(IsAddingEditingOrSearching));
                this.OnPropertyChanged(nameof(IsSearching));
            }
        }
        private bool CanSearch
        {
            get => this.IsSearching;
        }

        private void Search()
        {
            Customer searchPattern = new Customer { CustomerID = 0 };
            this.customers.Insert(currentCustomer, searchPattern);
            this.IsSearching = true;
            this.OnPropertyChanged(nameof(Current));
        }

        private void View()
        {
            _ = FindCustomersAsync(Current);
            this.IsAdding = false;
            this.IsBrowsing = true;
            this.LastError = String.Empty;
        }

        private void Cancel()
        {
            this.customers.Remove(this.Current);
            this.OnPropertyChanged(nameof(Current));
            this.IsSearching = false;
            this.IsBrowsing = true;
            this.LastError = String.Empty;
        }

        public async Task FindCustomersAsync(Customer pattern)
        {
            try
            {
                this.IsBusy = true;
                var response = await this.client.GetAsync($"api/customers/find?title={pattern.Title ?? "%"}&firstName={pattern.FirstName ?? "%"}&lastName={pattern.LastName ?? "%"}&email={pattern.EmailAddress ?? "%"}&phone={pattern.Phone ?? "%"}");
                if (response.IsSuccessStatusCode)
                {
                    var customersJsonString = await response.Content.ReadAsStringAsync();
                    customers = JsonSerializer.Deserialize<List<Customer>>(customersJsonString, options);
                    this.First();
                }
                else
                {
                    this.LastError = response.ReasonPhrase;
                }
            }
            catch (Exception e)
            {
                this.LastError = e.Message;
            }
            finally
            {
                this.OnPropertyChanged(nameof(CustomerListCount));
                this.IsBusy = false;
            }
        }
        #endregion

        #region INotifyPropertyChanged interface

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged is not null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
