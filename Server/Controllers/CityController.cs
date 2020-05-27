using BlazorVaruska.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazorVaruska.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorVaruska.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
  
        private readonly ILogger<CityController> logger;
        private readonly ApplicationDbContext context;
        public CityController(ILogger<CityController> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IList<City>> Get()
        {
            return await context.City.ToListAsync();
        }
    }
}
