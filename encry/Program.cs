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

        //string input = "Eating chips wow";
        //string key = "haha";

        Console.WriteLine("Write input data");
        string input = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Input data: "+input);
        Console.WriteLine("Write encryption key");
        string key = Console.ReadLine();
        Console.Clear();

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

        
        
        
        
        
        
        
        
        
        
        Console.WriteLine("");
        Console.WriteLine("Attempt alternate decryption key: ");
        string altKey = Console.ReadLine();

        encrypted = vBGG_CRYPT.VBGG_ENCRYPT(input, key);
        encoded = vBGG_CRYPT.AsciiEncode(encrypted);
        decoded = vBGG_CRYPT.AsciiDecode(encoded);
        decrypted = vBGG_CRYPT.VBGG_DECRYPT(decoded, altKey);

        Console.WriteLine("Input:     " + input);
        Console.WriteLine("Key:       " + key + "\n");
        Console.WriteLine("Alt Key:   " + altKey + "\n");

        Console.WriteLine("Encrypted, data is now: (" + encrypted + ")  with key: (" + key + ")");
        Console.WriteLine("Encoded, data is now:   (" + encoded + ")");
        Console.WriteLine("Decoded, data is now:   (" + decoded + ")");
        Console.WriteLine("Decrypted, data is now: (" + decrypted + ")  with key: (" + altKey + ")");

    }
}