namespace NetworthDomain.Enums
{
    public class Institution : AbstractEnumeration
    {
        public static readonly Institution Questrade = new Institution(1, "Questrade");
        public static readonly Institution Wealthsimple = new Institution(2, "Wealthsimple");

        public Institution(int id, string name)
            : base(id, name)
        {
        }

        public Institution() : base()
        {
            
        }
    }
}