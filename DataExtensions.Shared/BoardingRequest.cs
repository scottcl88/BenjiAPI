using Models;
using Models.Shared;

namespace DataExtensions
{
    public class BoardingCreateRequest
    {
        public BoardingCreateRequest()
        {
            Boarding = new BoardingModel();
        }
        public BoardingModel Boarding { get; set; }
    }

    public class BoardingUpdateRequest
    {
        public BoardingUpdateRequest()
        {
            Boarding = new BoardingModel();
        }
        public BoardingModel Boarding { get; set; }
    }
    public class BoardingDeleteRequest
    {
        public BoardingId BoardingId { get; set; }
    }
}