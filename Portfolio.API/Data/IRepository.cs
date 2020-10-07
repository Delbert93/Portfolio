﻿using Portfolio.Shared;
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

        IQueryable<ProjectLanguage> ProjectLanguages { get; }

        Task SaveProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
        Task EditProjectAsync(Project project);
        Task AssignCategoryAsync(AssignRequest assignRequest);
    }
}