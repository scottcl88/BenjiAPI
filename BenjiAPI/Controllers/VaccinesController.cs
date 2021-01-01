using Business;
using DataExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Shared;
using System.Collections.Generic;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class VaccineController : ControllerBase
    {
        private readonly VaccineManager _vaccineManager;
        private readonly DogManager _dogManager;
        private readonly ILogger<VaccineController> _logger;

        public VaccineController(ILogger<VaccineController> logger, VaccineManager vaccineManager, DogManager dogManager)
        {
            _logger = logger;
            _vaccineManager = vaccineManager;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<VaccineModel> GetAll()
        {
            var defaultDog = _dogManager.GetDefaultDog();
            return _vaccineManager.GetAllVaccine(defaultDog);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public VaccineModel Get(int Id)
        {
            return _vaccineManager.GetVaccineById(new VaccineId() { Value = Id });
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] VaccineCreateRequest request)
        {
            return _vaccineManager.CreateNewVaccine(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] VaccineUpdateRequest request)
        {
            return _vaccineManager.UpdateVaccine(request);
        }

        [HttpPost]
        [Route("Delete")]
        [EnableCors("MyPolicy")]
        public bool Delete([FromBody] VaccineDeleteRequest request)
        {
            return _vaccineManager.DeleteVaccine(request);
        }
    }
}