using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Livraria.Business;
using Livraria.Data.Context;
using Livraria.Data.Repository;
using Livraria.Domain.Interfaces;

namespace Livraria.Ioc
{
    public class WindsorIoc
    {
        private static WindsorContainer Container { get; set; }

        private static readonly object objectLock = new object();

        public static void Iniciar()
        {
            if (Container == null)
            {
                lock (objectLock)
                {
                    if (Container == null)
                    {
                        Container = new WindsorContainer();

                        Container.Register(Component
                            .For<IContextEF>()
                            .ImplementedBy<ContextEFFactory>()
                            .LifeStyle
                            .HybridPerWebRequestPerThread());

                        Container.Register(Component
                            .For(typeof(IRepositorio))
                            .ImplementedBy(typeof(Repositorio))
                            .LifeStyle
                            .HybridPerWebRequestPerThread());

                        Container.Register(
                            Classes.FromAssembly(typeof(BusinessBase<>).Assembly)
                                .BasedOn(typeof(IBusiness<>))
                                .WithServiceAllInterfaces()
                                .LifestyleScoped<HybridPerWebRequestPerThreadScopeAccessor>());
                    }
                }
            }
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static T Resolve<T>(string nome)
        {
            return Container.Resolve<T>(nome);
        }

        /// <summary>
        /// Libera uma instância de um objeto que implementa IDisposable e o ciclo de vida do mesmo seja Transient ou Pooled.
        /// Caso objeto não implemente IDisposable, o Winsdor não rastreia o mesmo e não há necessidade de efetuar o release da instância pois o CG irá realizar.
        /// Veja http://tommarien.github.io/blog/2012/04/21/castle-windsor-avoid-memory-leaks-by-learning-the-underlying-mechanics
        /// </summary>
        /// <param name="instancia">Instância de objeto IDisposable</param>
        public static void Release(object instancia)
        {
            Container.Release(instancia);
        }

        public static void Finalizar()
        {
            if (Container != null)
            {
                Container.Dispose();
                Container = null;
            }
        }

        public void Dispose()
        {
            if (Container != null)
            {
                Container.Dispose();
                Container = null;
            }
        }
    }
}