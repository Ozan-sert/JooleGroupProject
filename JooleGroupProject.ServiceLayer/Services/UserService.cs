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

namespace JooleGroupProject.ServiceLayer.Services
{
    public class UserService: IUserService
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public UserService()
        {
            _context = new MyDBContext();
            _unitOfWork = new UnitOfWork(_context);

            var config = new MapperConfiguration(cfg =>   // AutoMapper Configuration
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });

            _mapper = config.CreateMapper();
        }


        public UserDTO Login(String UsernameOrEmail, String Password)
        {
            // Email Address
            if (UsernameOrEmail.Contains("@"))
            {
                var user = _unitOfWork.UserRepo.GetUserByEmail(UsernameOrEmail);
                if (user != null && user.Password.Equals(Password))
                {
                    return _mapper.Map<UserDTO>(user); 
                }
            }
            // User Name
            else {
                var user = _unitOfWork.UserRepo.GetUserByName(UsernameOrEmail);
                if (user != null && user.Password.Equals(Password))
                {
                    return _mapper.Map<UserDTO>(user);
                }
            }

            return null; // Authentication failed
        }

        public void RegisterUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _unitOfWork.UserRepo.AddUser(user);
            _unitOfWork.Save();
        }

    }
}
