﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using DataExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class DogController : ControllerBase
    {
        private DogManager _dogManager;
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
            return _dogManager.GetDogById(new DogId() { Value = Id });
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
