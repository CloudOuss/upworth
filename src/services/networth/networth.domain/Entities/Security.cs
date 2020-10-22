using NetworthDomain.Enums;

namespace NetworthDomain.Entities
{
    public class Security
    {
        public Industry Industry { get; set; }

        public Security(int industryId)
        {
            Industry = AbstractEnumeration.FromValue<Industry>(industryId);
        }
    }
}
