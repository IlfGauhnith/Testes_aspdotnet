using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.data;
using ProAgil.WebAPI.model;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public DataContext _context { get; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            this._context = context;
            _logger = logger;
        }

        [HttpGet]
        public async  Task<IActionResult> Get()
        {

            try
            {
                var results = await this._context.Eventos.ToListAsync<Evento>();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id)
        {
            try
            {
                var result = await this._context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(result);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }
    }
}
