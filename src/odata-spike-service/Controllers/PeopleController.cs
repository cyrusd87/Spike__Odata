using System.Linq;
using System.Web.Http;
using System.Web.OData;
using odata_spike_service.DataSource;

namespace odata_spike_service.Controllers
{
    [EnableQuery]
    public class PeopleController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(new SpikeDataSource().People.AsQueryable());
        }
    }
}