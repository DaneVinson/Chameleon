using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Chameleon.WinApp.Host
{
    [RoutePrefix("api/forms")]
    public class FormsController : ApiController
    {
        [HttpGet]
        public bool Handshake()
        {
            return true;
        }

        [HttpGet]
        public bool StartForm(string formType)
        {
            return Program.StartForm(formType);
        }
    }
}
