﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi)
/// </summary>
namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Rental()
        {
            RentDate = DateTime.Now;
        }
    }

    
}

