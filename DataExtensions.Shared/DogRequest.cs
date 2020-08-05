using Models;

namespace DataExtensions
{
    public class DogCreateRequest
    {
        public DogCreateRequest()
        {
            Dog = new DogModel();
        }
        public DogModel Dog { get; set; }
    }

    public class DogUpdateRequest
    {
        public DogUpdateRequest()
        {
            Dog = new DogModel();
        }
        public DogModel Dog { get; set; }
    }
}