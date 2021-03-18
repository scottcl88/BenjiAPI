using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class VetVisitMap : ClassMap<VetVisit>
    {
        public VetVisitMap()
        {
            Table("VetVisits");
            Id(x => x.VetVisitId);
            Map(x => x.Comments);
            Map(x => x.Title);
            Map(x => x.VisitDateTime);
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