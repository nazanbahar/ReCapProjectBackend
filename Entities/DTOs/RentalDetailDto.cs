using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
///car → Id/BrandId/ColorId-CarName/ModelYear/DailyPrice/Description/IsRented
///customer → Id/UserId/CompanyName
///rental → Id/CarId/CustomerId/RentDate/ReturnDate
/// </summary>
namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; } 
        public int CustomerId { get; set; } 
        public int UserId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        //customer
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        //user
        public string UserName { get; set; }
        //car
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public bool? IsRented { get; set; }

    }
}

