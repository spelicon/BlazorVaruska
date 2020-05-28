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
    public class VaruskaController : ControllerBase
    {
  
        private readonly ILogger<VaruskaController> logger;
        private readonly ApplicationDbContext context;
        public VaruskaController(ILogger<VaruskaController> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IList<Varuska>> Get()
        {
            return await context.Varuska.ToListAsync();
        }


        [HttpPost]
        public async Task<Varuska> Add(Varuska varuska)
        {
            context.Varuska.Add(varuska);
            await context.SaveChangesAsync();
            return varuska;
        }


        [HttpPut]
        public async Task<Varuska> Update(Varuska varuska)
        {
            context.Entry(varuska).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return varuska;
        }

        [HttpDelete]
        public async Task<Varuska> Delete(int id)
        {
            var toDo = await context.Varuska.FindAsync(id);
            context.Varuska.Remove(toDo);
            await context.SaveChangesAsync();
            return toDo;
        }
    }
}
