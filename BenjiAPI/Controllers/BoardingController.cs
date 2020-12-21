using System;
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
using Models.Shared;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class BoardingController : ControllerBase
    {
        private BoardingManager _boardingManager;
        private DogManager _dogManager;
        private readonly ILogger<BoardingController> _logger;

        public BoardingController(ILogger<BoardingController> logger, BoardingManager boardingManager, DogManager dogManager)
        {
            _logger = logger;
            _boardingManager = boardingManager;
            _dogManager = dogManager;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<BoardingModel> GetAll()
        {
            var defaultDog = _dogManager.GetDefaultDog();
            return _boardingManager.GetAllBoarding(defaultDog);
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public BoardingModel Get(int Id)
        {
            return _boardingManager.GetBoardingById(new BoardingId() { Value = Id });
        }
        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] BoardingCreateRequest request)
        {
            return _boardingManager.CreateNewBoarding(request);
        }
        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] BoardingUpdateRequest request)
        {
            return _boardingManager.UpdateBoarding(request);
        }
        [HttpPost]
        [Route("Delete")]
        [EnableCors("MyPolicy")]
        public bool Delete([FromBody] BoardingDeleteRequest request)
        {
            return _boardingManager.DeleteBoarding(request);
        }
    }
}
