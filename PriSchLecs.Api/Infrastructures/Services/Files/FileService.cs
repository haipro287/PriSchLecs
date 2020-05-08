using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PriSchLecs.Api.Domains.Files;
using PriSchLecs.Api.Dtos.Models.Files;
using PriSchLecs.Api.Dtos.Results;
using PriSchLecs.Api.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PriSchLecs.Api.Infrastructures.Services.Files
{
    public interface IFileService
    {
        Task<BaseResult> Upload(FileModel model);
    }

    public class FileService : IFileService
    {
        private readonly IRepository<Domains.Files.File> FileRepository;

        private readonly IWebHostEnvironment WebHostEnvironment;

        private string Domain = "localhost:44356\\";

        private string[] permittedExtensions = { ".txt", ".pdf", ".docx", ".pptx", ".xlsx", "png", "jpg", "mp4", "mp3" };

        public FileService(IRepository<Domains.Files.File> fileRepository, IWebHostEnvironment webHostEnvironment)
        {
            FileRepository = fileRepository;
            WebHostEnvironment = webHostEnvironment;
        }

        public async Task<BaseResult> Upload(FileModel model)
        {
            var result = new UploadResult();
            try
            {
                if (model.File.Length > 0)
                {
                    //create path directory
                    if (!Directory.Exists($"{WebHostEnvironment.WebRootPath}\\upload\\")) ;
                    {
                        Directory.CreateDirectory($"{WebHostEnvironment.WebRootPath}\\upload\\");
                    }

                    //extension validation
                    var extension = Path.GetExtension(model.File.FileName).ToLowerInvariant();
                    if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                    {
                        result.Result = Result.Failed;
                        result.Message = $"Định dạng file không hợp lệ, hãy sử dụng file có định dạng: {permittedExtensions}";
                    }

                    var temp = Path.GetTempFileName();
                    using (var fileStream = System.IO.File.Create($"{WebHostEnvironment.WebRootPath}\\upload\\{temp}"))
                    {
                        await model.File.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        //var file = new Domains.Files.File()
                        //{
                        //    Name = temp,
                        //    Path = $"{WebHostEnvironment.WebRootPath}\\upload\\",
                        //    Domain = Domain
                        //};
                        //await FileRepository.InsertAsync(file);
                        //result.Id = file.Id;
                    }
                }
                else
                {
                    result.Result = Result.Failed;
                    result.Message = "Không tìm thấy file";
                }
            }
            catch (Exception e)
            {
                result.Result = Result.SystemError;
                result.Message = e.ToString();
            }
            return result;
        }
    }
}
