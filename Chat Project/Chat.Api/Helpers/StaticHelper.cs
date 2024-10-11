namespace Chat.Api.Helpers;


public static class StaticHelper
{
    public static string GetFullName(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }

    public static bool IsPhoto(IFormFile file)
    {
        return   file.ContentType 
            is UserConstants.JpgType 
            or UserConstants.PngType;
    }

    public static byte[] GetData(IFormFile file)
    {
        
        var ms = new MemoryStream();

        file.CopyTo(target: ms);

        return ms.ToArray();

    }
}
