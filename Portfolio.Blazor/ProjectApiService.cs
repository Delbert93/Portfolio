using Portfolio.Shared;
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

        public async Task AddProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("/project", project);
        }

        public async Task DeleteAsync(Project project)
        {
            await client.PostAsJsonAsync("/project/delete", project);
        }

        public async Task<Project> GetProjectById(int Id)
        {
            var projects = await client.GetFromJsonAsync<IEnumerable<Project>>("/project");
            var project = projects.Where(proj => proj.Id == Id).First();
            return project;
        }

        public async Task Edit(Project project)
        {
            await client.PostAsJsonAsync("/project/edit", project);
        }
    }
}
