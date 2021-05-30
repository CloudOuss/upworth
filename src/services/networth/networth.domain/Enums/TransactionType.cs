namespace NetworthDomain.Enums
{
    public class TransactionType : AbstractEnumeration
    {
        public static readonly TransactionType Buy = new TransactionType(1, "Buy");
        public static readonly TransactionType Sell = new TransactionType(2, "Sell");
        public static readonly TransactionType Dividend = new TransactionType(3, "Dividend");
        public static readonly TransactionType Other = new TransactionType(3, "Other");

        public TransactionType(int id, string name)
            : base(id, name)
        {
        }

        public TransactionType() : base()
        {
            
        }
    }
}