using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class TreatmentMap : ClassMap<Treatment>
    {
        public TreatmentMap()
        {
            Table("Treatments");
            Id(x => x.TreatmentId);
            Map(x => x.Comments);
            Map(x => x.Title);
            Map(x => x.ReceivedDateTime);
            Map(x => x.Doctor);
            Map(x => x.Amount);
            Map(x => x.ExpirationDateTime);
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted);
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}