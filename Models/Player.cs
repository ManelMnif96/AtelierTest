namespace AtelierTest.Models
{
    public class Player
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string shortName { get; set; }

        public string sex { get; set; }

        public Country country { get; set; }

        public string picture { get; set; }

        public Data data {  get; set; }

    }
}
