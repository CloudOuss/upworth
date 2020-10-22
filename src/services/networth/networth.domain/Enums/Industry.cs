namespace NetworthDomain.Enums
{
    public class Industry : AbstractEnumeration
    {
        public static readonly Industry CommunicationServices = new Industry(1, "Communication Services");
        public static readonly Industry ConsumerDiscretionary = new Industry(2, "Consumer Discretionary");
        public static readonly Industry ConsumerStaples = new Industry(3, "Consumer Staples");
        public static readonly Industry Energy = new Industry(4, "Energy");
        public static readonly Industry Financials = new Industry(5, "Financials");
        public static readonly Industry HealthCare = new Industry(6, "Health Care");
        public static readonly Industry Industrials = new Industry(7, "Industrials");
        public static readonly Industry Materials = new Industry(8, "Materials");
        public static readonly Industry RealEstate = new Industry(9, "Real Estate");
        public static readonly Industry Technology = new Industry(10, "Technology");
        public static readonly Industry Utilities = new Industry(11, "Utilities");

        public Industry(int id, string name)
            : base(id, name)
        {
        }
    }
}
