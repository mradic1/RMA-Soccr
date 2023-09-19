using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoccrServer.Models;
using System.Net;

namespace SoccrServer.Services
{
    public class PlayersService
    {
        List<PlayerModel> _players;
        public PlayersService()
        {
            _players = new List<PlayerModel>();
        }
        public bool Add(string playersJson)
        {
            if (string.IsNullOrEmpty(playersJson))
                return false;

            try
            {
                _players = JsonConvert.DeserializeObject<List<PlayerModel>>(playersJson);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public void Clear()
        {
            _players.Clear();
        }
        public string Get()
        {
            if (_players.Count <= 0)
                return "";

            return JsonConvert.SerializeObject(_players);
        }
    }
}
