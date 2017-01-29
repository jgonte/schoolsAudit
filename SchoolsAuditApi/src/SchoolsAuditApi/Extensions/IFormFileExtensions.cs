using Microsoft.AspNetCore.Http;
using System.IO;

namespace SchoolsAudit
{
    public static class IFormFileExtensions
    {
        public static byte[] GetContent(this IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}
