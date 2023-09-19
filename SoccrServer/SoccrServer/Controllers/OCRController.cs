using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Tesseract;

namespace SoccrServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OCRController : Controller
    {
        string folderName = "images";
        string trainedDataFolderName = "tessdata";

        [HttpPost]
        public IActionResult Recognize(IFormFile image)
        {
            string name = image.FileName;

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(folderName, image.FileName), FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }

            string tessPath = Path.Combine(trainedDataFolderName, "");
            string result = "";

            Bitmap bmp = new Bitmap(Path.Combine(folderName, image.FileName));
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            bmp.Save(Path.Combine(folderName, image.FileName));

            using (var engine = new TesseractEngine(tessPath, "hrv", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(Path.Combine(folderName, image.FileName)))
                {
                    var page = engine.Process(img);
                    result = page.GetText();
                }
            }
            return Ok(String.IsNullOrWhiteSpace(result) ? "Ocr is finished. Return empty" : result);
        }
    }
}
