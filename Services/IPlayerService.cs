using AtelierTest.Models;

namespace AtelierTest.Services
{
    public interface IPlayerService
    {
        public List<Player> GetPlayersOrderByRank();

        public Player GetPlayerById(int id);

        public string GetWonCountry();

        public  float GetIMC();

        public double GetMedian();
    }
}
