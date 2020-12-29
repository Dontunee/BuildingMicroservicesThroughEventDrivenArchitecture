using EduSync.Speech.Application.Interfaces;
using EduSync.Speech.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.Speech.Application.Service
{
    public class RegisterSpeechUseCase : IRegisterSpeechUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISpeechRepository _speechRepository;

        public RegisterSpeechUseCase(IUnitOfWork unitOfWork, ISpeechRepository speechRepository)
        {
            _unitOfWork = unitOfWork;
            _speechRepository = speechRepository;
        }

        public async Task Handle([NotNull] RegisterSpeechCommandMessage command)
        {
            var title = command.Title;
            var urlValue = command.Url;
            var description = command.Description;
            var type = command.Type;
            var speech = new Domain.SpeechAggregate.Speech(title, urlValue, description, type);
            await _speechRepository.CreateAsync(speech);
            _unitOfWork.Commit();

        }
    }
}
