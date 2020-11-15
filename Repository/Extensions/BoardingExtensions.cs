using Models;
using Models.Shared;
using Repository.Models;
using System.Linq;

namespace Repository
{
    public static class BoardingExtensions
    {
        public static BoardingModel ToBoardingModel(this Boarding dbBoarding)
        {
            return new BoardingModel()
            {
                BoardingId = new BoardingId() { Value = dbBoarding.BoardingId },
                Created = dbBoarding.Created,
                Modified = dbBoarding.Modified,
                Deleted = dbBoarding.Deleted
            };
        }
    }
}
