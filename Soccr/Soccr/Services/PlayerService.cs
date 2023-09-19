using Soccr.Models;
using System.Text.RegularExpressions;

namespace Soccr.Services
{
    internal class PlayerService
    {
        private static readonly string _regexPattern = @"\b((\d{1,2}\s+)([A-Za-zšđžčćŠĐŽČĆ]+\s*){1,4})([0-9/(V)]*\s+)([0-9]{4,6})";
        public static List<PlayerModel> ParsePlayersFromResponse(string response)
        {
            Regex regex = new Regex(_regexPattern);
            MatchCollection matches = regex.Matches(response);

            List<PlayerModel> result = new List<PlayerModel>();

            foreach (Match match in matches)
            {
                string playerNumber = match.Groups[2].Value;
                string playerName = match.Groups[1].Value.Replace(playerNumber, string.Empty);
                result.Add(new PlayerModel(int.Parse(playerNumber), playerName));
            }
            return result;
        }
    }
}
