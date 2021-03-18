using Models.Shared;
using Repository.Models;

namespace Repository
{
    public static class VetVisitExtensions
    {
        public static VetVisitModel ToVetVisitModel(this VetVisit dbVetVisit)
        {
            return new VetVisitModel()
            {
                VetVisitId = new VetVisitId() { Value = dbVetVisit.VetVisitId },
                Comments = dbVetVisit.Comments,
                Title = dbVetVisit.Title,
                VisitDateTime = dbVetVisit.VisitDateTime,
                Doctor = dbVetVisit.Doctor,
                Company = dbVetVisit.Company,
                Address = dbVetVisit.Address,
                Dog = dbVetVisit.Dog.ToDogModel(),
                Created = dbVetVisit.Created,
                Modified = dbVetVisit.Modified,
                Deleted = dbVetVisit.Deleted
            };
        }
    }
}