using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public interface IRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<Language> Languages { get; }
        IQueryable<Platform> Platforms { get; }
        IQueryable<Technology> Technologies { get; }

        IQueryable<ProjectLanguage> ProjectLanguages { get; }
        IQueryable<ProjectPlatform> ProjectPlatforms { get; }
        IQueryable<ProjectTechnology> ProjectTechnologies { get; }

        Task SaveProjectAsync(Project project);
        Task SaveLanuguageAsync(Language language);
        Task SavePlatformAsync(Platform platform);
        Task SaveTechnologyAsync(Technology technology);
        Task DeleteProjectAsync(int id);
        Task DeleteLanguageAsync(int id);
        Task DeletePlatformAsync(int id);
        Task DeleteTechnologyAsync(int id);
        Task EditProjectAsync(ProjectViewModel project);
        Task AssignCategoryAsync(AssignRequest assignRequest);
    }
}
