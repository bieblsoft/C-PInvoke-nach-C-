using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace DLLInterop
{
	class Program
	{
		[StructLayout(LayoutKind.Sequential, Pack=8)]
		public struct MLocation  
		{
		   public int x;
		   public int y;
		};

		public struct TraditionalDLL 
		{
		   [DllImport("Structlayout.dll")]
		   static public extern double GetDistance(MLocation a, MLocation b);
           
           [DllImport("Structlayout.dll")]
		   unsafe static extern public double InitLocation(MLocation* a);
		};

		static void Main ( string[ ] args )
		{
			// Datenaustauch mittels Strukturen
			// Hier ist besonders auf die übereinstimmende Anordnung der Strukturmember
			// zu achten
			MLocation loc1;
			loc1.x = 0;
			loc1.y = 0;

			MLocation loc2;
			loc2.x = 100;
			loc2.y = 100;

			double dist = TraditionalDLL.GetDistance(loc1, loc2);
			Console.WriteLine("[returned from native] distance = {0}", dist);

			MLocation loc3;
			unsafe
			{
				TraditionalDLL.InitLocation ( &loc3 );
			}

			Console.WriteLine ( "[initialized by native code] x={0} y={1}", loc3.x, loc3.y );
		}
	}
}
