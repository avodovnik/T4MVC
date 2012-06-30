// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

namespace System.Web.Mvc {
    #region ModelUnbinders
    [GeneratedCode("T4MVC", "2.0")]
    public interface IModelUnbinder {
        void UnbindModel(RouteValueDictionary routeValueDictionary, string routeName, object routeValue);
    }
    [GeneratedCode("T4MVC", "2.0")]
    public interface IModelUnbinder<in T> where T : class {
        void UnbindModel(RouteValueDictionary routeValueDictionary, string routeName, T routeValue);
    }
    [GeneratedCode("T4MVC", "2.0")]
    public class ModelUnbinders {
        private class GenericModelUnbinderWrapper<T> : IModelUnbinder where T : class {
            private readonly IModelUnbinder<T> _unbinder;

            public GenericModelUnbinderWrapper(IModelUnbinder<T> unbinder) {
                _unbinder = unbinder;
            }

            public void UnbindModel(RouteValueDictionary routeValueDictionary, string routeName, object routeValue) {
                var typedObject = routeValue as T;
                _unbinder.UnbindModel(routeValueDictionary, routeName, typedObject);
            }
        }
        
        private readonly Dictionary<Type, IModelUnbinder> _unbinders = new Dictionary<Type, IModelUnbinder>();
        private readonly Dictionary<Type, IModelUnbinder> _baseClassUnbinders = new Dictionary<Type, IModelUnbinder>();
        public virtual void Add(Type type, IModelUnbinder unbinder, bool isBaseClass = false) {
            if (isBaseClass)
                _baseClassUnbinders[type] = unbinder;
            else
                _unbinders[type] = unbinder;
        }
        public virtual void Add<T>(IModelUnbinder<T> unbinder, bool isBaseClass = false) where T : class {
            Add(typeof(T), new GenericModelUnbinderWrapper<T>(unbinder), isBaseClass);
        }
        public virtual IModelUnbinder FindUnbinderFor(Type type) {
            IModelUnbinder unbinder;
            if (_unbinders.TryGetValue(type, out unbinder))
                return unbinder;

            Type baseType = null;
            foreach (var baseClassUnbinder in _baseClassUnbinders) {
                if (baseClassUnbinder.Key.IsAssignableFrom(type)) {
                    if ((baseType == null) || baseType.IsAssignableFrom(baseClassUnbinder.Key)) {
                        unbinder = baseClassUnbinder.Value;
                        baseType = baseClassUnbinder.Key;
                    }
                }
            }
            return unbinder;
        }
        
        public virtual void Clear() {
            _unbinders.Clear();
            _baseClassUnbinders.Clear();
        }
    }
    [GeneratedCode("T4MVC", "2.0")]
    public class DefaultModelUnbinder : IModelUnbinder {
        public void UnbindModel(RouteValueDictionary routeValueDictionary, string routeName, object routeValue) {
            routeValueDictionary.Add(routeName, routeValue);
        }
    }
    [GeneratedCode("T4MVC", "2.0")]
    public class PropertiesUnbinder : IModelUnbinder {
        public virtual void UnbindModel(RouteValueDictionary routeValueDictionary, string routeName, object routeValue) {
            var dict = new RouteValueDictionary(routeValue);
            foreach (var entry in dict) {
                var name = entry.Key;

                if (!(entry.Value is string) && (entry.Value is System.Collections.IEnumerable)) {
                    var enumerableValue = entry.Value as System.Collections.IEnumerable;
                    var i = 0;
                    foreach (var enumerableElement in enumerableValue) {
                        ModelUnbinderHelpers.AddRouteValues(routeValueDictionary, string.Format("{0}.{1}[{2}]", routeName, name, i), enumerableElement);
                        i++;
                    }
                }
                else {
                    ModelUnbinderHelpers.AddRouteValues(routeValueDictionary, routeName + "." + name, entry.Value);
                }
            }
        }
    }
    public class ModelUnbinderHelpers {
        public static void AddRouteValues(RouteValueDictionary routeValueDictionary, string routeName, object routeValue) {
            if (routeValue == null)
                return;

            var unbinder = ModelUnbinders.FindUnbinderFor(routeValue.GetType()) ?? DefaultModelUnbinder;
            unbinder.UnbindModel(routeValueDictionary, routeName, routeValue);
        }
        
        private static readonly ModelUnbinders _modelUnbinders = new ModelUnbinders();
        public static ModelUnbinders ModelUnbinders {
            get { return _modelUnbinders; }
        }

        public static IModelUnbinder DefaultModelUnbinder { get; set; }
        static ModelUnbinderHelpers() {
            DefaultModelUnbinder = new DefaultModelUnbinder();
        }
    }
}
    #endregion
#endregion T4MVC

