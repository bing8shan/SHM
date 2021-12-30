using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDllLib
{
    public class MapFileHelper
    {
        private static int FILE_SIZE = 256;
        private static string FILE_NAME = "IDCARDINFO.DAT";
        public static string FULLPATH = @"c:\IDCARDINFO.DAT";
        public const string CONTENT = "READIDNO";


        public static void writeMemoryMappedFile()
        {
            using (var mmf = MemoryMappedFile.CreateFromFile(FULLPATH, FileMode.OpenOrCreate, FILE_NAME, FILE_SIZE))
            {

                using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, FILE_SIZE)) //偏移量，可以控制数据存储的内存位置；大小，用来控制存储所占用的空间
                {
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(CONTENT);
                    var writer = new BinaryWriter(stream);
                    writer.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        writer.Write(bytes[i]);

                    }

                }

            }

        }
        public static void clearMemoryMappedFile()
        {
            using (var mmf = MemoryMappedFile.CreateFromFile(FULLPATH, FileMode.OpenOrCreate, FILE_NAME, FILE_SIZE))
            {
                using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, FILE_SIZE)) //偏移量，可以控制数据存储的内存位置；大小，用来控制存储所占用的空间
                {
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(CONTENT);
                    var writer = new BinaryWriter(stream);
                    writer.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        writer.Write((byte)'a');

                    }
                }
            }

        }
        public static string readMemoryMappedFile()
        {
            string ret = "";
            using (var mmf = MemoryMappedFile.CreateFromFile(FULLPATH, FileMode.OpenOrCreate, FILE_NAME, FILE_SIZE))
            {
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    byte[] bytes = new byte[System.Text.Encoding.Default.GetBytes(CONTENT).Length];
                    stream.Seek(0, SeekOrigin.Begin);
                    var reader = new BinaryReader(stream);
                    //reader.Seek(0, SeekOrigin.Begin);
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        byte b = reader.ReadByte();
                        bytes[i] = b;
                    }
                    ret = System.Text.Encoding.Default.GetString(bytes);

                }
            }
            return ret;
        }
    }
}
