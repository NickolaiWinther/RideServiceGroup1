using System;

namespace RideServiceGroup1.Entities
{
    public class RideCategory
    {
        private string description;
        public RideCategory()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description
        {
            get => description;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Must contain data");
                }
                description = value;
            }
        }
    }
}
