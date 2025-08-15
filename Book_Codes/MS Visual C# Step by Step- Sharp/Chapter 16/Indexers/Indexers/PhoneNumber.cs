
namespace Indexers
{
	struct PhoneNumber
	{
        private string number;

		public PhoneNumber(string text)
		{
			this.number = text;
		}

		public string Text
		{
			get { return this.number; }
		}

		public override int GetHashCode() => this.number.GetHashCode();

		public override bool Equals(object other) => (other is PhoneNumber) && Equals((PhoneNumber)other);
		
		public bool Equals(PhoneNumber other) => this.number == other.number;
	}
}
