using System;

namespace Parameters
{
	class Pass
	{
		public static void Value(int param)
		{
		    param = 42;
		}

        public static void Valueref(ref int param)
        {
            param = 62;
        }

        public static void Valueout(out int param)
        {
            param = 52;
        }

        public static void Reference(WrappedInt param)
        {
            param.Number = 42;
        }
	}
}