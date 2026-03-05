using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MichangerAPIControl.Automation.Flows
{
    /// <summary>
    /// Auto-discovers all classes that implement <see cref="IFlow"/> in the current assembly.
    /// No manual registration required — just create a class that implements IFlow and
    /// it will appear automatically.
    ///
    /// Tu dong tim tat ca cac class implement IFlow trong assembly.
    /// Khong can dang ky thu cong — chi can tao class implement IFlow la no se tu xuat hien.
    /// </summary>
    public static class FlowRegistry
    {
        private static List<IFlow> _flows;

        /// <summary>
        /// Returns all discovered IFlow instances, sorted by name.
        /// Each call after the first uses the cache.
        /// </summary>
        public static IReadOnlyList<IFlow> GetAll()
        {
            if (_flows != null) return _flows;

            _flows = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IFlow).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t =>
                {
                    try { return (IFlow)Activator.CreateInstance(t); }
                    catch { return null; }
                })
                .Where(f => f != null)
                .OrderBy(f => f.Name)
                .ToList();

            return _flows;
        }

        /// <summary>
        /// Clears the discovery cache. Call this if you add new flows at runtime.
        /// Xoa cache. Goi ham nay neu ban them flow moi luc runtime.
        /// </summary>
        public static void Invalidate() => _flows = null;
    }
}
