using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Utils
{
    public class ReplaceBytes
    {
        public static void ReplaceHexInFile(string filePath, string findHex, string replacementHex)
        {
            byte[] find = ConvertHexStringToByteArray(Regex.Replace(findHex, "0x|[ ,]", string.Empty).Normalize().Trim());
            byte[] replace = ConvertHexStringToByteArray(Regex.Replace(replacementHex, "0x|[ ,]", string.Empty).Normalize().Trim());

            if (find.Length != replace.Length)
            {
                throw new ArgumentException("Find and replace hex must be the same length");
            }

            int bufferSize = 4096; // Adjust the buffer size as needed
            byte[] buffer = new byte[bufferSize];
            int bytesRead;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        while ((bytesRead = reader.Read(buffer, 0, bufferSize)) > 0)
                        {
                            for (int i = 0; i < bytesRead - find.Length + 1; i++)
                            {
                                if (BytesMatch(buffer, i, find))
                                {
                                    // Replace the bytes
                                    for (int j = 0; j < replace.Length; j++)
                                    {
                                        buffer[i + j] = replace[j];
                                    }
                                    writer.Seek(-bytesRead, SeekOrigin.Current);
                                    writer.Write(buffer, 0, bytesRead);
                                    writer.Seek(0, SeekOrigin.End);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool BytesMatch(byte[] source, int position, byte[] pattern)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (source[position + i] != pattern[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException($"The binary key cannot have an odd number of digits: {hexString}");
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
    }
}
