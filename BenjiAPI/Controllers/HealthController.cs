using Business;
using DataExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Collections.Generic;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class HealthController : ControllerBase
    {
        private readonly HealthManager _healthManager;
        private readonly DogManager _dogManager;
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger, HealthManager healthManager, DogManager dogManager)
        {
            _logger = logger;
            _healthManager = healthManager;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<HealthModel> GetAll()
        {
            var defaultDog = _dogManager.GetDefaultDog();
            return _healthManager.GetAllHealth(defaultDog);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public HealthModel Get(int Id)
        {
            return _healthManager.GetHealthById(new HealthId() { Value = Id });
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] HealthCreateRequest request)
        {
            return _healthManager.CreateNewHealth(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] HealthUpdateRequest request)
        {
            return _healthManager.UpdateHealth(request);
        }
    }
}