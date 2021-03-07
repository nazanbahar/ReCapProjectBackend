using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage
    {
        //Id,CarId,ImagePath,Date
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
