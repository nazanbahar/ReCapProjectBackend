using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarDeleted = "Araba kaydı silindi";
        public static string CarUpdated = "Araba bilgisi güncellendi";

        public static string RentalsListed = "Kiralık arabalar listelendi";
        public static string RentalDeleted = "Kiralık araba silindi";
        public static string RentalUpdated = "Kiralık araba bilgisi güncellendi";
        public static string RentedCar = "Araba kiralanmış";
        public static string RentalCar = "Araba kiralanabilir";
       
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CompanyNameInvalid = "Müşteri ismi geçersiz";
        public static string CustomersListed = "Müşteri listelendi";
        public static string CustomerDeleted = "Müşteri bilgisi silindi";
        public static string CustomerUpdated = "Müşteri bilgisi güncellendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorsListed = "Renk listelendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk bilgisi güncellendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandsListed = "Marka listelendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka bilgisi güncellendi";

        public static string UserAdded = "User eklendi";
        public static string UserNameInvalid = "User name geçersiz";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserDeleted = "User kaydı silindi";
        public static string UserUpdated = "User bilgisi güncellendi";

        //Yetkilendirme Mesajı
        public static string AuthorizationDenied = "Yetkiniz Yoktur...";

        //Register-Login Messages
        public static string UserRegistered = "Kayıt Oluşturuldu...";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";


    }
}
