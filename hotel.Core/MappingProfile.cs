﻿using AutoMapper;
using Restaurant.Core.DTOs;
using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDTO,Employee>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();

        }
    }
}
