namespace RestFulAPI.Core.Models
{
    public class HouseImage
    {
        public int Id { get; set; }

        public int HouseId { get; set; }

        public House House { get; set; }

        public string MainImageName { get; set; }

        public string BigImageName { get; set; }

        public string FirstSmallImageName { get; set; }

        public string SecondSmallImageName { get; set; }
    }
}
