
namespace CodeChallenge4.ServiceLayer.Code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ObjectMapper
    {
        private static Dictionary<KeyValuePair<Type, Type>, object> maps = new Dictionary<KeyValuePair<Type, Type>, object>();

        /// <summary>
        /// Register a map between two object
        /// </summary>
        /// <typeparam name="TFrom">Type of first object</typeparam>
        /// <typeparam name="TTo">Type of second object</typeparam>
        /// <param name="mapFunc">The custom map action (if any).</param>
        public static void AddMap<TFrom, TTo>(Action<TFrom, TTo> mapFunc = null)
            where TFrom : class
            where TTo : class
        {
            maps.Add(new KeyValuePair<Type, Type>(typeof(TFrom), typeof(TTo)), mapFunc);
        }

        /// <summary>
        /// Removes the map.
        /// </summary>
        /// <typeparam name="TFrom">The type of from.</typeparam>
        /// <typeparam name="TTo">The type of to.</typeparam>
        public static void RemoveMap<TFrom, TTo>()
            where TFrom : class
            where TTo : class
        {
            var map = new KeyValuePair<Type, Type>(typeof(TFrom), typeof(TTo));
            if (maps.ContainsKey(map))
            {
                maps.Remove(map);
            }
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public static void Clear()
        {
            maps = new Dictionary<KeyValuePair<Type, Type>, object>(); ;
        }

        /// <summary>
        /// Get a new object mapped with the value of first object.
        /// </summary>
        /// <typeparam name="TMapFrom">The type of the map from.</typeparam>
        /// <typeparam name="TMapTo">The type of the map to.</typeparam>
        /// <param name="mapFrom">The</param>
        /// <param name="mapTo">The map to.</param>
        /// <exception cref="System.ArgumentNullException">mapFrom</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static void Map<TMapFrom, TMapTo>(TMapFrom mapFrom, TMapTo mapTo)
            where TMapFrom : class
            where TMapTo : class
        {
            if (mapFrom == null) { throw new ArgumentNullException("mapFrom"); }

            var key = new KeyValuePair<Type, Type>(typeof(TMapFrom), typeof(TMapTo));
            var map = (Action<TMapFrom, TMapTo>)maps[key];
            Type tFrom = mapFrom.GetType();
            if (mapTo == null) { mapTo = Activator.CreateInstance<TMapTo>(); }

            Type tTo = mapTo.GetType();
            bool hasMap = maps.Any(m => m.Key.Equals(key));
            if (!hasMap) { throw new ArgumentException(string.Format("No mapping", tFrom.Name, tTo.Name)); }

            MapProperties<TMapFrom, TMapTo>(mapFrom, mapTo, tFrom, tTo);
            MapFields<TMapFrom, TMapTo>(mapFrom, mapTo, tFrom, tTo);

            //If the custom mapping function is not null, call it. This will overwrite previously mapped properties
            if (map != null) { map(mapFrom, mapTo); }
        }

        /// <summary>
        /// Gets the mappings.
        /// </summary>
        internal static Dictionary<KeyValuePair<Type, Type>, object> Mappings { get { return maps; } }

        private static void MapFields<TMapFrom, TMapTo>(TMapFrom mapFrom, TMapTo mapTo, Type tFrom, Type tTo)
            where TMapFrom : class
            where TMapTo : class
        {
            //Map fields on the same name
            var equalFields = from tF in tTo.GetFields()
                              join fF in tFrom.GetFields() on tF.Name equals fF.Name
                              select new
                              {
                                  ToField = tF,
                                  FromField = fF
                              };
            foreach (var field in equalFields)
            {
                //Fields must have the same return type
                if (field.FromField.FieldType.Name != field.ToField.FieldType.Name)
                    continue;

                //Get the value from the mapFrom and set to the mapTo field
                object fieldValue = field.FromField.GetValue(mapFrom);
                field.ToField.SetValue(mapTo, fieldValue);
            }
        }

        private static void MapProperties<TMapFrom, TMapTo>(TMapFrom mapFrom, TMapTo mapTo, Type tFrom, Type tTo)
            where TMapFrom : class
            where TMapTo : class
        {
            //Map properties on the same name
            var equalProps = from tP in tTo.GetProperties()
                             join fP in tFrom.GetProperties() on tP.Name equals fP.Name
                             select new
                             {
                                 ToProperty = tP,
                                 FromProperty = fP
                             };
            //O(n)
            foreach (var prop in equalProps)
            {
                //They have to have the same return type
                if (prop.FromProperty.PropertyType.Name != prop.ToProperty.PropertyType.Name) { continue; }

                //Get the value from the mapFrom. Caveat: Indexing properties not supported!
                object fromValue = prop.FromProperty.GetValue(mapFrom, null);
                prop.ToProperty.SetValue(mapTo, fromValue, null);
            }
        }

    }

}
