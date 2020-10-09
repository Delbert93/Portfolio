using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Shared.ViewModels;
    
namespace Portfolio.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<List<ProjectViewModel>> Get() 
        {
            return await repository.Projects
                .Include(p => p.ProjectLanguages)
                    .ThenInclude(lan => lan.Language)
                .Include(p => p.ProjectPlatforms)
                    .ThenInclude(plat => plat.Platform)
                .Include(p => p.ProjectTechnologies)
                    .ThenInclude(tech => tech.Technology)
                .Select(p => new ProjectViewModel(p))
                .ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task AssginCategory(AssignRequest assignRequest)
        {
            await repository.AssignCategoryAsync(assignRequest);
        }
            

        //Temp data for now.
        //TODO remove later 
        [HttpGet("[action]")]
        public async Task DefaultData()
        {
            await repository.SaveProjectAsync(new Project
            {
                Title = "Project 1",
                Requirements = "You got this",
                Design = "Its amazing",
                //CompletionDate = new DateTime(2020, 23, 9)
            });
        }

        [HttpPost("[action]")]
        public async Task Delete(Project project)
        {
            await repository.DeleteProjectAsync(project.Id);
        }

        [HttpPost("[action]")]
        public async Task Edit(ProjectViewModel project)
        {
            await repository.EditProjectAsync(project);
        }

        [HttpPost()]
        public async Task Post(Project project)
        {
            await repository.SaveProjectAsync(project);
        }
    }
}
