using StudyOnlineRepository.RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnlineRepository.RepositoryLayer.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        void Commit();
        void Rollback();
        void InitTransaction();

        IStudentRepository StudentRepository { get; }
    }
}
