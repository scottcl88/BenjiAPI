using DataExtensions;
using Models.Shared;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class FoodManager
    {
        private readonly FoodRepository _foodRepository;

        public FoodManager()
        {
            _foodRepository = new FoodRepository();
        }

        public List<FoodModel> GetAllFood(DogModel dogModel)
        {
            return _foodRepository.GetAllFoodForDog(dogModel.DogId).ToList();
        }

        public FoodModel GetFoodById(FoodId foodId)
        {
            return _foodRepository.GetFoodById(foodId);
        }

        public bool CreateNewFood(FoodCreateRequest request)
        {
            return _foodRepository.CreateFood(request.Food);
        }

        public bool UpdateFood(FoodUpdateRequest request)
        {
            return _foodRepository.UpdateFood(request.Food);
        }
    }
}