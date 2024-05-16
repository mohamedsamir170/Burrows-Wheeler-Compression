using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm_assignment;
using static System.Net.Mime.MediaTypeNames;


namespace burrows
{
    public class Transform
    {

        public static byte[] Transform_Text(byte[] inputBytes)
        {
            byte eof = 0;
            byte[] inputBytesWithEOF = new byte[inputBytes.Length + 1];
            Array.Copy(inputBytes, inputBytesWithEOF, inputBytes.Length);
            inputBytesWithEOF[inputBytes.Length] = eof;

            short[] shortString = new short[inputBytesWithEOF.Length];
            for (int i = 0; i < inputBytesWithEOF.Length; i++)
                shortString[i] = BitConverter.ToInt16(new byte[] { inputBytesWithEOF[i], 0 }, 0);

            int[] suffixArray = SuffixArray.Construct(shortString);

            byte[] bwtArray = new byte[inputBytesWithEOF.Length];

            for (int i = 0; i < suffixArray.Length; i++)
            {
                int bwtIndex = (suffixArray[i] - 1 + inputBytesWithEOF.Length) % inputBytesWithEOF.Length;
                bwtArray[i] = inputBytesWithEOF[bwtIndex];
            }

            return bwtArray;
        }


    }
}
