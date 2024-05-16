using Algorithm_assignment;
using burrows;
using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

class Program
{
    private static void Compress(string filePath)
    {
        string CompressedFileName = Path.GetFileNameWithoutExtension(filePath) + ".bin";
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        byte[] inputText = File.ReadAllBytes(filePath);
        byte[] bwt = Transform.Transform_Text(inputText);
        byte[] encode = MoveToFront.Encode(inputText);
        HuffmanCoding huffmanCoding = new HuffmanCoding();
        byte[] compress = huffmanCoding.Compress(encode);
        File.WriteAllBytes(CompressedFileName, compress);
        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;
        Console.WriteLine("Total Compression Execution Time For File " + filePath + ": " + elapsedTime.TotalSeconds);
    }

    private static void Decompress(string filePath)
    {

        string DecompressedFileName = Path.GetFileNameWithoutExtension(filePath) + "_Decompressed.txt";
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        HuffmanCoding huffmanCoding = new HuffmanCoding();
        byte[] inputText = File.ReadAllBytes(filePath);
        byte[] decompressed = huffmanCoding.DCompress(inputText);
        byte[] decode = MoveToFront.Decode(decompressed);
        byte[] inverse = Inverse.InverseTransform(decode);
        File.WriteAllBytes(DecompressedFileName, decode);
        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;
        Console.WriteLine("Total Decompression Execution Time For File " + filePath + ": " + elapsedTime.TotalSeconds);
    }
    static void Main(string[] args)
    {

        if (args.Length < 2)
        {
            Console.WriteLine("Usage: bwt-compression <compress|decompress> <filePath>");
            return;
        }

        string mode = args[0];
        string filePath = args[1];

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File not found: " + filePath);
            return;
        }

        if (mode.ToLower() == "compress")
        {
            Compress(filePath);
        }
        else if (mode.ToLower() == "decompress")
        {
            Decompress(filePath);
        }
        else
        {
            Console.WriteLine("Error: Unknown mode: " + mode);
            Console.WriteLine("Usage: bwt-compression <compress|decompress> <filePath>");
        }
    }
}

