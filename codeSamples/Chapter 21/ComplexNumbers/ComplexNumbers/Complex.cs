using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComplexNumbers
{
    class Complex
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public Complex(int real, int imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        /// <summary>
        /// Constructs a Complex numbers from an Integer
        /// </summary>
        /// <param name="real"></param>
        public Complex(int real)
        {
            this.Real = real;
            this.Imaginary = 0;
        }

        /// <summary>
        /// A conversion operator between Integer numbers and Complex number
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static implicit operator Complex(int from)
        {
            return new Complex(from);
        }

        /// <summary>
        /// Converts a complex object and returns the value of the Real property
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static explicit operator int(Complex from)
        {
            return from.Real;
        }

        public override string ToString()
        {
            //return (this.Real.ToString() + " + ", this.Imaginary.ToString() + "i");
            return String.Format("{0} + {1}i", this.Real, this.Imaginary);
        }

        public static Complex operator +(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.Real + rhs.Real, lhs.Imaginary + rhs.Imaginary);
        }

        public static Complex operator -(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.Real - rhs.Real, lhs.Imaginary - rhs.Imaginary);
        }

        public static Complex operator *(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.Real*rhs.Real - lhs.Imaginary*rhs.Imaginary,
                               lhs.Imaginary*rhs.Real + lhs.Real*rhs.Imaginary);
        }

        public static Complex operator /(Complex lhs, Complex rhs)
        {
            int realPart = (lhs.Real*rhs.Real + lhs.Imaginary*rhs.Imaginary)/
                           (rhs.Real*rhs.Real + rhs.Imaginary*rhs.Imaginary);
            int imagPart = (lhs.Imaginary*rhs.Real - lhs.Real*rhs.Imaginary)/
                           (rhs.Real*rhs.Real + rhs.Imaginary*rhs.Imaginary);

            return new Complex(realPart, imagPart);
        }

        public static bool operator ==(Complex lhs, Complex rhs)
        {
            return (lhs.Equals(rhs));
        }

        public static bool operator !=(Complex lhs, Complex rhs)
        {
            return !(lhs.Equals(rhs));
        }

        public override bool Equals(Object obj)
        {
            if (obj is Complex)
            {
                Complex other = (Complex) obj;
                return (this.Real == other.Real) && (this.Imaginary == other.Imaginary);
            }

           return false;         
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
