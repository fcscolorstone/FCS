using System;
using System.Collections.Generic;
using AoteNiu.Core.DependencyManagement;

namespace AoteNiu.Core.Infrastructure
{
    /// <summary>
    /// 点点商城引擎接口 -- 模块的注册与实现
    /// </summary>
    public interface IEngine
    {
        // IOC容器管理类
        ContainerManager ContainerManager { get; }

        // 初始化引擎： 含各个组件及插件
        void Initialize();

        // 根据类名称解析类，并生成实例
        T Resolve<T>(string name = null) where T : class;

        // 根据对象类型和名称来解析对象， 并生成实例
        object Resolve(Type type, string name = null);

        // 解析所有对象；
        T[] ResolveAll<T>();
    }
}
