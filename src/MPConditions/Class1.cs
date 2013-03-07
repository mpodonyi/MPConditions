using System;
using System.Collections;
using System.Collections.Generic;
using MPConditions.Numeric;
using MPConditions.Primitives;



namespace MPConditions
{
   
    public static class Run
    {
        public static void Main()
        {
            int uuu = 8;

            uuu.Conditionize("uuu").Between(2, 7).Or.Greater(6).Throw();


            int? uu2 = 8;

            uu2.Conditionize("uuu").Between(2, 7).Or.Greater(6).Throw();

            decimal start = 6;
            decimal end = 12;

            int? uu3 = 8;

            uu3.Conditionize("uuu").Between(start, end).Throw();



        }
    }

}
