using AutoMapper;
using JooleGroupProject.DAL.Interfaces;
using JooleGroupProject.DAL.Models;
using JooleGroupProject.RepositoryLayer;
using JooleGroupProject.RepositoryLayer.Repositories;
using JooleGroupProject.ServiceLayer.Interfaces;
using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.ServiceLayer.Services
{
    public class SearchService : ISearchService
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;
        public SearchService()
        {
            _context = new MyDBContext();
            _unitOfWork = new UnitOfWork(_context);

            var config = new MapperConfiguration(cfg =>   // AutoMapper Configuration
            {
                cfg.CreateMap<SubCategory, SubCategoryDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<Product, ProductDTO>();
            });

            _mapper = config.CreateMapper();
        }
        public List<CategoryDTO> GetCategories()
        {
            var categories = _unitOfWork.CategoryRepo.GetAll().ToList();
                return _mapper.Map<List<CategoryDTO>>(categories);
        }


        public List<SubCategoryDTO> GetSubsforCategory(int id)
        {
            var subCategories = _unitOfWork.SubCategoryRepo.GetMany(x => x.CategoryID == id);
           return _mapper.Map<List<SubCategoryDTO>>(subCategories);
        }

        public string GetCategoryNameByID(int id) {
            var category = _unitOfWork.CategoryRepo.GetByID(id);
            return category.CategoryName; 
        }

        public SubCategoryDTO GetSubCategoryByName(string name) { 
            SubCategory subcategory = _unitOfWork.SubCategoryRepo.GetSubCategoryByName(name);
            return  _mapper.Map <SubCategoryDTO> (subcategory);
        }
    }
}
