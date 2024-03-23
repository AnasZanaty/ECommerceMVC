namespace session3_MVC.wwwroot.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file , string folderName)
        {
            //1- Get Located folder path

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName);

            //2- Get file name and make it unique

            var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

            //3- Get file path

            var filePath = Path.Combine(folderPath, fileName);

            //

            using var filestream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(filestream);

            return fileName;
        }
    }
}
