using AutoMapper;
using Entity.Concrete;
using Entity.DTOs.AboutDto;
using Entity.DTOs.BookingDto;
using Entity.DTOs.CategoryDto;
using Entity.DTOs.ContactDto;
using Entity.DTOs.DiscountDto;
using Entity.DTOs.FeatureDetailDto;
using Entity.DTOs.FeatureDto;
using Entity.DTOs.OpeningHourDto;
using Entity.DTOs.OpeningHoursDto;
using Entity.DTOs.OrderDetailDto;
using Entity.DTOs.OrderDto;
using Entity.DTOs.ProductDto;
using Entity.DTOs.RestaurantTableDto;
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

            CreateMap<FeatureDetail, ResultFeatureDetailDto>().ReverseMap();
            CreateMap<FeatureDetail, CreateFeatureDetailDto>().ReverseMap();
            CreateMap<FeatureDetail, UpdateFeatureDetailDto>().ReverseMap();
            CreateMap<FeatureDetail, GetByIdFeatureDetailDto>().ReverseMap();

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

            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, GetByIdOrderDto>().ReverseMap();

            CreateMap<OrderDetail, ResultOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, GetByIdOrderDetailDto>().ReverseMap();

            CreateMap<RestaurantTable, ResultRestaurantTableDto>().ReverseMap();
            CreateMap<RestaurantTable, CreateRestaurantTableDto>().ReverseMap();
            CreateMap<RestaurantTable, UpdateRestaurantTableDto>().ReverseMap();
            CreateMap<RestaurantTable, GetByIdRestaurantTableDto>().ReverseMap();
        }
    }
}
