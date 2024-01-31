using SignalRAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDBContext context ;
        private GenericRepository<Account> _accountRepository;
        private GenericRepository<Categories> _categoryRepository;

        public UnitOfWork(ApplicationDBContext context)
        {
            this.context = context;
        }

        public GenericRepository<Account> AccountRepository
        {
            get
            {

                if (this._accountRepository == null)
                {
                    this._accountRepository = new GenericRepository<Account>(context);
                }
                return _accountRepository;
            }
        }

        public GenericRepository<Categories> CategoryRepository
        {
            get
            {

                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepository<Categories>(context);
                }
                return _categoryRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
