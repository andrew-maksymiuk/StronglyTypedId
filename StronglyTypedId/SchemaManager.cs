using Microsoft.Extensions.DependencyModel;
using System.Collections.Concurrent;
using System.Reflection;

namespace StronglyTypedId
{
    public static class SchemaManager
    {
        private static TypeMappingCatalog _mappings;

        public static TypeMappingCatalog Mappings
        {
            get
            {
                _mappings ??= _GetTypeMappings();
                return _mappings;
            }
        }

        private static TypeMappingCatalog _GetTypeMappings()
        {
            ITypeMapping[] _a = _GetClassesExtending<ITypeMapping>();
            TypeMappingCatalog _result = new(_a);
            return _result;
        }

        private static bool _TryLoad(AssemblyName name, out Assembly assembly)
        {
            try
            {
                assembly = Assembly.Load(name);
                return true;
            }
            catch (Exception)
            {
                assembly = null;
                return false;
            }
        }

        private static ConcurrentDictionary<int, Assembly> _GetAssemblies()
        {
            ConcurrentDictionary<int, Assembly> _d = new();
            string[] _banned = {
                "Microsoft.Extensions.Primitives",
                "Microsoft.Net.Http.Headers"
            };

            Parallel.ForEach(
                DependencyContext.Default.GetDefaultAssemblyNames(),
                _n =>
                {
                    if (!_banned.Contains(_n.Name)
                        && _TryLoad(_n, out Assembly _a))
                        _d.TryAdd(_a.GetHashCode(), _a);
                });
            return _d;
        }

        private static bool _TryLoadTypes(Assembly assembly, out Type[] types)
        {
            try
            {
                types = assembly.GetTypes();
                return true;
            }
            catch (Exception)
            {
                types = null;
                return false;
            }
        }

        private static T[] _GetClassesExtending<T>()
        {
            Type _type = typeof(T);
            ConcurrentBag<Type> _result = new();
            Parallel.ForEach(
                _GetAssemblies()
                    .Values
                    .ToArray(),
                _item =>
            {
                if (_TryLoadTypes(_item, out Type[] _types))
                    foreach (Type _t in _types)
                        if (_type.IsAssignableFrom(_t))
                            _result.Add(_t);
            });
            return _result
                .Where(i => !i.GetTypeInfo().IsAbstract)
                .Select(i => (T)Activator.CreateInstance(i))
                .ToArray();
        }

        public static bool HasMapping(in Type origin, in Type provider)
        {
            return HasMapping(origin, provider, out _);
        }

        public static bool HasMapping(in Type origin, in Type provider, out ITypeMappingInfo mapping)
        {
            return Mappings.TryGetValue(origin, provider, out mapping);
        }
    }
}
