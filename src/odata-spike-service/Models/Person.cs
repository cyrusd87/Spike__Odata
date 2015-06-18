using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace odata_spike_service.Models
{
    public class Person
    {
        public Person() : this(string.Empty,string.Empty,new Trip[0])
        {
            
        }

        public Person(string id, string name, IEnumerable<Trip> trips) 
        {
            ID = id;
            Name = name;
            Trips = new List<Trip>(trips);

        }
         
        [Key]
        public string ID { get;  set; }

        [Required]
        public String Name { get; set; }

        public String Description { get; set; }

        public List<Trip> Trips { get; internal set; }
    }

}