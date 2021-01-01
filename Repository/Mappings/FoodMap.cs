using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class FoodMap : ClassMap<Food>
    {
        public FoodMap()
        {
            Table("Food");
            Id(x => x.FoodId);
            Map(x => x.AmountInOunces).Nullable();
            Map(x => x.FrequencyPerDay).Nullable();
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted);
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}