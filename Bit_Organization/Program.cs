namespace Bit_Organization
{
	internal class Program
	{
		static void Main(string[] args)
		{
			byte num1 = 8; // 0_ _ _ _ _ _ _ _ 1 
			sbyte num2 = -8;// 1_ _ _ _ _ _ _ _ 1 byte 8 bit en soldaki isaret biti 0 ise pozitif 1 ise negatif oldugunu ifade eder
			Console.WriteLine($"min byte value: {byte.MinValue} max byte value: {byte.MaxValue}");
			Console.WriteLine($"min sbyte value: {sbyte.MinValue} max sbyte value: {sbyte.MaxValue}");

			var numbers = new string[]
			{
				"00000000",	// 0
				"00000001",	// 1
				"00000010",	// 2 
				"00000011",	// 3 
				"00001000",	// 8
				"10000000",	// 128 |  -128
				"10000001",	// 129 | -128+1 = -127
				"10000011",	// 131 | -128+3 = -125
				"10001111",	// 143 | -128+15 = -113
				"11111111",    // 255 | -128+127 = -1
			};
			//en soldaki isaret biti eder birse "-" degilse "+" sbyte icin..
			foreach (var item in numbers)
			{
				byte number = Convert.ToByte(item, 2);
				//sbyte numberSByte = Convert.ToSByte(item, 2);
				Console.WriteLine(number);
			}

			Console.WriteLine("{0} - {1}", UInt32.MaxValue, UInt32.MinValue);
			Console.WriteLine("{0} - {1}", Int64.MaxValue, Int64.MinValue);
			Console.WriteLine("{0} - {1}", Int16.MaxValue, Int16.MinValue);
			Console.WriteLine("{0} - {1}", UInt16.MaxValue, UInt16.MinValue);
		}
	}
}
