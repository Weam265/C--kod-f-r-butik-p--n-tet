using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInterface
{
     class Goods
    {
        public double pris;
        public int motiv;
        public double snittbetyg;

        public double Snittbetyg
        {
            set { snittbetyg = value; }
            get { return snittbetyg; }
        }
        public int Motiv
        {
            set { motiv = value; }
            get { return motiv; }
        }
        public double Pris
        {
            set { pris = value; }
            get { return pris; }
        }

        public override string ToString()
        {
            return "motiv:" + motiv + " snittbetyg:" + Math.Round(snittbetyg) + " pris:" + Math.Round(pris, 1);
        }
    }
}
