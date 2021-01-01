using Models;

namespace DataExtensions
{
    public class HealthCreateRequest
    {
        public HealthCreateRequest()
        {
            Health = new HealthModel();
        }

        public HealthModel Health { get; set; }
    }

    public class HealthUpdateRequest
    {
        public HealthUpdateRequest()
        {
            Health = new HealthModel();
        }

        public HealthModel Health { get; set; }
    }
}