namespace ApplicationCore.Entities
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Artist { get; set; }
        public string Shortname { get; set; }
        public int? BPM { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string SpotifyId { get; set; }
        public string Album { get; set; }
    }
}
