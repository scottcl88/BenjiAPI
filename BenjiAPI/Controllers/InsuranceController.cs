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
    public class InsuranceController : ControllerBase
    {
        private readonly InsuranceManager _insuranceManager;
        private readonly DogManager _dogManager;
        private readonly ILogger<InsuranceController> _logger;

        public InsuranceController(ILogger<InsuranceController> logger, InsuranceManager insuranceManager, DogManager dogManager)
        {
            _logger = logger;
            _insuranceManager = insuranceManager;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<InsuranceModel> GetAll()
        {
            var defaultDog = _dogManager.GetDefaultDog();
            return _insuranceManager.GetAllInsurance(defaultDog);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public InsuranceModel Get(int Id)
        {
            return _insuranceManager.GetInsuranceById(new InsuranceId() { Value = Id });
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] InsuranceCreateRequest request)
        {
            return _insuranceManager.CreateNewInsurance(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] InsuranceUpdateRequest request)
        {
            return _insuranceManager.UpdateInsurance(request);
        }

        [HttpPost]
        [Route("Delete")]
        [EnableCors("MyPolicy")]
        public bool Delete([FromBody] InsuranceDeleteRequest request)
        {
            return _insuranceManager.DeleteInsurance(request);
        }
    }
}