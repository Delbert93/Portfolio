using Microsoft.EntityFrameworkCore;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public class EfCoreReopsitory : IRepository
    {
        private readonly ApplicationDbContext context;
        public EfCoreReopsitory(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentException(nameof(context));
        }
        public IQueryable<Project> Projects => context.Projects;

        public IQueryable<Language> Languages => context.Languages;

        public IQueryable<ProjectLanguage> ProjectLanguages => throw new NotImplementedException();

        public async Task AssignCategoryAsync(AssignRequest assignRequest)
        {
            switch (assignRequest.CategoryType)
            {
                case Project.LanguageCategory:
                    var language = await context.Languages.FirstOrDefaultAsync(la => la.Name == assignRequest.Name);
                    if(language == null)
                    {
                        language = new Language { Name = assignRequest.Name };
                        context.Languages.Add(language);
                        await context.SaveChangesAsync();
                    }
                    var lc = new ProjectLanguage
                    {
                        ProjectId = assignRequest.ProjectId,
                        LanguageId = language.Id
                    };
                    context.ProjectLanguages.Add(lc);
                    await context.SaveChangesAsync();
                    break;
                default:
                    break;
            }
        }

        public async Task DeleteProjectAsync(int id)
        {
            Project project = new Project();
            project.Id = id;
            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public async Task EditProjectAsync(ProjectViewModel project)
        {
            //TODO assign correct information to project
            //context.Projects.Update(project);
            await context.SaveChangesAsync();
        }

        public async Task SaveProjectAsync(Project project)
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }
    }
}
