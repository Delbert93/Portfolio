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
            this.repository = repository;
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

        [HttpGet("{slug}")]
        public async Task<PlatformViewModel> GetPlatform(string slug)
        {
            try
            {
                var platform = await repository.Platforms
                    .Include(p => p.ProjectPlatforms)
                        .ThenInclude(lan => lan.Project)
                    .FirstOrDefaultAsync(p => p.Slug == slug);
                return new PlatformViewModel(platform);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task Delete(Platform platform)
        {
            await repository.DeletePlatformAsync(platform.Id);
        }
    }
}
