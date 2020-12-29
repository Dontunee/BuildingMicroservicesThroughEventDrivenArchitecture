using EduSync.Speech.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSync.Speech.Application.Service
{
    public class RegisterSpeechCommandMessage : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }

        public RegisterSpeechCommandMessage(string title, string description, string url, string type)
        {
            Title = title;
            Description = description;
            Url = url;
            Type = type;
        }
    }
}
