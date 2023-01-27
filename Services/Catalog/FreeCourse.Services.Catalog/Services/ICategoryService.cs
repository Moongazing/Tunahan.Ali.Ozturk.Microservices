﻿using FreeCourse.Services.Catalog.Dto;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
  public interface ICategoryService
  {
    Task<Response<List<CategoryDto>>> GetAllAsync();
    Task<Response<CategoryDto>> GetByIdAsync(string id);
    Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
  }
}
