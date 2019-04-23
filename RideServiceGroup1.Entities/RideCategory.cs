using System;

namespace RideServiceGroup1.Entities
{
    public class RideCategory
    {
        private string name;

        public RideCategory(int id, string name = "Nameless", string description = "This is a ride")
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get => name; set => name = value; }
        public string Description { get; set; }
    }
}
