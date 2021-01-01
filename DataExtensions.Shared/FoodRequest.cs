using Models.Shared;

namespace DataExtensions
{
    public class FoodCreateRequest
    {
        public FoodCreateRequest()
        {
            Food = new FoodModel();
        }

        public FoodModel Food { get; set; }
    }

    public class FoodUpdateRequest
    {
        public FoodUpdateRequest()
        {
            Food = new FoodModel();
        }

        public FoodModel Food { get; set; }
    }
}