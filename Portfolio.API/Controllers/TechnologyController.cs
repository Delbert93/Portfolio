using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;

namespace Portfolio.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly IRepository repository;

        public TechnologyController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public async Task<List<TechnologyViewModel>> Get()
        {
            return await repository.Technologies
                .Include(tech => tech.ProjectTechnologies)
                    .ThenInclude(proj => proj.Project)
                .Select(tech => new TechnologyViewModel(tech))
                .ToListAsync();
        }

        [HttpGet("{slug}")]
        public async Task<TechnologyViewModel> GetTechnology(string slug)
        {
            try
            {
                var technology = await repository.Technologies
                    .Include(p => p.ProjectTechnologies)
                        .ThenInclude(lan => lan.Project)
                    .FirstOrDefaultAsync(p => p.Slug == slug);
                return new TechnologyViewModel(technology);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task Delete(Technology technology)
        {
            await repository.DeleteTechnologyAsync(technology.Id);
        }
    }
}
