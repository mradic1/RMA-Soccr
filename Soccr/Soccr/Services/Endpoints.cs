using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccr.Services
{
    internal class Endpoints
    {
        public static string BaseURL = "http://192.168.8.104:5180";
        public static string RecognizeURL = BaseURL + "/api/OCR/Recognize";
        public static string LoginURL = BaseURL + "/api/Authorization/Login";
        public static string AddPlayersURL = BaseURL + "/api/Players/Add";
    }
}
