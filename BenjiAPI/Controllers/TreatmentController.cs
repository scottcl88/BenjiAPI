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
    public class TreatmentController : ControllerBase
    {
        private readonly TreatmentManager _treatmentManager;
        private readonly DogManager _dogManager;
        private readonly ILogger<TreatmentController> _logger;

        public TreatmentController(ILogger<TreatmentController> logger, TreatmentManager treatmentManager, DogManager dogManager)
        {
            _logger = logger;
            _treatmentManager = treatmentManager;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<TreatmentModel> GetAll()
        {
            var defaultDog = _dogManager.GetDefaultDog();
            return _treatmentManager.GetAllTreatment(defaultDog);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public TreatmentModel Get(int Id)
        {
            return _treatmentManager.GetTreatmentById(new TreatmentId() { Value = Id });
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] TreatmentCreateRequest request)
        {
            return _treatmentManager.CreateNewTreatment(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] TreatmentUpdateRequest request)
        {
            return _treatmentManager.UpdateTreatment(request);
        }

        [HttpPost]
        [Route("Delete")]
        [EnableCors("MyPolicy")]
        public bool Delete([FromBody] TreatmentDeleteRequest request)
        {
            return _treatmentManager.DeleteTreatment(request);
        }
    }
}