using DataExtensions;
using Models;
using Models.Shared;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class VaccineManager
    {
        private readonly VaccineRepository _vaccinesRepository;

        public VaccineManager()
        {
            _vaccinesRepository = new VaccineRepository();
        }

        public List<VaccineModel> GetAllVaccine(DogModel dogModel)
        {
            return _vaccinesRepository.GetAllVaccineForDog(dogModel.DogId).ToList();
        }
        public VaccineModel GetVaccineById(VaccineId vaccinesId)
        {
            return _vaccinesRepository.GetVaccineById(vaccinesId);
        }

        public bool CreateNewVaccine(VaccineCreateRequest request)
        {
            return _vaccinesRepository.CreateVaccine(request.Vaccine);
        }

        public bool UpdateVaccine(VaccineUpdateRequest request)
        {
            return _vaccinesRepository.UpdateVaccine(request.Vaccine);
        }
        public bool DeleteVaccine(VaccineDeleteRequest request)
        {
            return _vaccinesRepository.DeleteVaccine(request);
        }
    }
}