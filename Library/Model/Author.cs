namespace Library.Model
{
    public class Author: IBase
    {
        public string EmailAddress;
        public string FirstName;
        public string LastName;
        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}
