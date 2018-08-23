// WebContainerManager.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace WebApi2Book.Web.Common
{
    /// <summary>
    ///     Provides access to dependencies managed by the <see cref="IDependencyResolver" />. Useful where
    ///     access to the resolver is not convenient/possible.
    /// </summary>
    public static class WebContainerManager
    {
        /// <summary>
        ///     Provides access to the dependency resolver.
        /// </summary>
        public static IDependencyResolver GetDependencyResolver()
        {
            var dependencyResolver = GlobalConfiguration.Configuration.DependencyResolver;
            if (dependencyResolver != null)
            {
                return dependencyResolver;
            }

            throw new InvalidOperationException("The dependency resolver has not been set.");
        }

        /// <summary>
        ///     Provides access to a specific type of dependency managed by the <see cref="IDependencyResolver" />. Use only
        ///     where access to the resolver is not convenient/possible.
        /// </summary>
        public static T Get<T>()
        {
            var service = GetDependencyResolver().GetService(typeof (T));

            if (service == null)
                throw new NullReferenceException($"Requested service of type {typeof(T).FullName}, but null was found.");

            return (T) service;
        }

        /// <summary>
        ///     Provides access to a specific type of dependency managed by the <see cref="IDependencyResolver" />. Use only
        ///     where access to the resolver is not convenient/possible.
        /// </summary>
        public static IEnumerable<T> GetAll<T>()
        {
            var services = GetDependencyResolver().GetServices(typeof (T)).ToList();

            if (!services.Any())
                throw new NullReferenceException(
                    $"Requested services of type {typeof(T).FullName}, but none were found.");

            return services.Cast<T>();
        }
    }
}