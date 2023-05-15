using bookshop.Interfaces;

public class BufferedFileUploadLocalService : IBufferedFileUploadService
{
    public async Task<string> UploadFile(IFormFile file, string where)
    {
        string path = "";
        try
        {
            if (file.Length > 0)
            {
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot/" + where));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return file.FileName;
            }
            else
            {
                return "none";
            }
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }
    }
}