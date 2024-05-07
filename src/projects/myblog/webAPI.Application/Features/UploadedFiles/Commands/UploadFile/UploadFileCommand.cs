using Azure.Security.KeyVault.Secrets;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using Core.Helpers.Services;
using Core.Helpers.Services.ConfigurationServices;
using Core.Helpers.Services.ConfigurationServices.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;
using webAPI.Application.Features.UploadedFiles.Dtos;
using webAPI.Application.Features.UploadedFiles.Rules;
using webAPI.Application.Services.UploadedFileService;

namespace webAPI.Application.Features.UploadedFiles.Commands.UploadFile
{
    public class UploadFileCommand : IRequest<CustomResponseDto<UploadedFileCreatedDto>>
    {
        public IFormFile File { get; set; }

        public UploadFileCommand()
        {
            File = null!;
        }

        public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, CustomResponseDto<UploadedFileCreatedDto>>
        {
            private readonly string UPLOADEDFILE_FOLDER = Path.Combine("Resources", "UploadedFiles", "DocumentPool");
            private readonly IUploadedFileService _uploadedFileService;
            private readonly IConfigurationService _configurationService;
            private readonly UploadedFileBusinessRules _uploadedFileBusinessRules;

            public UploadFileCommandHandler(IUploadedFileService uploadedFileService, UploadedFileBusinessRules uploadedFileBusinessRules, IConfigurationService configurationService)
            {
                _uploadedFileService = uploadedFileService;
                _uploadedFileBusinessRules = uploadedFileBusinessRules;
                _configurationService = configurationService;
            }

            public async Task<CustomResponseDto<UploadedFileCreatedDto>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
            {
                FileHelper.GenerateUrl filePath = FileHelper.AzureGenerateURLForFile(request.File, UPLOADEDFILE_FOLDER);
                UploadedFile uploadedFile = await this._uploadedFileService.AddOrUpdateDocument(new UploadedFileDto
                {
                    FileType = this._uploadedFileBusinessRules.DetectFileType(filePath.Path),
                    FileName = request.File.FileName + filePath.FileType,
                    Path = filePath.Path,
                    Extension = FileInfoHelper.GetFileExtension(filePath.Path),
                    Directory = request.File.Name,
                });

                ConfigurationListModelDto? configurationList = _configurationService.GetConfigurationList();
                KeyVaultSecret secretBlobStorage = configurationList.SecretClient.GetSecret("MyBlogBlobStorageConfig");
                string? azureBlobConnectionString = secretBlobStorage.Value;
                string? azureBlobContainerName = "myblogfiles";
                AzureBlobStorageService azureBlobStorageService = new AzureBlobStorageService(azureBlobConnectionString, azureBlobContainerName);
                await azureBlobStorageService.UploadFileAsync(filePath.Path, request.File);
                return CustomResponseDto<UploadedFileCreatedDto>.Success((int)HttpStatusCode.Created, new UploadedFileCreatedDto { Path = filePath.Path, Token = uploadedFile.Token }, true);
            }
        }
    }
}
