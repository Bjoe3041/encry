using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encry
{
    public class VBGG_CRYPT
    {

        public string VBGG_DECRYPT(string v, string key)
        {
            string res = "";
            int[] outputValues = new int[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                try
                {
                    outputValues[i] = (int)v[i] - (int)Math.Sqrt(LoopGet(i, key) * StringAsInt(key));

                }
                catch (Exception)
                {

                    outputValues[i] = 0;
                }
            }

            for (int i = 0; i < outputValues.Length; i++)
            {
                res += (char)outputValues[i];
            }

            return res;
        }

        public string VBGG_ENCRYPT(string v, string key)
        {
            v = " " + v;

            string res = "";
            int[] outputValues = new int[v.Length];
            for (int i = 1; i < v.Length; i++)
            {
                outputValues[i] = (int)v[i] + (int)Math.Sqrt(LoopGet(i, key) * StringAsInt(key));
            }

            for (int i = 0; i < outputValues.Length; i++)
            {
                res += (char)outputValues[i];
            }

            return res;

        }

        private int StringAsInt(string s)
        {
            int returnInt = 0;
            for (int i = 0; i < s.Length; i++)
            {
                returnInt += (int)s[i];
            }
            return returnInt;
        }

        private int LoopGet(int i, string key)
        {
            int pointer = 0;
            for (int iRoll = 0; iRoll < i; iRoll++)
            {
                if (pointer > key.Length)
                    pointer = 0;
                else
                    pointer++;
            }

            return pointer;
        }

        public string AsciiDecode(string v)
        {
            string res = "";
            string[] work = v.Split(' ');
            foreach (string s in work)
                try
                {
                    res += (char)int.Parse(s);

                }
                catch (Exception)
                {

                }

            return res;
        }

        public string AsciiEncode(string v)
        {
            string res = "";
            for (int i = 0; i < v.Length; i++)
            {
                if (i != 0)
                    res += " ";
                res += (int)v[i];
            }
            return res;
        }

    }
}
