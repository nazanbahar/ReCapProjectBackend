using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        //IoC Container -- Inversion of Control
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }



        //1) CURUD Operations - 
        //B) HTTP POST Request: api/values... 
        //add
        [ValidationAspect(typeof(CarValidator))]
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        //update
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        //delete
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        //A) HTTP GET Request  api/values...  
        //2) Entities → GetAll | GetById | GetCarsByBrandId | GetCarsByColorId 
        //getall
        [CacheAspect]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependencey chain --
            //Lesson17: Spinn Time Added
            Thread.Sleep(50);
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        //getbyid
        [HttpGet("getbyid")]
        public IActionResult GetById(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }




        //getbybrandid 
        [HttpGet("getallbybrandid")]
        public IActionResult GetAllByBrandId(int brandId)
        {
            var result = _carService.GetAllByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        //getbycolorid 
        [HttpGet("getallbycolorid")]
        public IActionResult GetAllByColorId(int colorId)
        {
            var result = _carService.GetAllByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


  

        //3) DTOs Data Transfer Object → 
        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _carService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }





        //getcardetailbycar
        [HttpGet("getalldetailsbycar")]
        public IActionResult GetAllDetailsByCarId(int carId)
        {
            var result = _carService.GetAllDetailsByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);     
        }





        //getcardetailsbybrand
        //(x) [HttpGet("getallbybrandid")]
        [HttpGet("getalldetailsbybrand")]
        public IActionResult GetAllDetailsByBrandId(int brandId)
        {
            var result = _carService.GetAllDetailsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        //getcardetailsbycolor
        //(x) [HttpGet("getallbycolorid")]
        [HttpGet("getalldetailsbycolor")]
        public IActionResult GetAllDetailsByColorId(int colorId)
        {
            var result = _carService.GetAllDetailsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

 
    }
}
