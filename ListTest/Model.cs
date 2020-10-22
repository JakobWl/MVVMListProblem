using System;
using System.Collections.Generic;
using System.Text;

namespace ListTest
{
    public class Model
    {
        private List<Test> myVar;

        public Model()
        {
            this.Properties = new List<Test>() { new Test(1), new Test(2) };
        }

        public List<Test> Properties
        {
            get
            {
                return this.myVar;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.myVar = value;
            }
        }

    }

    public class Test
    {
        private int myVar;

        public Test(int myvar)
        {
            this.Property = myvar;
        }

        public int Property
        {
            get
            {
                return this.myVar;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.myVar = value;
            }
        }

    }
}
