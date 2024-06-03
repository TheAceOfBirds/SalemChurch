namespace BlankMVC.Models.Pets.API
{
    public class Attributes
    {
        public string name { get; set; }
        public string description { get; set; }
        public maxmin life { get; set; }
        public maxmin male_weight { get; set; }
        public maxmin female_weight { get; set; }
        public bool hypoallergenic { get; set; }
    }
    public class maxmin
    {
        public int max { get; set; }
        public int min { get; set; }
    }
}
