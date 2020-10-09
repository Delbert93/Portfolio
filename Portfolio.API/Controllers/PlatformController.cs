using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;

namespace Portfolio.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IRepository repository;

        public PlatformController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<List<PlatformViewModel>> Get()
        {
            return await repository.Platforms
                .Include(plat => plat.ProjectPlatforms)
                    .ThenInclude(proj => proj.Project)
                .Select(plat => new PlatformViewModel(plat))
                .ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task Delete(Platform platform)
        {
            await repository.DeleteLanguageAsync(platform.Id);
        }
    }
}
