using System.Linq;

string c = "char";
byte baz = Convert.ToByte(c[0]);
Console.WriteLine(baz);

string hexValue = baz.ToString("X2");
Console.WriteLine(hexValue);
Console.WriteLine("0x{0,2:X2}", baz);

// string.format("{0}", hexValue);
// $"{hexValue}"
Console.WriteLine(String.Format("0x{0,2:X2}", baz));

// "See\u00A0what\'s hidden in your string\u2026\tor be\\u200Bhind\uFEFF"

// var cha2 = '…';
// // Console.WriteLine(Convert.ToByte(cha2));
// Console.WriteLine(String.Format("0x{0,2:X2}", Convert.ToByte(cha2)));
// var cha3 = '​';
// Console.WriteLine(String.Format("0x{0,2:X2}", Convert.ToByte(cha3)));
// var cha4 = '﻿';
// Console.WriteLine(String.Format("0x{0,2:X2}", Convert.ToByte(cha4)));

// var cha = ' ';
// var hex = String.Format("0x{0,2:X2}", (Convert.ToByte(cha)));
// Console.WriteLine(hex);

// 0xA0
// U+A0

// string[] HexString = result.ToList().Select(k => "0x" + k.ToString("x")).ToArray();

char charValue = ' '; // &#160; // \u00A0 - A0-00 => 00-A0
// char charValue = '…'; // &#8230; // \u2026 - 26-20
// char charValue = '​';
// char charValue = '﻿';

Console.WriteLine(BitConverter.IsLittleEndian.ToString());

Console.WriteLine("Char value: " + charValue.ToString());
var bytes = BitConverter.GetBytes(charValue);

var isLittleEndian = BitConverter.IsLittleEndian;

if (isLittleEndian) {
    Array.Reverse(bytes);
}


int decVal = 0;
// foreach (var byte in bytes)
// {
//     decVal += byte;
// }

for(int i = 0; i < bytes.Length; i++)
{
    var v = bytes[i];
    decVal += v;
}



Console.WriteLine(decVal);
int sum = bytes.Select(x => (int)x).Sum();
Console.WriteLine(sum);

// Console.WriteLine(bytes.Sum());

Console.WriteLine("Byte array value:");
Console.WriteLine(BitConverter.ToString(bytes).Replace("-", String.Empty));