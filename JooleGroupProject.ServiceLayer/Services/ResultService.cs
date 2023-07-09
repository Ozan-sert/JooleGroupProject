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
                cfg.CreateMap<ProductAttribute, ProductAttributeDTO>()
                    .ForMember(dest => dest.AttributeName, opt => opt.MapFrom(src => src.Attribute.AttributeName))
                    .ForMember(dest => dest.IsTechSpec, opt => opt.MapFrom(src => src.Attribute.IsTechSpec))
                    .ForMember(dest => dest.IsType, opt => opt.MapFrom(src => src.Attribute.IsType));
                ;

            });


            _mapper = config.CreateMapper();
        }

        public List<ProductDTO> GetProductsBySubCategory(int subCategoryID)
        {
            //var products = _unitOfWork.ProductRepo.GetMany(x => x.SubCategoryID == subCategoryID);
            //return _mapper.Map<List<ProductDTO>>(products);
            var products = _unitOfWork.ProductRepo.GetMany(x => x.SubCategoryID == subCategoryID);

            var productDTOs = _mapper.Map<List<ProductDTO>>(products);

            foreach (var productDTO in productDTOs)
            {
                var productAttributes = _unitOfWork.ProductAttributeRepo.GetMany(x => x.ProductID == productDTO.ProductID);
                productDTO.Attributes = _mapper.Map<List<ProductAttributeDTO>>(productAttributes);
            }

            return productDTOs;
        }

        public List<ProductDTO> GetProductsByProductID(int ProductID)
        {
            //var products = _unitOfWork.ProductRepo.GetMany(x => x.SubCategoryID == subCategoryID);
            //return _mapper.Map<List<ProductDTO>>(products);
            var products = _unitOfWork.ProductRepo.Get(x => x.ProductID == ProductID);

            var productDTOs = _mapper.Map<List<ProductDTO>>(products);

            foreach (var productDTO in productDTOs)
            {
                var productAttributes = _unitOfWork.ProductAttributeRepo.Get(x => x.ProductID == productDTO.ProductID);
                productDTO.Attributes = _mapper.Map<List<ProductAttributeDTO>>(productAttributes);
            }

            return productDTOs;
        }

        public List<TechSpecFilterDTO> GetTechSpecFilterNamesForSubCategory(int sub)
        {
            IEnumerable<Attribute> attributeList = _unitOfWork.AttributeRepo.GetAttributesByTechSpec();
            IEnumerable<TechSpecFilter> specFilterList = _unitOfWork.TechSpecFilterRepo.GetMany(x => x.SubCategoryID == sub);

            var results = (from t1 in attributeList
                           join t2 in specFilterList on t1.AttributeID equals t2.AttributeID
                           select t2);

            List<TechSpecFilterDTO> techSpecFilters = _mapper.Map<List<TechSpecFilterDTO>>(results);
            return techSpecFilters.ToList();
        }
        public IEnumerable<ProductDTO> GetProductsFiltered(int sub, int year1, int year2)
        {
            var products = _unitOfWork.ProductRepo.GetMany(x => x.SubCategoryID == sub && (x.ModelYear >= year1 && x.ModelYear <= year2));
            // return _mapper.Map<IEnumerable<ProductDTO>>(products);
            var productDTOs = _mapper.Map<List<ProductDTO>>(products);

            foreach (var productDTO in productDTOs)
            {
                var productAttributes = _unitOfWork.ProductAttributeRepo.GetMany(x => x.ProductID == productDTO.ProductID);
                productDTO.Attributes = _mapper.Map<List<ProductAttributeDTO>>(productAttributes);
            }

            return productDTOs;
        }
        public List<ProductAttributeDTO> GetIndividualProperties(int subid)
        {
        
            IEnumerable<Attribute> attributeList = _unitOfWork.AttributeRepo.GetAttributesByTechSpec();
            IEnumerable<ProductAttribute> productAttributeList = _unitOfWork.ProductAttributeRepo.GetMany(x => x.Product.SubCategoryID == subid);

            var results = (from attr in attributeList
                           join prodAttr in productAttributeList on attr.AttributeID equals prodAttr.AttributeID
                           select prodAttr);

            List<ProductAttributeDTO> productAttributes = _mapper.Map<List<ProductAttributeDTO>>(results);
            return productAttributes.ToList();
        }

        public int GetSubCategoryID(string subCategoryName)
        {
            int subCategoryID = _unitOfWork.SubCategoryRepo.Get(x => x.SubCategoryName == subCategoryName).SubCategoryID;
            return subCategoryID;
        }
        //public List<ProductAttributeDTO> GetIndividualProperties(int subid, int productID)
        //{
        //    IEnumerable<Attribute> attributeList = _unitOfWork.AttributeRepo.GetAttributesByTechSpec();
        //    IEnumerable<ProductAttribute> productAttributeList = _unitOfWork.ProductAttributeRepo.GetMany(x => x.ProductID == productID);

        //    var results = (from attr in attributeList
        //                   join prodAttr in productAttributeList on attr.AttributeID equals prodAttr.AttributeID
        //                   select prodAttr);

        //    List<ProductAttributeDTO> productAttributes = _mapper.Map<List<ProductAttributeDTO>>(results);
        //    return productAttributes.ToList();
        //}
        //public List<ProductDTO> GetProductsWithIndividualProperties(int subid)
        //{
        //    var products = _unitOfWork.ProductRepo.GetProductsBySubCategory(subid);
        //    var productDTOs = _mapper.Map<List<ProductDTO>>(products);

        //    foreach (var productDTO in productDTOs)
        //    {
        //        var productAttributes = GetIndividualProperties(subid, productDTO.ProductID);
        //        productDTO.Attributes = productAttributes;
        //    }

        //    return productDTOs;
        //}
    }
}
