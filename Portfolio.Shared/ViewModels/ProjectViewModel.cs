using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Languages = new List<string>();
            Platforms = new List<string>();
            Technologies = new List<string>();
        }

        public ProjectViewModel(Project p)
        {
            Id = p.Id;
            Title = p.Title;
            Requirements = p.Requirements;
            Design = p.Design;
            CompletionDate = p.CompletionDate;
            Languages = new List<string>(p.ProjectLanguages.Select(lan => lan.Language.Name));
            Platforms = new List<string>(p.ProjectPlatforms.Select(plat => plat.Platform.Name));
            Technologies = new List<string>(p.ProjectTechnologies.Select(tech => tech.Technology.Name));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }
        public IList<string> Languages { get; set; }
        public IList<string> Platforms { get; set; }
        public IList<string> Technologies { get; set; }
    }
}
