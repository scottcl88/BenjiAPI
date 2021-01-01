using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class BoardingMap : ClassMap<Boarding>
    {
        public BoardingMap()
        {
            Table("Boarding");
            Id(x => x.BoardingId);
            Map(x => x.StartDateTime);
            Map(x => x.EndDateTime);
            Map(x => x.Company);
            Map(x => x.Comments);
            Map(x => x.Reason);
            Map(x => x.Address);
            Map(x => x.PaymentAmount);
            Map(x => x.Website);
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted);
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}