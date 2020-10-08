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

        public async Task<ProjectViewModel> GetProjectByIdAsync(int id)
        {
            var projects = await client.GetFromJsonAsync<IEnumerable<ProjectViewModel>>("/project");
            var project = projects.Where(proj => proj.Id == id).First();
            return project;
        }

        public async Task<LanguageViewModel> GetLanguageByIdAsync(int id)
        {
            var langauges = await client.GetFromJsonAsync<IEnumerable<LanguageViewModel>>("/langauge");
            var langauge = langauges.Where(lang => lang.Id == id).First();
            return langauge;
        }

        public async Task AssignLanguage(int projectId, string language)
        {
            var request = new AssignRequest
            {
                CategoryType = Project.LanguageCategory,
                Name = language,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync("/project/AssginLangauge", request);
        }

        public async Task Edit(ProjectViewModel project)
        {
            await client.PostAsJsonAsync("/project/edit", project);
        }
    }
}
