using APIServices.Implementation;
using APIServices.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.ServiceIoc
{
    public class DependencyFactory
    {
        public static void Resolve(IUnityContainer _container)
        {
            //_container.RegisterType<IUserService, UserService>(new PerResolveLifetimeManager());
        }
    }
}
