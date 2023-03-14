using Microsoft.AspNetCore.Mvc;
using OpenShiftDemo_Utilities;

namespace OpenShiftDemo_Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public int Get()
        {
            var val = new Values();
            return val.GetRand(1, 10);
        }
    }
}
