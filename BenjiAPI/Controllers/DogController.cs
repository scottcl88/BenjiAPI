using Business;
using DataExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class DogController : ControllerBase
    {
        private readonly DogManager _dogManager;
        private readonly ILogger<DogController> _logger;

        public DogController(ILogger<DogController> logger, DogManager dogManager)
        {
            _logger = logger;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<DogModel> GetAll()
        {
            return _dogManager.GetAllDogs();
        }

        [HttpGet]
        [Route("Get")]
        [EnableCors("MyPolicy")]
        public DogModel Get()
        {
            return _dogManager.GetDefaultDog();
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public DogModel Get(int Id)
        {
            try
            {
                return _dogManager.GetDogById(new DogId() { Value = Id });
            }
            catch (Exception ex)
            {
                return new DogModel()
                {
                    Name = ex.Message
                };
            }
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] DogCreateRequest request)
        {
            return _dogManager.CreateNewDog(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] DogUpdateRequest request)
        {
            return _dogManager.UpdateDog(request);
        }
    }
}