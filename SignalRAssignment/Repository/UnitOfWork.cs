
using Repository.ModelsDbF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {
        private SqldataContext context = new SqldataContext();
        private GenericRepository<Account> _accountRepository;
        private GenericRepository<Category> _categoryRepository;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Supplier> _supplierRepository;

        //public UnitOfWork(SqldataContext context)
        //{
        //    this.context = context;
        //}

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
        public GenericRepository<Supplier> SupplierRepository
        {
            get
            {

                if (this._supplierRepository == null)
                {
                    this._supplierRepository = new GenericRepository<Supplier>(context);
                }
                return _supplierRepository;
            }
        }
        public GenericRepository<Product> ProductsRepository
        {
            get
            {

                if (this._productRepository == null)
                {
                    this._productRepository = new GenericRepository<Product>(context);
                }
                return _productRepository;
            }
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new GenericRepository<Category>(context);
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
