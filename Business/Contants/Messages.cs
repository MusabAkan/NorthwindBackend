﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants
{
    public static class Messages
    {
       
        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";

        public static string CategoryAdded = "Kategori başarıyla eklendi";
        public static string CategoryDeleted = "Kategori başarıyla silindi";
        public static string CategoryUpdated = "Kategori başarıyla güncellendi";

        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccesFullLogin = "Sisteme Başarılı giriş";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz Yok";

        public static string ProductNameAlreadyExists = "Ürün İsmi Zaten Mevcut !!";
    }
}
