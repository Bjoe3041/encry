using encry;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        VBGG_CRYPT vBGG_CRYPT= new VBGG_CRYPT();
        
        string input = "Eating chips wow";
        string key = "haha";
        
        string encrypted;
        string encoded;
        string decoded;
        string decrypted;

        encrypted = vBGG_CRYPT.VBGG_ENCRYPT(input, key);
        encoded = vBGG_CRYPT.AsciiEncode(encrypted);
        decoded = vBGG_CRYPT.AsciiDecode(encoded);
        decrypted = vBGG_CRYPT.VBGG_DECRYPT(decoded, key);

        Console.WriteLine("Input:     " + input);
        Console.WriteLine("Key:       " + key+"\n");

        Console.WriteLine("Encrypted, data is now: ("+encrypted+ ")  with key: ("+key+")");
        Console.WriteLine("Encoded, data is now:   ("+encoded+")");
        Console.WriteLine("Decoded, data is now:   ("+decoded+")");
        Console.WriteLine("Decrypted, data is now: ("+decrypted + ")  with key: (" + key+")");

    }
}