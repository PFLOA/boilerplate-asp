using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coladel.Core.Utils
{
    public static class GenericExtension
    {
        public static int ToInt32(this object obj)
        {
            try
            {
                if (obj == null)
                    return 0;
                return Convert.ToInt32(obj);
            }
            catch
            {
                return 0;
            }
        }

        public static long ToInt64(this object obj)
        {
            try
            {
                if (obj == null)
                    return 0;
                return Convert.ToInt64(obj);
            }
            catch
            {
                return 0;
            }
        }

        public static T ClonarObjeto<T>(this T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
