using Models;

namespace DataExtensions
{
    public partial class DogCreateRequest
    {
        public DogCreateRequest()
        {
            Dog = new DogModel();
        }

        public DogModel Dog { get; set; }
    }

    public partial class DogUpdateRequest
    {
        public DogUpdateRequest()
        {
            Dog = new DogModel();
        }

        public DogModel Dog { get; set; }
    }
}