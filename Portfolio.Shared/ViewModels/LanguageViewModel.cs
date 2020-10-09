using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class LanguageViewModel
    {
        public LanguageViewModel() { }
        public LanguageViewModel(Language language)
        {
            Id = language.Id;
            Name = language.Name;
            Projects = new List<string>(language.ProjectLanguages.Select(proj => proj.Project.Title));
            Slug = language.Slug;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> Projects { get; set; }
        public string Slug { get; set; }
    }
}
