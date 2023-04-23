
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInterface
{

    enum materialType
    {
        wool,cotton,silk
    }
     class Tshirt:Goods
    {
      static   Random x;
       
        private int size;
        private materialType material;
       

        public int Size
        {
            set { size = value; }
            get { return size; }
        }

        public materialType Material
        {
            set { material = value; }
            get { return material; }
        }

      

       


        public Tshirt(int mo,int s,materialType m,double r,double p)
        {
            motiv = mo;
            size = s;
            material = m;
            snittbetyg = r;
            pris = p;

        }

        public Tshirt()
        {
            size = 1;
            material = materialType.cotton;
            pris = 200;
        
        }

        public static Tshirt[]  generateTshirt()
        {
            x = new Random();
            Tshirt[] tshirts = new Tshirt[30];

            for(int i=0;i<30;i++)
            {

                tshirts[i] = new Tshirt(i+1,x.Next(40, 50),(materialType)x.Next(0, 3), x.NextDouble() * 10, x.NextDouble() * 100);

            }
            return tshirts;

        }

        public static Tshirt[]  sort(Tshirt[] beforeSort)
        {
            Tshirt[] sortTshirt=new Tshirt[beforeSort.Length];

            for(int i=0;i<beforeSort.Length;i++)
            {
                sortTshirt[i] = beforeSort[i];

            }

            for(int i=beforeSort.Length-1;i>0;i--)
            {
                for(int j=0;j<i;j++)
                {
                    if (sortTshirt[j].snittbetyg > sortTshirt[j+1].snittbetyg)
                    {
                        Tshirt temp;
                        temp = sortTshirt[j];
                        sortTshirt[j] = sortTshirt[j + 1];
                        sortTshirt[j + 1] = temp;

                    }

                }
            }


            return sortTshirt;
        }

        public static Tshirt[] sort1(Tshirt[] beforeSort)
        {
            Tshirt[] sortTshirt = new Tshirt[beforeSort.Length];

            sortTshirt =  beforeSort.OrderByDescending(obj => obj.snittbetyg).ToArray();
          
            return sortTshirt;
        }
        public override string ToString()
        {
            return base.ToString() + " size:" + size + " material:" + material;
        }



    }
}
