using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EduSync.Speech.Domain.SpeechAggregate;

namespace EduSync.Speech.Domain.Interfaces
{
    public interface ISpeechRepository
    {
        Task CreateAsync(Domain.SpeechAggregate.Speech entity);


    }

   
}
