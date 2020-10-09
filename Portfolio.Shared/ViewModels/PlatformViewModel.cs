using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class PlatformViewModel
    {
        public PlatformViewModel() { }
        public PlatformViewModel(Platform platform)
        {
            Id = platform.Id;
            Name = platform.Name;
            Projects = new List<string>(platform.ProjectPlatforms.Select(proj => proj.Project.Title));
            Slug = platform.Slug;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> Projects { get; set; }
        public string Slug { get; set; }
    }
}
