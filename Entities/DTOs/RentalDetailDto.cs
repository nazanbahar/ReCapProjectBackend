using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
//RentalId, CarName, Description, ModelYear, 
// DailyPrice, FirstName, LastName, Email, CompanyName,  RentDate, ReturnDate 
/// </summary>
namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int RentalId { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}

