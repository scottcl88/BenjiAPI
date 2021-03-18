using Models.Shared;
using Repository.Models;

namespace Repository
{
    public static class TreatmentExtensions
    {
        public static TreatmentModel ToTreatmentModel(this Treatment dbTreatment)
        {
            return new TreatmentModel()
            {
                TreatmentId = new TreatmentId() { Value = dbTreatment.TreatmentId },
                Comments = dbTreatment.Comments,
                Title = dbTreatment.Title,
                ReceivedDateTime = dbTreatment.ReceivedDateTime,
                Doctor = dbTreatment.Doctor,
                Amount = dbTreatment.Amount,
                ExpirationDateTime = dbTreatment.ExpirationDateTime,
                Dog = dbTreatment.Dog.ToDogModel(),
                Created = dbTreatment.Created,
                Modified = dbTreatment.Modified,
                Deleted = dbTreatment.Deleted
            };
        }
    }
}