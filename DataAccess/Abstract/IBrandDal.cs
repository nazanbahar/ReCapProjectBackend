using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// v1. List<BrandDetailDto> GetAllDetails();
/// v2. List<BrandDetailDto> GetBrandDetails();
/// </summary>
namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
    }
}
