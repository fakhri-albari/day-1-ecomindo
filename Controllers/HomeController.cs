using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger.Controllers
{
    /// <summary>
    /// Weather controller responsible for REST API for managing people
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class HomeController : ControllerBase
    {
        private string[] people = new[]
        {
            "Budi", "Udin", "Ucup"
        };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This GET method return sample name
        /// </summary>
        /// <returns>An array of sample name</returns>
        [HttpGet]
        public IEnumerable<People> Get()
        {
            return Enumerable.Range(0, 3).Select(i => new People {
                Name = people[i]
            }).ToArray();
        }

        [HttpPost]
        [Route("")]
        public People CreatePeople([FromBody] People person)
        {
            string[] newPeople = new string[people.Length];
            people.CopyTo(newPeople, 0);
            newPeople[1] = person.Name;
            people = newPeople;
            People newPerson = new People{ Name = person.Name };
            return newPerson;
        }
    }
}
