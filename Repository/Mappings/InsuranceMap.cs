using FluentNHibernate.Mapping;
using Repository.Models;
using System;

namespace Repository.Mappings
{
    public class InsuranceMap : ClassMap<Insurance>
    {
        public InsuranceMap()
        {
            Table("Insurance");
            Id(x => x.InsuranceId);
            Map(x => x.PolicyId);
            Map(x => x.AnnualCoverageLimit);
            Map(x => x.UnlimitedAnnualCoverageLimit);
            Map(x => x.DeductibleAmount);
            Map(x => x.EndDateTime);
            Map(x => x.PaymentAmount);
            Map(x => x.PaymentFrequency).Nullable().CustomType<TimeSpan>();
            Map(x => x.Company);
            Map(x => x.ReimbursementPercentage);
            Map(x => x.RenewalDateTime);
            Map(x => x.StartDateTime);
            Map(x => x.Website);
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted);
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}