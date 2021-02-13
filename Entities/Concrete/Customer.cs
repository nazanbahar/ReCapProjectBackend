using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Customers-->UserId,CompanyName
/// </summary>
namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
