using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StreamsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = string.Join("", Enumerable.Range(0, 100000)
                .Select(n => n.ToString())
                .ToArray());


            Stream foo = null;
            try
            {
                foo = File.OpenWrite("text.txt");
            }
            finally
            {
                if (foo != null)
                {
                    foo.Close();
                }
            }

            using (var bar = File.OpenWrite("text.txt"))
            {
                bar.WriteByte(5);
            }

            var strm = File.OpenRead("text.txt");

            var date = strm.ReadByte();
            Console.WriteLine(date);

            var strm2 = File.OpenRead("text.txt");

            var date2 = strm.ReadByte();
            Console.WriteLine(date);

            using (var foobidu = new Foobidu())
            {
                Console.WriteLine("Blubb");
                foobidu.Foo();
            }


                //using (var strm = File.OpenWrite("text.txt"))
                //{
                //    using (var zipStrm = new DeflateStream(strm, CompressionLevel.Optimal))
                //    {
                //        DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

                //        cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
                //        cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");

                //        using (var crStream = new CryptoStream(zipStrm,
                //            cryptic.CreateEncryptor(), CryptoStreamMode.Write))
                //        {
                //            using (var foo = new StreamWriter(crStream))
                //            {
                //                foo.WriteLine(data);
                //            }
                //        }
                //    }
                //}

                Console.ReadKey();
        }
    }

    class Foobidu : IDisposable
    {
        public void Foo()
        {
            Console.WriteLine("In Foo()");
        }

        public void Dispose()
        {
            Console.WriteLine("In Dispose()");
        }
    }
}
