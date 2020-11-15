using FluentNHibernate.Mapping;
using Repository.Models;
using NHibernate;

namespace Repository.Mappings
{
    public class BoardingMap : ClassMap<Boarding>
    {
        public BoardingMap()
        {
            Table("Boarding");
            Id(x => x.BoardingId);
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted);
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}
