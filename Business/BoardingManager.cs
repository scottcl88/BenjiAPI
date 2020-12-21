using DataExtensions;
using Models;
using Models.Shared;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class BoardingManager
    {
        private readonly BoardingRepository _boardingRepository;

        public BoardingManager()
        {
            _boardingRepository = new BoardingRepository();
        }

        public List<BoardingModel> GetAllBoarding(DogModel dogModel)
        {
            return _boardingRepository.GetAllBoardingForDog(dogModel.DogId).ToList();
        }
        public BoardingModel GetBoardingById(BoardingId boardingId)
        {
            return _boardingRepository.GetBoardingById(boardingId);
        }

        public bool CreateNewBoarding(BoardingCreateRequest request)
        {
            return _boardingRepository.CreateBoarding(request.Boarding);
        }

        public bool UpdateBoarding(BoardingUpdateRequest request)
        {
            return _boardingRepository.UpdateBoarding(request.Boarding);
        }
        public bool DeleteBoarding(BoardingDeleteRequest request)
        {
            return _boardingRepository.DeleteBoarding(request);
        }
    }
}