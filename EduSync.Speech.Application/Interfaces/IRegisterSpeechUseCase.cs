using EduSync.Speech.Application.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.Speech.Application.Interfaces
{
    public interface IRegisterSpeechUseCase
    {
        Task Handle(RegisterSpeechCommandMessage command);
    }
}
