using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AoteNiu.Core.DependencyManagement
{
    public class ContainerManager
    {
        private IContainer _container;

        public ContainerManager()
        {

        }

        public ContainerManager(IContainer container)
        {
            _container = container;
        }

        public IContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }

        /// <summary>
        /// 解析指定生命期内的对象 -- 根据对象解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public T Resolve<T>(object key = null, ILifetimeScope scope = null) where T : class
        {
            if (key == null)
            {
                return (scope ?? Scope()).Resolve<T>();
            }
            return (scope ?? Scope()).ResolveKeyed<T>(key);
        }

        /// <summary>
        /// 解析指定生命期内的对象 -- 根据名称解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public T ResolveNamed<T>(string name, ILifetimeScope scope = null) where T : class
        {
            return (scope ?? Scope()).ResolveNamed<T>(name);
        }

        /// <summary>
        /// 解析指定生命期内的对象 -- 根据类型解析
        /// </summary>
        /// <param name="type"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public object Resolve(Type type, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).Resolve(type);
        }

        /// <summary>
        /// 解析指定生命期内的对象 -- 根据类型和名称类型解析
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public object ResolveNamed(Type type, string name, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).ResolveNamed(name, type);
        }

        /// <summary>
        /// 获取指定类型的服务, 若该服务未注册，则允许返回null.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public object ResolveOptional(Type serviceType, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).ResolveOptional(serviceType);
        }

        /// <summary>
        /// 解析指定生命期内的所有相关对象 -- 根据对象关键词解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public T[] ResolveAll<T>(object key = null, ILifetimeScope scope = null)
        {
            if (null == key)
            {
                return (scope ?? Scope()).Resolve<IEnumerable<T>>().ToArray();
            }
            else
            {
                return (scope ?? Scope()).ResolveKeyed<IEnumerable<T>>(key).ToArray();
            }
        }

        /// <summary>
        /// 尝试解析类指定生命范围内的所有指定类型对象
        /// </summary>
        /// <param name="types"></param>
        /// <param name="instances"></param>
        /// <param name="scope"></param>
        /// <returns>若失败则返回false, 没有任何对象会解析; 若成功，则instances包含所有解析后的对象. </returns>
        private bool TryResolveAll(Type[] types, out object[] instances, ILifetimeScope scope = null)
        {
            instances = null;

            try
            {
                var instances2 = new object[types.Length];

                for (int i = 0; i < types.Length; i++)
                {
                    var service = Resolve(types[i], scope);
                    if (service == null)
                    {
                        return false;
                    }

                    instances2[i] = service;
                }

                instances = instances2;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 尝试解析类指定生命范围内的指定类型对象
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="scope"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool TryResolve(Type serviceType, ILifetimeScope scope, out object instance)
        {
            return (scope ?? Scope()).TryResolve(serviceType, out instance);
        }

        /// <summary>
        /// 尝试解析类指定生命范围内的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool TryResolve<T>(ILifetimeScope scope, out T instance)
        {
            return (scope ?? Scope()).TryResolve<T>(out instance);
        }

        /// <summary>
        /// 检测指定类型是否已经注册
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public bool IsRegistered(Type serviceType, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).IsRegistered(serviceType);
        }

        /// <summary>
        /// Set any properties on instance that can be resolved in the context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public T InjectProperties<T>(T instance, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).InjectProperties(instance);
        }

        /// <summary>
        /// Set any null-valued properties on instance that can be resolved by the container.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public T InjectUnsetProperties<T>(T instance, ILifetimeScope scope = null)
        {
            return (scope ?? Scope()).InjectUnsetProperties(instance);
        }

        /// <summary>
        /// 获取生命期内对应的容器
        /// </summary>
        /// <returns></returns>
        public ILifetimeScope Scope()
        {
            var scope = _container.Resolve<ILifetimeScopeAccessor>().GetLifetimeScope(null);
            return scope ?? _container;
        }

        /// <summary>
        /// 获取生命期范围访问类 -- AsyncRunner
        /// </summary>
        public ILifetimeScopeAccessor ScopeAccessor
        {
            get
            {
                return _container.Resolve<ILifetimeScopeAccessor>();
            }
        }
    }
}
