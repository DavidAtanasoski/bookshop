using Microsoft.AspNetCore.WebUtilities;

namespace bookshop.Interfaces
{
    public interface IStreamFileUploadService
    {
        Task<bool> UploadFile(MultipartReader reader, MultipartSection section);
    }
}
