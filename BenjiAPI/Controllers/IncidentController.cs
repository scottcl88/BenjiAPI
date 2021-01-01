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
    public class IncidentController : ControllerBase
    {
        private readonly IncidentManager _incidentManager;
        private readonly DogManager _dogManager;
        private readonly ILogger<IncidentController> _logger;

        public IncidentController(ILogger<IncidentController> logger, IncidentManager incidentManager, DogManager dogManager)
        {
            _logger = logger;
            _incidentManager = incidentManager;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<IncidentModel> GetAll()
        {
            var defaultDog = _dogManager.GetDefaultDog();
            return _incidentManager.GetAllIncident(defaultDog);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public IncidentModel Get(int Id)
        {
            return _incidentManager.GetIncidentById(new IncidentId() { Value = Id });
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] IncidentCreateRequest request)
        {
            return _incidentManager.CreateNewIncident(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] IncidentUpdateRequest request)
        {
            return _incidentManager.UpdateIncident(request);
        }

        [HttpPost]
        [Route("Delete")]
        [EnableCors("MyPolicy")]
        public bool Delete([FromBody] IncidentDeleteRequest request)
        {
            return _incidentManager.DeleteIncident(request);
        }
    }
}