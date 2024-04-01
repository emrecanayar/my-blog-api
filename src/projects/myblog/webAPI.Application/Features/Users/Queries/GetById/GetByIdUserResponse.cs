using Application.Features.FavoriteArticles.Queries.GetList;
using Application.Features.UserUploadedFiles.Queries.GetList;
using Core.Application.Responses;
using Core.Domain.ComplexTypes.Enums;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public RecordStatu Status { get; set; }
    public CultureType CultureType { get; set; }
    public IList<GetListUserUploadedFileListItemDto> UserUploadedFiles { get; set; }
    public IList<GetListFavoriteArticleListItemDto> FavoriteArticles { get; set; }

    public GetByIdUserResponse()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        UserUploadedFiles = [];
        FavoriteArticles = [];
    }

    public GetByIdUserResponse(Guid id, string firstName, string lastName, string email, RecordStatu status, CultureType culture)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
        CultureType = culture;
        UserUploadedFiles = [];
        FavoriteArticles = [];
    }
}
