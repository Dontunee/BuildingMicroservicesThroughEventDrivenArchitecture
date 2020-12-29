using System;

namespace EduSync.Speech.Domain.SpeechAggregate
{
    public class Speech
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }

        public Speech()
        {

        }
        public Speech(string title, string description, string url, string type)
        {
            Title = title;
            Description = description;
            Url = url;
            Type = type;
        }
    }
}
