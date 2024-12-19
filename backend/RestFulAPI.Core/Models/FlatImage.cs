namespace RestFulAPI.Core.Models
{
    public class FlatImage
    {
        public int Id { get; set; }

        public int FlatId { get; set; }

        public Flat Flat {get; set;}

        public string MainImageName { get; set; }

        public string BigImageName { get; set; }

        public string FirstSmallImageName { get; set; }

        public string SecondSmallImageName { get; set; }
    }
}
