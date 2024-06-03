namespace BlankMVC.Models.Pets.API
{
    public class Relationships
    {
        public Group group { get; set; }
    }
    public class Group
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public string id { get; set; }
        public string type { get; set; }
    }
}
