namespace NetworthDomain.Enums
{
    public class AccountType : AbstractEnumeration
    {
        public static readonly AccountType Rrsp = new AccountType(1, "RRSP");
        public static readonly AccountType Tfsa = new AccountType(2, "TFSA");
        public static readonly AccountType Taxable = new AccountType(3, "Taxable");
        public static readonly AccountType Lira = new AccountType(4, "LIRA");

        public AccountType(int id, string name)
            : base(id, name)
        {
        }

        public AccountType() : base()
        {
            
        }
    }
}