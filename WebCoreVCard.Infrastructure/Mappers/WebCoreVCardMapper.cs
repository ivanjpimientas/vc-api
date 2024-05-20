using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCoreVCard.Domain.Dtos;
using WebCoreVCard.Domain.Entities;

namespace WebCoreVCard.Infrastructure.Mappers
{
    public class WebCoreVCardMapper: Profile
    {
        public WebCoreVCardMapper() 
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
