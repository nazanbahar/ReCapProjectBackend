using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 1) DTO's Definitions-all...
/// CarName, BrandName, ColorName, DailyPrice
/// public List<string> ImagePath { get; set; }
/// public bool? IsRentable { get; set; }
/// public List<string> Images { get; set; }
/// Warning: It will only have setters and getters that means only data and no business logic.
/// What is a Data Transfer Object (DTO)?
/// DTOs can be to encapsulate parameters for method calls. 
/// Getters and Setters
///Business Object  X  View Object
///Veritabanımızda bulunan CRUD (Create, Read, Update, Delete) işlemler için entity kullanacağız.
///Dto veritabanı ile etkileşimin son anına kadar verileri saklama ve proje içerisinde kullanma görevlerini icra edecek.
///DTO'daki propertylerin adları entity(ayrıca VS Code içinde models folder içinde de aynı olmalı) içindeki propertyle ile aynı olmalı, yoksa mapper içerisinde profiller oluştururken özel kurallar yazmamız gerekir.
///İsimler aynı olursa AutoMapper otomatik olarak hangi property nin Dto daki hangi propertye eşit olduğunu anlayacak ve atamaları yapacak.
///“Data transfer object” ler içlerinde business kod bulundurmazlar görevleri sadece verileri taşımak ve geçici olarak saklamaktır. 
///DTO amacı, istemcilerin sunucuya çağrı kaydetmesi için gerekli görülen bilgiler kadar tek bir yanıtta toplanmasıdır.
///
///2) Data Transfer Object (DTO) Definitions... 
///Warning: It will only have setters and getters that means only data and no business logic.
/// What is a Data Transfer Object (DTO)?
///  DTOs can be to encapsulate parameters for method calls. 
///  Getters and Setters
///   Business Object  X  View Object
///  Veritabanında bulunan CRUD (Create, Read, Update, Delete) işlemler için entity mizi kullanacağız.
///  Dto veritabanı ile etkileşimin son anına kadar verileri saklama ve proje içerisinde kullanma görevlerini icra edecek.
/// UYARI: DTO 'daki propertylerin adları entity(ayrıca VS Code içinde models folder içinde de aynı olmalı) içindeki propertyle ile aynı olmalı!
///  “Data transfer object” ler içlerinde business kod bulundurmazlar görevleri sadece verileri taşımak ve geçici olarak saklamaktır. 
///  
/// 3) Encapsülation - Sadece gerekli olanı arayüzde gösterir.
/// DTOs can be to encapsulate parameters for method calls.
/// Car -Brand -Color properties
/// Data Transfer Object (DTO) Definitions - Encapsülation
/// </summary>
namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {

        // Data Transfer Object (DTO) Definitions - Encapsülation
        //DTOs can be to encapsulate parameters for method calls.
        //Car -Brand -Color properties
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        //Image properties
        public List<string> Images { get; set; }
        public bool? IsRented { get; set; }
    }
}
