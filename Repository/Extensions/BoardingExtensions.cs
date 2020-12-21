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
                Comments = dbBoarding.Comments,
                Company = dbBoarding.Company,
                Address = dbBoarding.Address,
                Reason = dbBoarding.Reason,
                PaymentAmount = dbBoarding.PaymentAmount,
                Dog = dbBoarding.Dog.ToDogModel(),
                Website = dbBoarding.Website,
                StartDateTime = dbBoarding.StartDateTime,
                EndDateTime = dbBoarding.EndDateTime,
                Created = dbBoarding.Created,
                Modified = dbBoarding.Modified,
                Deleted = dbBoarding.Deleted
            };
        }
    }
}
