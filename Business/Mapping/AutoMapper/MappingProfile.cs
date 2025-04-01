using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.AboutDto;
using Entity.DTOs.BookingDto;
using Entity.DTOs.CategoryDto;
using Entity.DTOs.ContactDto;
using Entity.DTOs.DiscountDto;
using Entity.DTOs.FeatureDescriptionDto;
using Entity.DTOs.FeatureDto;
using Entity.DTOs.OpeningHourDto;
using Entity.DTOs.OpeningHoursDto;
using Entity.DTOs.ProductDto;
using Entity.DTOs.SocialMediaDto;
using Entity.DTOs.TestimonialDto;

namespace Business.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();

            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, GetByIdBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();

            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();

            CreateMap<FeatureDescription, ResultFeatureDescriptionDto>().ReverseMap();
            CreateMap<FeatureDescription, CreateFeatureDescriptionDto>().ReverseMap();
            CreateMap<FeatureDescription, UpdateFeatureDescriptionDto>().ReverseMap();
            CreateMap<FeatureDescription, GetByIdFeatureDescriptionDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<OpeningHours, ResultOpeningHourDto>().ReverseMap();
            CreateMap<OpeningHours, CreateOpeningHourDto>().ReverseMap();
            CreateMap<OpeningHours, UpdateOpeningHourDto>().ReverseMap();
            CreateMap<OpeningHours, GetByIdOpeningHourDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialDto>().ReverseMap();
        }
    }
}
