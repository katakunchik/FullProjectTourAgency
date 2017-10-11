using Autofac;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DataModule : Module
    {
        private readonly string _connString;
        public DataModule(string connString)
        {
            _connString = connString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new EFContext(_connString))
                .As<IEFContext>().InstancePerRequest();
            builder.RegisterType<CountryRepository>()
                .As<ICountryRepository>().InstancePerRequest();
            builder.RegisterType<CityRepository>()
                .As<ICityRepository>().InstancePerRequest();
            builder.RegisterType<LocationService>()
                .As<ILocationService>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
