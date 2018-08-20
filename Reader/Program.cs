using System;
using System.IO;

namespace Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = ReadBytes(@"E:\dev_files\Yamaha-V50-Synbass-1-C2.wav");

            var wav = Wav.CreateWav(data);

            var ChunkId = wav.ChunkId;
            var ChunkSize = wav.ChunkSize;
            var Format = wav.Format;
            var Subchunk1Id = wav.Subchunk1Id;
            var Subchunk1Size = wav.Subchunk1Size;
            var AudioFormat = wav.AudioFormat;
            var NumChannels = wav.NumChannels;
            var SampleRate = wav.SampleRate;
            var ByteRate = wav.ByteRate;
            var BlockAlign = wav.BlockAlign;
            var BitsPerSample = wav.BitsPerSample;
            var Subchunk2Id = wav.Subchunk2Id;
            var Subchunk2Size = wav.Subchunk2Size;

            string str_chunkId = GetBytesAsString(wav._ChunkId);
            string str_chunkSize = GetBytesAsString(wav._ChunkSize);
            string str_format = GetBytesAsString(wav._Format);
            string str_sub1Id = GetBytesAsString(wav._Subchunk1Id);
            string str_sub1Size = GetBytesAsString(wav._Subchunk1Size);
            string str_audioForm = GetBytesAsString(wav._AudioFormat);
            string str_numChan = GetBytesAsString(wav._NumChannels);
            string str_sRate = GetBytesAsString(wav._SampleRate);
            string str_bRate = GetBytesAsString(wav._ByteRate);
            string str_align = GetBytesAsString(wav._BlockAlign);
            string str_bps = GetBytesAsString(wav._BitsPerSample);
            string str_sub2Id = GetBytesAsString(wav._Subchunk2Id);
            string str_sub2Size = GetBytesAsString(wav._Subchunk2Size);
            string str_data = GetBytesAsString(wav._RawData);

            Console.WriteLine(
                $"ChunkId       : {ChunkId}\t:: {str_chunkId}\n" +
                $"ChunkSize     : {ChunkSize}\t:: {str_chunkSize}\n" +
                $"Format        : {Format}\t:: {str_format}\n" +
                $"Subchunk1Id   : {Subchunk1Id}\t:: {str_sub1Id}\n" +
                $"Subchunk1Size : {Subchunk1Size}\t:: {str_sub1Size}\n" +
                $"AudioFormat   : {AudioFormat}\t:: {str_audioForm}\n" +
                $"NumChannels   : {NumChannels}\t:: {str_numChan}\n" +
                $"SampleRate    : {SampleRate}\t:: {str_sRate}\n" +
                $"ByteRate      : {ByteRate}\t:: {str_bRate}\n" +
                $"BlockAlign    : {BlockAlign}\t:: {str_align}\n" +
                $"BitsPerSample : {BitsPerSample}\t:: {str_bps}\n" +
                $"Subchunk2Id   : {Subchunk2Id}\t:: {str_sub2Id}\n" +
                $"Subchunk2Size : {Subchunk2Size}\t:: {str_sub2Size}\n\n" +
                $"Raw Data      : {str_data.Substring(0, 254)}...");

        }

        public static byte[] ReadBytes(string filePath)
        {
            byte[] data;

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File Not Found", filePath);

            data = File.ReadAllBytes(filePath);

            return data;
        }

        private static string GetBytesAsString(byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }
    }


}
