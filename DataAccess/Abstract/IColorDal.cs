using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
///v1. List<ColorDetailDto> GetAllDetails();
///v2. List<ColorDetailDto> GetColorDetails();
/// </summary>
namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
    }
}
