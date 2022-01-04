using System;
using System.Collections.Generic;
using System.Text;

namespace Virsta_Roxana_Proiect
{
    class Sneaker
    {
        private SneakerType mBrand;
        public SneakerType Brand
        {
            get
            { return mBrand; }
            set
            { mBrand = value; }
        }


        private float mPrice;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }

        public Sneaker(SneakerType aBrand)
        {
            mBrand = aBrand;
        }
    }
    public enum SneakerType
    {
        Nike,
        Puma,
        Vans,
        Adidas
    }
}


