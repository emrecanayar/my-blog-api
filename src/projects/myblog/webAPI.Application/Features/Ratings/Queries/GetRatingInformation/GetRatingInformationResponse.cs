using Application.Features.Auth.Commands.Login;

namespace webAPI.Application.Features.Ratings.Queries.GetRatingInformation
{
    public class GetRatingInformationResponse : IResponse
    {
        public Guid Id { get; set; }
        public bool IsThere { get; set; }
        public int Score { get; set; }
    }
}
