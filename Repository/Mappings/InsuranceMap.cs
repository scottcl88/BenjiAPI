using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class InsuranceMap : ClassMap<Insurance>
    {
        public InsuranceMap()
        {
            Table("Insurance");
            Id(x => x.InsuranceId);
            Map(x => x.PolicyId);
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted);
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}