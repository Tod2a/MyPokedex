namespace MyPokedex.Data
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Level { get; set; } = 1;
        public string Sprite { get; set; }
        public string ShinySprite { get; set; }
        public string Type { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public List<StatsInfo> Stats { get; set; }

        public void LevelUp()
        {
            Level++;

            foreach(StatsInfo stats in Stats)
            {
                stats.BaseStat += 5;
            }
        }
    }
}
