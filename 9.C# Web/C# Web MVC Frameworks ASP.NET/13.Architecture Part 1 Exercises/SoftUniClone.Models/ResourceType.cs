using System.Collections.Generic;

namespace SoftUniClone.Models
{
    public class ResourceType
    {
        public ResourceType()
        {
            this.Resources = new List<Resource>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}