using Models;
using Models.Shared;
using Repository.Models;
using System.Linq;

namespace Repository
{
    public static class VaccineExtensions
    {
        public static VaccineModel ToVaccineModel(this Vaccine dbVaccine)
        {
            return new VaccineModel()
            {
                VaccineId = new VaccineId() { Value = dbVaccine.VaccineId },
                Comments = dbVaccine.Comments,
                Title = dbVaccine.Title,
                Expiration = dbVaccine.Expiration,
                Received = dbVaccine.Received,
                Doctor = dbVaccine.Doctor,
                Company = dbVaccine.Company,
                Address = dbVaccine.Address,
                Dog = dbVaccine.Dog.ToDogModel(),
                Created = dbVaccine.Created,
                Modified = dbVaccine.Modified,
                Deleted = dbVaccine.Deleted
            };
        }
    }
}
