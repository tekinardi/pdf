using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pdf
{
    public class sinif
    {

            public string tamadres { get; set; }
            public string belgeadi { get; set; }
            public int sayfano { get; set; }
            public int sirano { get; set; }

            public override string ToString()
            {
                return belgeadi + " - " + sayfano.ToString() + ". Sayfa";
            }

        

    }
}
