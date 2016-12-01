using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Counter16
    {
        private int value10, max, min;
        private string value16;

        public int Min
        {
            get { return min; }
        }
        public int Max
        {
            get { return max; }
        }
        public int Value10
        {
            get { return value10; }
            set { value10 = value; }
        }
        public string Value16
        {
            get { return Convert.ToString(value10,16); }
        }

        public Counter16()
        {
            this.min = 0;
            this.max = 16;
            this.value10 = 0;
        }

        public Counter16(int min, int max, int value10)
        {
            this.min = min;
            this.max = max;
            if (value10 > max || value10 < min)
                throw (value10 > max) ? new Exception("Число выше чем максимум") : new Exception("Число ниже чем минимум");
            this.value10 = value10;
        }

        public Counter16(int min, int max, string value16)
        {
            this.min = min;
            this.max = max;
            this.value10 = Convert.ToInt32(value16, 16);
            if (value10 > max || value10 < min)
                throw (value10 > max) ? new Exception("Число выше чем максимум") : new Exception("Число ниже чем минимум");
        }

        public void incValue()
        {
            if (value10 + 1 > max)
                throw new Exception("Число выше чем максимум");
            this.value10++;
        }
        public void decValue()
        {
            if (value10 - 1< min)
                throw new Exception("Число ниже чем минимум");
            this.value10--;
        }

    }
}
