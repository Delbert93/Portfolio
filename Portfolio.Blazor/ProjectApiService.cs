using Portfolio.Shared;
using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Portfolio.Blazor
{
    public class ProjectApiService
    {
        private readonly HttpClient client;

        public ProjectApiService(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var response = await client.GetAsync("/project/getprojects");
            return await client.GetFromJsonAsync<IEnumerable<Project>>("/project/getprojects");
        }

        public async Task<IEnumerable<Language>> GetLanguageAsync()
        {
            var language = await client.GetFromJsonAsync<IEnumerable<Language>>("/language");
            return language;
        }

        public async Task<IEnumerable<Platform>> GetPlatformAsync()
        {
            var platform = await client.GetFromJsonAsync<IEnumerable<Platform>>("/platform");
            return platform;
        }

        public async Task<IEnumerable<Technology>> GetTechnologyAsync()
        {
            var technology = await client.GetFromJsonAsync<IEnumerable<Technology>>("/technology");
            return technology;
        }

        public async Task AddProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("/project", project);
        }

        public async Task DeleteProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("/project/delete", project);
        }

        public async Task DeleteLanguageAsync(Language language)
        {
            await client.PostAsJsonAsync("/language/delete", language);
        }

        public async Task DeletePlatformAsync(Platform platform)
        {
            await client.PostAsJsonAsync("/platform/delete", platform);
        }

        public async Task DeleteTechnologyAsync(Technology technology)
        {
            await client.PostAsJsonAsync("/technology/delete", technology);
        }

        public async Task<ProjectViewModel> GetProjectByIdAsync(int id)
        {
            var projects = await client.GetFromJsonAsync<IEnumerable<ProjectViewModel>>("/project");
            var project = projects.Where(proj => proj.Id == id).First();
            return project;
        }

        public async Task<Project> GetProjectByNameAsync(string projectName)
        {
            var projects = await client.GetFromJsonAsync<IEnumerable<Project>>("/project");
            var project = projects.Where(proj => proj.Title == projectName).First();
            return project;
        }

        public async Task<LanguageViewModel> GetLanguageByIdAsync(int id)
        {
            var langauges = await client.GetFromJsonAsync<IEnumerable<LanguageViewModel>>("/language");
            var langauge = langauges.Where(lang => lang.Id == id).First();
            return langauge;
        }

        public async Task<Language> GetLanguageByNameAsync(string languageName)
        {
            var languages = await client.GetFromJsonAsync<IEnumerable<Language>>("/language");
            var language = languages.Where(lang => lang.Name == languageName).First();
            return language;
        }

        public async Task<PlatformViewModel> GetPlatformByIdAsync(int id)
        {
            var platforms = await client.GetFromJsonAsync<IEnumerable<PlatformViewModel>>("/platform");
            var platform = platforms.Where(plat => plat.Id == id).First();
            return platform;
        }

        public async Task<Platform> GetPlatformByNameAsync(string platformName)
        {
            var platforms = await client.GetFromJsonAsync<IEnumerable<Platform>>("/platform");
            var platform = platforms.Where(plat => plat.Name == platformName).First();
            return platform;
        }

        public async Task<TechnologyViewModel> GetTechnologyByIdAsync(int id)
        {
            var technologies = await client.GetFromJsonAsync<IEnumerable<TechnologyViewModel>>("/technology");
            var technology = technologies.Where(tech => tech.Id == id).First();
            return technology;
        }

        public async Task<Technology> GetTechnologyByNameAsync(string technologyName)
        {
            var technologies = await client.GetFromJsonAsync<IEnumerable<Technology>>("/technology");
            var technology = technologies.Where(tech => tech.Name == technologyName).First();
            return technology;
        }

        public async Task AssignLanguage(int projectId, string language)
        {
            var request = new AssignRequest
            {
                CategoryType = Project.LanguageCategory,
                Name = language,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync("/project/AssginCategory", request);
        }

        public async Task AssignPlatform(int projectId, string platform)
        {
            var request = new AssignRequest
            {
                CategoryType = Project.PlatformCategory,
                Name = platform,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync("/project/AssginCategory", request);
        }

        public async Task AssignTechnology(int projectId, string technology)
        {
            var request = new AssignRequest
            {
                CategoryType = Project.TechnologyCategory,
                Name = technology,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync("/project/AssginCategory", request);
        }

        public async Task<ProjectViewModel> GetProjectBySlugAsync(string slug)
        {
            return await client.GetFromJsonAsync<ProjectViewModel>($"/project/{slug}");
        }

        public async Task Edit(ProjectViewModel project)
        {
            await client.PostAsJsonAsync("/project/edit", project);
        }
    }
}
