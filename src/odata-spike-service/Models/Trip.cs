using System;
using System.ComponentModel.DataAnnotations;

namespace odata_spike_service.Models
{
    public class Trip
    {

        public Trip() : this(string.Empty, string.Empty)
        {
            
        }
        public Trip(string id, string name)
        {
            ID = id;
            Name = name;
        }

        [Key]
        public String ID { get; set; }
        [Required]
        public String Name { get; set; }
    }
}