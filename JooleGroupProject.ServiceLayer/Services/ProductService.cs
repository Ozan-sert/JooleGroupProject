using AutoMapper;
using JooleGroupProject.DAL.Interfaces;
using JooleGroupProject.DAL.Models;
using JooleGroupProject.RepositoryLayer.Repositories;
using JooleGroupProject.RepositoryLayer;
using JooleGroupProject.ServiceLayer.Interfaces;
using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JooleGroupProject.ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public ProductService()
        {
            _context = new MyDBContext();
            _unitOfWork = new UnitOfWork(_context);

            var config = new MapperConfiguration(cfg =>   // AutoMapper Configuration
            {
                cfg.CreateMap<Product, ProductDTO>();
            });

            _mapper = config.CreateMapper();
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _unitOfWork.ProductRepo.GetByID(id);
            if (product == null)
            {
                return null;
            }

            return _mapper.Map<ProductDTO>(product);
        }


        public List<ProductDTO> GetProductsBySubCategory(int subCategoryID)
        {
            var products = _unitOfWork.ProductRepo.GetMany(x => x.SubCategoryID == subCategoryID);
            return _mapper.Map<List<ProductDTO>>(products);
        }
    

        public ProductDTO GetProductByName(string name)
        {
            var product = _unitOfWork.ProductRepo.Get(x => x.ProductName == name);
            return _mapper.Map<ProductDTO>(product);
        }
    }
    
}
