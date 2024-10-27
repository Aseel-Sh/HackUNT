using Backend.Data.Data;
using Backend.Data.Models;
using Backend.Service.DTOs;
using Backend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Repositories
{
    public class AttachmentService : IAttachmentService
    {
        private readonly ApplicationDbContext _context;
        public AttachmentService(ApplicationDbContext content)
        {
            _context = content;
        }

        public string UploadUserProfilePicture(AttachmentDTO.CreateUserAttachmentDTO dto)
        {
            if (!_context.Users.Any(u => u.Id == dto.UserId))
            {
                throw new Exception("UserId does not exist.");
            }

            ValidateFile(dto.FileName, dto.FilePath);
            return SaveAttachment(dto.UserId, dto.FileName, dto.FilePath);

        }

        public void ValidateFile(string fileName, string filePath)
        {
            string validExtensions = ".png";
            string extension = Path.GetExtension(fileName)?.ToLower();
            if (string.IsNullOrEmpty(extension) || !validExtensions.Contains(extension))
            {
                throw new Exception($"Extension is not valid ({string.Join(',', validExtensions)})");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.", filePath);
            }

            FileInfo fileInfo = new FileInfo(filePath);
            long size = fileInfo.Length;
            if (size > (2 * 1024 * 1024))
            {
                throw new Exception("Maximum size is 2MB.");
            }
        }

        private string SaveAttachment(int userId, string fileName, string filePath)
        {


            string extension = Path.GetExtension(fileName).ToLower();
            string generatedFileName = Guid.NewGuid().ToString() + extension;
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Attachments");

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string targetFilePath = Path.Combine(targetDirectory, generatedFileName);
            File.Copy(filePath, targetFilePath, overwrite: true);

            var attachment = new Attachment
            {
                UserId = userId,
                FileName = generatedFileName,
                FilePath = targetFilePath,
                CreatedAt = DateTime.Now
            };

            _context.Attachments.Add(attachment);
            _context.SaveChanges();

            return generatedFileName;
        }

    }
}
