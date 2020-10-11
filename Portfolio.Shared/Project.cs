using Portfolio.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Portfolio.Shared
{
    public class Project
    {
        public Project()
        {

        }

        public Project(ProjectViewModel vm)
        {
            this.Id = vm.Id;
            this.Title = vm.Title;
            this.Requirements = vm.Requirements;
            this.Design = vm.Design;
            this.Slug = vm.Slug;
        }

        public const string LanguageCategory = "language";
        public const string PlatformCategory = "platform";
        public const string TechnologyCategory = "technology";

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("requirements")]
        public string Requirements { get; set; }

        [JsonPropertyName("design")]
        public string Design { get; set; }

        [JsonPropertyName("completiondate")]
        public DateTime CompletionDate { get; set; }

        public List<ProjectLanguage> ProjectLanguages { get; set; }
        public List<ProjectPlatform> ProjectPlatforms { get; set; }
        public List<ProjectTechnology> ProjectTechnologies { get; set; }

        public string Slug { get; set; }
    }
}
