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

        public async Task<Project> GetById(int id)
        {
            var response = await client.GetAsync($"/project/getbyid/?id={id}");
            return await client.GetFromJsonAsync<Project>($"/project/getbyid/?id={id}");
        }

        public async Task Update(Project project)
        {
            await client.PostAsJsonAsync("/project/update", project);
        }
    }
}
