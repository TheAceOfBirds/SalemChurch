﻿namespace BlankMVC.Models.Pets.API
{
    public class Dog
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes attributes { get; set; }
        public Relationships relationships { get; set; }
    }
}
