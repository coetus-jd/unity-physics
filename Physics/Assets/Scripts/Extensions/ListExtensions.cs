using System;
using System.Collections.Generic;
using System.Linq;

namespace Physics.Extensions
{
    public static class ListExtensions 
    {
        /// <summary>
        /// Get a random element of a list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T RandomValue<T>(this List<T> list)
        {
            int index = new System.Random(DateTime.Now.Millisecond).Next(0, list.Count);

            return list.ElementAt(index);
        }
    }
}