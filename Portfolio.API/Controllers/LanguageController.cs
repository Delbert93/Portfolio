﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data;
using Portfolio.Shared;
using Portfolio.Shared.ViewModels;

namespace Portfolio.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IRepository repository;

        public LanguageController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public async Task<List<LanguageViewModel>> Get()
        {
            return await repository.Languages
                .Include(lan => lan.ProjectLanguages)
                    .ThenInclude(proj => proj.Project)
                .Select(lan => new LanguageViewModel(lan))
                .ToListAsync();
        }

        [HttpGet("{slug}")]
        public async Task<LanguageViewModel> GetLanguage(string slug)
        {
            try
            {
                var language = await repository.Languages
                    .Include(p => p.ProjectLanguages)
                        .ThenInclude(lan => lan.Project)
                    .FirstOrDefaultAsync(p => p.Slug == slug);
                return new LanguageViewModel(language);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("[action]")]
        public async Task Delete(Language language)
        {
            await repository.DeleteLanguageAsync(language.Id);
        }
    }
}
