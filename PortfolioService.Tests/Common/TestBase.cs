using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PortfolioService.Api.Extensions.ServiceCollectionExtensions;

namespace PortfolioService.Tests.Common
{
    public abstract class TestBase
    {
        public abstract void Arrange();
        public abstract void Act();

        protected IServiceProvider ServiceProvider { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            try
            {
                SetupDI();
                Arrange();
                Act();
            }
            catch (Exception)
            {

                throw ;
            }
        }

        private void SetupDI()
        {
            ServiceCollection services = new ServiceCollection();
            services.RegisterDependencies();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
