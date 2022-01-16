using StudyOnlineRepository.RepositoryInformation;
using StudyOnlineRepository.RepositoryLayer.Classes;
using StudyOnlineRepository.RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnlineRepository.RepositoryLayer.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private IDbConnection connection;
        private IDbTransaction transaction;
        private IStudentRepository studentRepository;
        private bool disposedValue;

        public IStudentRepository StudentRepository
        {
            get
            {
                OpenConnection();
                return studentRepository??(studentRepository= new StudentRepository(connection,transaction));
            }
        }

        private void OpenConnection(string servername = "")
        {
            if(connection== null)
            {
                connection = new SqlConnection(CommonInfo.AppSettings["ConnectionString:SQL"].ToString());
                connection.Open();
            }
        }
        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Dispose();
                resetRepository();
            }
        }

        private void resetRepository()
        {
            studentRepository = null;
        }

        public void InitTransaction()
        {
            OpenConnection();
            transaction = connection.BeginTransaction();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitofWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
