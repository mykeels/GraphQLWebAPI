using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLWebAPI.Extensions
{
    public class Number
    {
        private static int seed = DateTime.Now.Millisecond;
        static Random rand = new Random(DateTime.Now.Millisecond);

        public static double Rnd()
        {
            return rand.NextDouble();
        }
    }
}