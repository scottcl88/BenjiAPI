using DataExtensions;
using Models.Shared;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class InsuranceManager
    {
        private readonly InsuranceRepository _insuranceRepository;

        public InsuranceManager()
        {
            _insuranceRepository = new InsuranceRepository();
        }

        public List<InsuranceModel> GetAllInsurance(DogModel dogModel)
        {
            return _insuranceRepository.GetAllInsuranceForDog(dogModel.DogId).ToList();
        }

        public InsuranceModel GetDefaultInsurance()
        {
            return _insuranceRepository.GetDefaultInsurance();
        }

        public InsuranceModel GetInsuranceById(InsuranceId insuranceId)
        {
            return _insuranceRepository.GetInsuranceById(insuranceId);
        }

        public bool CreateNewInsurance(InsuranceCreateRequest request)
        {
            return _insuranceRepository.CreateInsurance(request.Insurance);
        }

        public bool UpdateInsurance(InsuranceUpdateRequest request)
        {
            return _insuranceRepository.UpdateInsurance(request.Insurance);
        }

        public bool DeleteInsurance(InsuranceDeleteRequest request)
        {
            return _insuranceRepository.DeleteInsurance(request);
        }
    }
}