using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnetapi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class PersonsController : ControllerBase {

        [HttpGet]
        public void Get () { }

    }
}