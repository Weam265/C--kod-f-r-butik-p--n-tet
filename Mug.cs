
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StoreInterface
{
    public enum muggsTyp
    {
        stor, medel, liten
    }

     class Muggar:Goods
    {
        static Random x;
        
        private muggsTyp typ;
      

        
        public muggsTyp Typ
        {
            set { typ = value; }
            get { return typ; }
        }

       
       
         public Muggar(int m, muggsTyp t, double s, double p)
         {
            motiv = m;
            typ = t;
            snittbetyg = s;
            base.pris = p;

         }
        public Muggar()
        {
            typ = muggsTyp.medel;
            pris = 100;
            snittbetyg = 10;
        }
        public static Muggar[]  generateMuggar()
        {
            x = new Random();
            Muggar[] muggar = new Muggar[30];
            try
            {
                for (int i = 0; i < 30; i++)
                {
                    muggar[i] = new Muggar(i+1, (muggsTyp)x.Next(0, 2), x.NextDouble() * 10, x.NextDouble() * 100);
                }
                return muggar;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
            
        }

        public static Muggar[] sort(Muggar[] beforeSort)
        {
            Muggar[] sortMugger = new Muggar[beforeSort.Length];

            for (int i = 0; i < beforeSort.Length; i++)
            {
                sortMugger[i] = beforeSort[i];

            }

            for (int i = beforeSort.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (sortMugger[j].Snittbetyg < sortMugger[j + 1].Snittbetyg)
                    {
                        Muggar temp;
                        temp = sortMugger[j];
                        sortMugger[j] = sortMugger[j + 1];
                        sortMugger[j + 1] = temp;

                    }

                }
            }


            return sortMugger;
        }

        public static Muggar[]  sort1(Muggar[] beforeSort)
        {
            Muggar[] afterSort = beforeSort.OrderBy(x => x.snittbetyg).ToArray();

            return afterSort;
        }

        public override string ToString()
        {
            return base.ToString()+" muggsTyp:" + typ;
        }

    }
}
