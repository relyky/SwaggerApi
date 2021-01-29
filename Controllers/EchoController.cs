using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwaggerApi.Controllers
{
    public class EchoController : ApiController
    {
        #region resource
        private static readonly string[] Summaries = new[]  
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        #endregion

        #region Data Transfer Object
        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string Summary { get; set; }
        }
        #endregion

        /// <summary>
        /// GET: api/Echo
        /// </summary>
        [HttpGet]
        public IHttpActionResult Knock()
        {
            return Ok($"I am alive at {DateTime.Now.ToString("yyyy\\/MM\\/dd HH:mm:ss")}.");
        }

        /// <summary>
        /// GET: api/Echo/Weather
        /// </summary>
        [HttpPost]
        public IEnumerable<WeatherForecast> Weather()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
