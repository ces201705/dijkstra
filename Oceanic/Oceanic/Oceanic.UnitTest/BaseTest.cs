using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;

namespace UnitTests
{
    public abstract class BaseTest
    {
        protected IWindsorContainer Container;

        protected ObjectMother ObjectMother;

        [TestInitialize]
        public void Initialize()
        {
            Container = new WindsorContainer().Install(FromAssembly.This());
            Container.Register(GetComponents().ToArray());
            ObjectMother = new ObjectMother();
        }

        protected virtual IEnumerable<IRegistration> GetComponents()
        {
            return new List<IRegistration>();
        }
    }
}
