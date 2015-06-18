using System.Collections.Generic;
using odata_spike_service.Models;

namespace odata_spike_service.DataSource
{
    public class SpikeDataSource
    {
 
        public List<Person> People { get; set; }
        public List<Trip> Trips { get; set; }

        public SpikeDataSource()
        {
            People = new List<Person>();
            Trips = new List<Trip>();
            Trips.Add(new Trip("0","Trip 0"));
            Trips.Add(new Trip("1","Trip 1"));
            Trips.Add(new Trip("2","Trip 2"));
            Trips.Add(new Trip("3","Trip 3"));


            People.Add(new Person("001", "Angel", new[] { Trips[0], Trips[1] }));
            People.Add(new Person("002", "Clyde", new[] { Trips[1], Trips[2] }));
            People.Add(new Person("003", "Elaine", new[] { Trips[2], Trips[3] }));
        }

    }
}