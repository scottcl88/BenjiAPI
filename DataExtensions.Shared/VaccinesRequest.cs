using Models;
using Models.Shared;

namespace DataExtensions
{
    public class VaccineCreateRequest
    {
        public VaccineCreateRequest()
        {
            Vaccine = new VaccineModel();
        }
        public VaccineModel Vaccine { get; set; }
    }

    public class VaccineUpdateRequest
    {
        public VaccineUpdateRequest()
        {
            Vaccine = new VaccineModel();
        }
        public VaccineModel Vaccine { get; set; }
    }
    public class VaccineDeleteRequest
    {
        public VaccineId VaccineId { get; set; }
    }
}