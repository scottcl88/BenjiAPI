using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class VaccineMap : ClassMap<Vaccine>
    {
        public VaccineMap()
        {
            Table("Vaccines");
            Id(x => x.VaccineId);
            Map(x => x.Comments);
            Map(x => x.Title);
            Map(x => x.Expiration);
            Map(x => x.Received);
            Map(x => x.Doctor);
            Map(x => x.Company);
            Map(x => x.Address);
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted);
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}