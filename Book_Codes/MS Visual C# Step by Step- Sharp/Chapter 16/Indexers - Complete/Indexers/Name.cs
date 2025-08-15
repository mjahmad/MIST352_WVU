
namespace Indexers
{
	struct Name
	{
        private string name;

		public Name(string text)
		{
			this.name = text;
		}

		public string Text
		{
			get { return this.name; }
		}

		public override int GetHashCode() => this.name.GetHashCode();

		public override bool Equals(object other) => (other is Name) && Equals((Name)other);
		
		public bool Equals(Name other) => this.name == other.name;
	}
}