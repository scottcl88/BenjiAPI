using DataExtensions;
using Models;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class HealthManager
    {
        private readonly HealthRepository _healthRepository;

        public HealthManager()
        {
            _healthRepository = new HealthRepository();
        }

        public List<HealthModel> GetAllHealth(DogModel dogModel)
        {
            return _healthRepository.GetAllHealthForDog(dogModel.DogId).ToList();
        }

        public HealthModel GetHealthById(HealthId healthId)
        {
            return _healthRepository.GetHealthById(healthId);
        }

        public bool CreateNewHealth(HealthCreateRequest request)
        {
            return _healthRepository.CreateHealth(request.Health);
        }

        public bool UpdateHealth(HealthUpdateRequest request)
        {
            return _healthRepository.UpdateHealth(request.Health);
        }
    }
}