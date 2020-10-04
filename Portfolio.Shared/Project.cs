using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Portfolio.Shared
{
    public class Project
    {
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
    }
}
