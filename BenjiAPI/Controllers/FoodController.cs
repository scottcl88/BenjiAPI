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
    public class FoodController : ControllerBase
    {
        private readonly FoodManager _foodManager;
        private readonly DogManager _dogManager;
        private readonly ILogger<FoodController> _logger;

        public FoodController(ILogger<FoodController> logger, FoodManager foodManager, DogManager dogManager)
        {
            _logger = logger;
            _foodManager = foodManager;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<FoodModel> GetAll()
        {
            var defaultDog = _dogManager.GetDefaultDog();
            return _foodManager.GetAllFood(defaultDog);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public FoodModel Get(int Id)
        {
            return _foodManager.GetFoodById(new FoodId() { Value = Id });
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] FoodCreateRequest request)
        {
            return _foodManager.CreateNewFood(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] FoodUpdateRequest request)
        {
            return _foodManager.UpdateFood(request);
        }
    }
}