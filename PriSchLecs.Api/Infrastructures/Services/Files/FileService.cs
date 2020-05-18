﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        Task<DownloadResult> Download(int id);
    }

    public class FileService : IFileService
    {
        private readonly IRepository<Domains.Files.File> FileRepository;

        private readonly IWebHostEnvironment WebHostEnvironment;

        private string Domain = "localhost:44356";

        private string[] permittedExtensions = { ".txt", ".pdf", ".docx", ".pptx", ".xlsx", ".png", ".jpg", ".mp4", ".mp3" };

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
                    //extension validation
                    var extension = Path.GetExtension(model.File.FileName).ToLowerInvariant();
                    if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
                    {
                        result.Result = Result.Failed;
                        result.Message = $"Định dạng file không hợp lệ, hãy sử dụng file có định dạng: {{{string.Join(", ", permittedExtensions)}}}";
                    }
                    else
                    {
                        //set new name if exists
                        model.Name = string.IsNullOrEmpty(model.Name) ? (model.File.FileName + extension) : (model.Name + extension);

                        //get hashed name
                        var hashName = model.File.FileName.GetHashCode().ToString() + extension;

                        //create path directory if not exists
                        var path = string.IsNullOrEmpty(model.Path) ? Path.Combine(WebHostEnvironment.WebRootPath, "upload") : Path.Combine(WebHostEnvironment.WebRootPath, "upload", model.Path);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        //upload file to directory
                        using (var fileStream = System.IO.File.Create(Path.Combine(path, hashName)))
                        {
                            //upload
                            await model.File.CopyToAsync(fileStream);
                            await fileStream.FlushAsync();

                            //create data in sql
                            var file = new Domains.Files.File()
                            {
                                Name = model.Name,
                                HashName = hashName,
                                Path = model.Path,
                                Domain = Domain
                            };
                            file.UpdateCommonInt();
                            await FileRepository.InsertAsync(file);
                            result.Id = file.Id;
                        }
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

        public async Task<DownloadResult> Download(int id)
        {
            var result = new DownloadResult();
            var file = FileRepository.GetById(id);
            if (file == null)
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy file";
                return result;
            }
            var path = string.IsNullOrEmpty(file.Path)? Path.Combine(WebHostEnvironment.WebRootPath, "upload", file.HashName) :Path.Combine(WebHostEnvironment.WebRootPath, "upload", file.Path, file.HashName);
            if (!File.Exists(path))
            {
                result.Result = Result.Failed;
                result.Message = "Không tìm thấy file";
                return result;
            }
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
                result.File = memory;
                result.Name = file.Name;
            }

            return result;
        }
    }
}
