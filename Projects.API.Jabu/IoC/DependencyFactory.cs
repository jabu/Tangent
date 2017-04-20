using Microsoft.Practices.Unity;
using APIServices.Implementation;
using APIServices.Interfaces;
using APIServices.ServiceIoc;
using API.Services.Implementation;

namespace Projects.API.Jabu.IoC
{
    public class DependencyFactory
    {
        private static IUnityContainer _container;
        private static bool resolved;
        
        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            var container = new UnityContainer();
            _container = container;
        }

        public static void Resolve()
        {
            APIServices.ServiceIoc.DependencyFactory.Resolve(Container);

            _container
                .RegisterType<IUserService, UserService>(new PerResolveLifetimeManager())
                .RegisterType<IProjectInterface, ProjectService>(new PerResolveLifetimeManager());
            resolved = true;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()

        {
            if (!resolved)
            {
                Resolve();
            }

            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }
    }
}