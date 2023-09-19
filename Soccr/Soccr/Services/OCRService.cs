using Microsoft.Maui.Graphics.Platform;
using System.Diagnostics;

namespace Soccr.Services
{
    class OCRService
    {
        public static async Task<string> ParseImageFromStream(Stream image)
        {
            try
            {
                var scannedImage = PlatformImage.FromStream(image);
                var imageStream = scannedImage.AsStream();

                var imageBytes = new byte[imageStream.Length];
                await imageStream.ReadAsync(imageBytes, 0, (int)imageStream.Length);

                string response = await HttpService.PostImageAsync(imageBytes, "image", "image.png");
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return await Task.FromResult<string>(null);
            }
        }
    }
}
