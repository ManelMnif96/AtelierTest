using AtelierTest.Models;
using Newtonsoft.Json;

namespace AtelierTest.Services
{
    public class PlayerService : IPlayerService
    {

        private List<Player> GetPlayersFromJson()
        
        {
            
            var json = new List<Player>();
            using (StreamReader sr = File.OpenText("C:\\Users\\Dell\\source\\repos\\AtelierTest\\AtelierTest\\players.json"))
         
            {
                List<Player> players = JsonConvert.DeserializeObject<List<Player>>(sr.ReadToEnd());
                json.AddRange(players);
            }

            return json;
        }

        public List<Player> GetPlayersOrderByRank()
        {
            List<Player> players = this.GetPlayersFromJson();
            return players.OrderBy(x => x.data.rank).ToList();
        }

        public Player GetPlayerById(int id)
        {
            List<Player> players = this.GetPlayersFromJson();
            return players.Where(x => x.id == id).First();
        }

        public string GetWonCountry()
        
        {
            List<Player> players = this.GetPlayersFromJson();
            string country = players[0].country.code;
            int points = players[0].data.points;
            for (int i = 1; i < players.Count; i++)
            {
                if (points < players[i].data.points && country != players[i].country.code)
                {
                    points = players[i].data.points;
                    country = players[i].country.code;
                }
                else if (points < players[i].data.points && country != players[i].country.code)
                {
                    continue;
                }
                else if (country == players[i].country.code)
                {
                    points = points + players[i].data.points;
                }
                else continue;
            }

            return country;   
            
        }

        public float GetIMC()
        {
            List<Player> players = this.GetPlayersFromJson();
            float imcTotal = 0;
            foreach (var p in players)
            {
                float imc = (float)p.data.weight / ((float)p.data.height * (float)p.data.height) * 10;
                imcTotal = imcTotal +imc;
            }

            return imcTotal / players.Count ;
        }

        public double GetMedian()
        {
            List<Player> players = this.GetPlayersFromJson();
            List<int> playersHeight = new List<int>();
            foreach (var p in players)
            {
                playersHeight.Add(p.data.height);
            }
            playersHeight.Sort();
            double median = (playersHeight.Count % 2 != 0) ? playersHeight[playersHeight.Count / 2] : (playersHeight[playersHeight.Count / 2] + playersHeight[playersHeight.Count / 2 - 1]) / 2;
            return median;
        }
    }
}
