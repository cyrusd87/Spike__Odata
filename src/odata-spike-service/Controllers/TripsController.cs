using System.Linq;
using System.Web.Http;
using System.Web.OData;
using odata_spike_service.DataSource;

namespace odata_spike_service.Controllers
{
   [EnableQuery]
    public class TripsController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(new SpikeDataSource().Trips.AsQueryable());
        }
    }

    
}