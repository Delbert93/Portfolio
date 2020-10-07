﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Shared;
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

        public IQueryable<Language> Languages => throw new NotImplementedException();

        public IQueryable<ProjectLanguage> ProjectLanguages => throw new NotImplementedException();

        public async Task AssignCategoryAsync(AssignRequest assignRequest)
        {
            switch (assignRequest.CategoryType)
            {
                case Project.LanguageCategory:
                    var language = await context.Languages.FirstOrDefaultAsync(la => la.Name == assignRequest.Name);

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

        public async Task EditProjectAsync(Project project)
        {
            context.Projects.Update(project);
            await context.SaveChangesAsync();
        }

        public async Task SaveProjectAsync(Project project)
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }
    }
}