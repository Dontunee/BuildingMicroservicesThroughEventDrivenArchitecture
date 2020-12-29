using System;
using System.Collections.Generic;
using System.Text;

namespace EduSync.Speech.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
