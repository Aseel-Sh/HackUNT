using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Service.DTOs.AttachmentDTO;

namespace Backend.Service.Interfaces
{
    public interface IAttachmentService
    {
        string UploadUserProfilePicture(CreateUserAttachmentDTO dto);
        void ValidateFile(string fileName, string filePah);

    }
}
