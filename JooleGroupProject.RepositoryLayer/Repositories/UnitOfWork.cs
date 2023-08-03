using JooleGroupProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.RepositoryLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDBContext _dbContext;

        public UnitOfWork(MyDBContext dbContext) 
        {
            _dbContext = dbContext;

            UserRepo = new UserRepo(_dbContext);
            TechSpecFilterRepo = new TechSpecFilterRepo(_dbContext);
            AttributeRepo = new AttributeRepo(_dbContext);
            CategoryRepo = new CategoryRepo(_dbContext);
            SubCategoryRepo = new SubCategoryRepo(_dbContext);
            ProductRepo = new ProductRepo(_dbContext);
            ProductAttributeRepo = new ProductAttributeRepo(_dbContext);
        }

        public IUserRepo UserRepo { get; }
        public ITechSpecFilterRepo TechSpecFilterRepo { get; }
        public IAttributeRepo AttributeRepo { get;  }
        public ICategoryRepo CategoryRepo { get;  }
        public ISubCategoryRepo SubCategoryRepo { get; }
        public IProductRepo ProductRepo { get; }
        public IProductAttributeRepo ProductAttributeRepo { get; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}

