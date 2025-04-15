using Autofac;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mapping.AutoMapper;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>();

            builder.RegisterType<BookingManager>().As<IBookingService>();
            builder.RegisterType<EfBookingDal>().As<IBookingDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<EfContactDal>().As<IContactDal>();

            builder.RegisterType<DiscountManager>().As<IDiscountService>();
            builder.RegisterType<EfDiscountDal>().As<IDiscountDal>();

            builder.RegisterType<FeatureManager>().As<IFeatureService>();
            builder.RegisterType<EfFeatureDal>().As<IFeatureDal>();

            builder.RegisterType<FeatureDetailManager>().As<IFeatureDetailService>();
            builder.RegisterType<EfFeatureDetailDal>().As<IFeatureDetailDal>();

            builder.RegisterType<OpeningHourManager>().As<IOpeningHourService>();
            builder.RegisterType<EfOpeningHourDal>().As<IOpeningHoursDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>();
            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>();

            builder.RegisterType<TestimonialManager>().As<ITestimonialService>();
            builder.RegisterType<EfTestimonialDal>().As<ITestimonialDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>();

            builder.RegisterType<OrderPriceUpdaterManager>().As<IOrderPriceUpdaterService>();

            builder.RegisterType<RestaurantTableManager>().As<IRestaurantTableService>();
            builder.RegisterType<EfRestaurantTableDal>().As<IRestaurantTableDal>();


            builder.Register(c =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });

                return config.CreateMapper();
            }).As<IMapper>().SingleInstance();

            
        }
    }
}
