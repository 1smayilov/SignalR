using Core.Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    // Tek Bir Kopya: Statik sınıflar ve üyeler, uygulama boyunca sadece bir kez
    // oluşturulur ve bellekte tek bir kopya olarak tutulur. Bu, belleğin daha verimli kullanılmasını sağlar.

    // Kolay Erişim: Statik sınıflar, doğrudan sınıf adı ile erişilebilirler.Yani, Messages
    // sınıfının üyelerine erişmek için bir nesne oluşturmaya gerek yoktur. 
    public static class Messages   // static olanda new() - lənə bilmir
    {
        public static string ProductAdded = "Məhsullar yükləndi";
        public static string ProductRemoved = "Məhsullar silindi";
        public static string ProductUpdated = "Məhsullar yeniləndi";
        public static string ProductNameInvalid = "Məhsul adı uyğun deyil";
        public static string ProductsListed = "Məhsullar listləndi";
        public static string ProductsWithCategoryListed = "Məhsullar kateqoriya ilə birgə listləndi";
        public static string ProductFetchedById = "Id yə uyğun məhsul gətirildi";
        public static string ProductsFetchedByCategoryId = "Kateqoriyaya uyğun məhsullar gətirildi";
        public static string ProductsFetchedByPriceRange = "Verilən qiymət aralığındakı məhsullar gətirildi";
        public static string ProductCountOfCategoryError = "Kateqoriyada en chox 10 məhsul ola biler";
        public static string ProductNameAlreadyExists = "Bu adda başqa bir məhsul var";

        public static string AboutsListed = "Haqqında hissəsi listləndi";
        public static string AboutRemoved = "Haqqında hissəsi silindi";
        public static string AboutAdded = "Haqqında hissəsi əlavə olundu";
        public static string AboutUpdated = "Haqqında hissəsi yeniləndi";
        public static string AboutFetchedById = "Id yə uyğun haqqında hissəsi gətirildi";

        public static string BookingsListed = "Rezervasiya listləndi";
        public static string BookingRemoved = "Rezervasiya silindi";
        public static string BookingAdded = "Rezervasiya əlavə olundu";
        public static string BookingUpdated = "Rezervasiya yeniləndi";
        public static string BookingFetchedById = "Id yə uyğun rezervasiya gətirildi";

        public static string FeaturesListed = "Nümayiş etdirilənlər listləndi";
        public static string FeatureRemoved = "Nümayiş etdirilən silindi";
        public static string FeatureAdded = "Nümayiş etdirilən əlavə olundu";
        public static string FeatureUpdated = "Nümayiş etdirilən yeniləndi";
        public static string FeatureFetchedById = "Id yə uyğun nümayiş etdirilən gətirildi";

        public static string FeatureDescriptionsListed = "Nümayiş etdirilənin təsvirləri listləndi";
        public static string FeatureDescriptionRemoved = "Nümayiş etdirilənin təsviri silindi";
        public static string FeatureDescriptionAdded = "Nümayiş etdirilənin təsviri əlavə olundu";
        public static string FeatureDescriptionUpdated = "Nümayiş etdirilənin təsviri yeniləndi";
        public static string FeatureDescriptionFetchedById = "Id yə uyğun nümayiş etdirilənin təsviri gətirildi";

        public static string DiscountsListed = "Endirimlər listləndi";
        public static string DiscountRemoved = "Endirim silindi";
        public static string DiscountAdded = "Endirim əlavə olundu";
        public static string DiscountUpdated = "Endirim yeniləndi";
        public static string DiscountFetchedById = "Id yə uyğun endirim gətirildi";

        public static string ContactsListed = "Kontaktlar listləndi";
        public static string ContactRemoved = "Kontakt silindi";
        public static string ContactAdded = "Kontakt əlavə olundu";
        public static string ContactUpdated = "Kontakt yeniləndi";
        public static string ContactFetchedById = "Id yə uyğun kontakt gətirildi";

        public static string TestimonialsListed = "İfadələr listləndi";
        public static string TestimonialRemoved = "İfadə silindi";
        public static string TestimonialAdded = "İfadə əlavə olundu";
        public static string TestimonialUpdated = "İfadə yeniləndi";
        public static string TestimonialFetchedById = "Id yə uyğun ifadə gətirildi";

        public static string SocialMediasListed = "Sosial medialar listləndi";
        public static string SocialMediaRemoved = "Sosial media silindi";
        public static string SocialMediaAdded = "Sosial media əlavə olundu";
        public static string SocialMediaUpdated = "Sosial media yeniləndi";
        public static string SocialMediaFetchedById = "Id yə uyğun sosial media gətirildi";

        public static string OpeningHoursListed = "İş vaxtları listləndi";
        public static string OpeningHourRemoved = "İş vaxtı silindi";
        public static string OpeningHourAdded = "İş vaxtı əlavə olundu";
        public static string OpeningHourUpdated = "İş vaxtı yeniləndi";
        public static string OpeningHourFetchedById = "Id yə uyğun iş vaxtı gətirildi";

        public static string CategoryLimitExceded = "Kategoriya limiti aşıldığı üçün yeni məhsul əlavə edə bilməzsiniz";
        public static string CategoriesListed = "Kateqoriyalar listləndi";
        public static string CategoryFetchedById = "Düzəliş ediləcək kateqoriya gətirildi";
        public static string CategoryRemoved = "Kateqoriya silindi";
        public static string CategoryAdded = "Kateqoriya əlavə olundu";
        public static string CategoryUpdated = "Kateqoriya yeniləndi";

        public static string MaintenanceTime = "Server temirdedir";

        public static string AuthorizationDenied = "Səlahiyyətiniz yoxdur";
        public static string UserRegistered = "Qeydiyyatdan keçdi";
        public static string UserNotFound = "İstifadəçi tapılmadı";
        public static string PasswordError = "Şifrə yanlışdır";
        public static string SuccessfulLogin = "Daxil oldunuz";
        public static string UserAlreadyExists = "Bu istifadəçi mövcuddur";
        public static string AccessTokenCreated = "Token yaradıldı";
    }
}
