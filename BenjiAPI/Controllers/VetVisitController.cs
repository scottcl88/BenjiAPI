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
    public class VetVisitController : ControllerBase
    {
        private readonly VetVisitManager _VetVisitManager;
        private readonly DogManager _dogManager;
        private readonly ILogger<VetVisitController> _logger;

        public VetVisitController(ILogger<VetVisitController> logger, VetVisitManager VetVisitManager, DogManager dogManager)
        {
            _logger = logger;
            _VetVisitManager = VetVisitManager;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<VetVisitModel> GetAll()
        {
            var defaultDog = _dogManager.GetDefaultDog();
            return _VetVisitManager.GetAllVetVisit(defaultDog);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public VetVisitModel Get(int Id)
        {
            return _VetVisitManager.GetVetVisitById(new VetVisitId() { Value = Id });
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] VetVisitCreateRequest request)
        {
            return _VetVisitManager.CreateNewVetVisit(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] VetVisitUpdateRequest request)
        {
            return _VetVisitManager.UpdateVetVisit(request);
        }

        [HttpPost]
        [Route("Delete")]
        [EnableCors("MyPolicy")]
        public bool Delete([FromBody] VetVisitDeleteRequest request)
        {
            return _VetVisitManager.DeleteVetVisit(request);
        }
    }
}