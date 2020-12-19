using System;
namespace DotNetTestApi.Models
{
    public class Track
    {
        public int id { get; set; }
        public string title { get; set; }
        public string genre { get; set; }
        public Artist artist { get; set; }

        public Track()
        {
        }
    }
}
