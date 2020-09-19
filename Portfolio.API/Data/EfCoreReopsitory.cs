using Portfolio.API.Models;
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
        public IQueryable<Project> Projects => throw new NotImplementedException();

        public async Task SaveProjectAsync(Project project)
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }
    }
}
