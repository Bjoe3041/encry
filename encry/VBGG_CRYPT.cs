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


        public string RailFenceDecode(string v) //made for things like WECRUO ERDSOEERNTNE AIVDAC
        {
            string res = "";
            List<string> sections = v.Split(" ").ToList();

            bool direction = true;

            int sectionPointer = 0;
            while (res.Length < v.Length + sections.Count * 2)
            {
                for (int i = 0; i < sections.Count; i++)
                {
                    res += sections[i].First();
                    sections[i] = sections[i].Remove(0, 1);
                }
                res += " ";

                for (int i = sections.Count - 2; i > 0; i--)
                {
                    res += sections[i].First();
                    sections[i] = sections[i].Remove(0, 1);
                }
                res += " ";


            }

            return res;
        }

        public static string DecryptRailFence(string cipher, int key)// not mine, just added here for ctf usage
        {
            // create the matrix to cipher plain text
            // key = rows, length(text) = columns
            char[,] rail = new char[key, cipher.Length];

            // filling the rail matrix to distinguish filled
            // spaces from blank ones
            for (int i = 0; i < key; i++)
                for (int j = 0; j < cipher.Length; j++)
                    rail[i, j] = '\n';

            // to find the direction
            bool dirDown = true;
            int row = 0, col = 0;

            // mark the places with '*'
            for (int i = 0; i < cipher.Length; i++)
            {
                // check the direction of flow
                if (row == 0)
                    dirDown = true;
                if (row == key - 1)
                    dirDown = false;

                // place the marker
                rail[row, col++] = '*';

                // find the next row using direction flag
                if (dirDown)
                    row++;
                else
                    row--;
            }

            // now we can construct the fill the rail matrix
            int index = 0;
            for (int i = 0; i < key; i++)
                for (int j = 0; j < cipher.Length; j++)
                    if (rail[i, j] == '*' && index < cipher.Length)
                        rail[i, j] = cipher[index++];

            // create the result string
            string result = "";
            row = 0;
            col = 0;

            // iterate through the rail matrix
            for (int i = 0; i < cipher.Length; i++)
            {
                // check the direction of flow
                if (row == 0)
                    dirDown = true;
                if (row == key - 1)
                    dirDown = false;

                // place the marker
                if (rail[row, col] != '*')
                    result += rail[row, col++];

                // find the next row using direction flag
                if (dirDown)
                    row++;
                else
                    row--;
            }
            return result;
        }


    }
}

