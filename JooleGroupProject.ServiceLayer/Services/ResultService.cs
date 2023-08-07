using AutoMapper;
using JooleGroupProject.DAL.Interfaces;
using JooleGroupProject.RepositoryLayer.Repositories;
using JooleGroupProject.RepositoryLayer;
using JooleGroupProject.ServiceLayer.Interfaces;
using JooleGroupProject.ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.DAL.Models;
using Attribute = JooleGroupProject.DAL.Models.Attribute;

namespace JooleGroupProject.ServiceLayer.Services
{
    public class ResultService : IResultService
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public ResultService()
        {
            _context = new MyDBContext();
            _unitOfWork = new UnitOfWork(_context);

            var config = new MapperConfiguration(cfg =>   // AutoMapper Configuration
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<TechSpecFilter, TechSpecFilterDTO>()
       .ForMember(dest => dest.AttributeName, opt => opt.MapFrom(src => src.Attribute.AttributeName));
            });

            _mapper = config.CreateMapper();
        }

        public List<ProductDTO> GetProductsBySubCategory(int subCategoryID)
        {
            var products = _unitOfWork.ProductRepo.GetMany(x => x.SubCategoryID == subCategoryID);
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public List<TechSpecFilterDTO> getTechSpecFiltersForSubCategory(int sub)
        {
            IEnumerable<Attribute> attributeList = _unitOfWork.AttributeRepo.GetAll();
            IEnumerable<TechSpecFilter> specFilterList = _unitOfWork.TechSpecFilterRepo.GetMany(x => x.SubCategoryID == sub);

            var results = (from t1 in attributeList
                           join t2 in specFilterList on t1.AttributeID equals t2.AttributeID
                           select t2);

            List<TechSpecFilterDTO> techSpecFilters = _mapper.Map<List<TechSpecFilterDTO>>(results);
            return techSpecFilters.ToList();
        }
        public List<IndividualSpecDTO> GetIndividualPropertiesBySubCategory(int subid)
        {
            //IEnumerable<Attribute> properties = _unitOfWork.AttributeRepo.GetAttributesByIndividual();
            //var categortyID = _unitOfWork.SubCategoryRepo.GetByID(subid);
            //IEnumerable<ProductAttribute> specs = _unitOfWork.ProductAttributeRepo.GetMany(x => x.subca)
            //var results = (from t1 in properties
            //               join t2 in specs on t1.PropertyID equals t2.PropertyID
            //               select new ProductIndividualSpec
            //               {
            //                   PropertyName = t1.PropertyName,
            //                   iValue = t2.iValue,
            //                   ProductID = t2.ProductID
            //               }).ToList();
            //return results;
            throw new NotImplementedException();
        }
        public IEnumerable<ProductDTO> GetProductsFiltered(int sub, int year1, int year2)
        {
            var products = _unitOfWork.ProductRepo.GetMany(x => x.SubCategoryID == sub && (x.ModelYear >= year1 && x.ModelYear <= year2)).ToList();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public IEnumerable<ProductDTO> GetProductsFilteredBySubCategory(int sub, int year1, int year2)
        {
            throw new NotImplementedException();
        }
    }
}
