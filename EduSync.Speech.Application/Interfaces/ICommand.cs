using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.Speech.Application.Interfaces
{
    public interface ICommand { }

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand message);
    }
}
