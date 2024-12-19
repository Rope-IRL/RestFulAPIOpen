namespace RestFulAPI.Core.Models
{
    public class RoomImage
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public string MainImageName { get; set; }

        public string BigImageName { get; set; }

        public string FirstSmallImageName { get; set; }

        public string SecondSmallImageName { get; set; }
    }
}
