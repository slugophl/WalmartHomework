using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalmartHomework.Core.Dtos;
using WalmartHomework.Core.Models;

namespace WalmartHomework
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WalmartOpenApiBaseResponse, ErrorsDto>();
        }
    }
}
