using System;

namespace Reader
{
    public class Wav
    {
        private byte[] _ChunkId;
        private byte[] _ChunkSize;
        private byte[] _Format;
        private byte[] _Subchunk1Id;
        private byte[] _Subchunk1Size;
        private byte[] _AudioFormat;
        private byte[] _NumChannels;
        private byte[] _SampleRate;
        private byte[] _ByteRate;
        private byte[] _BlockAlign;
        private byte[] _BitsPerSample;
        private byte[] _Subchunk2Id;
        private byte[] _Subchunk2Size;
        private byte[] _Data;
        private byte[] _RawData;

        #region Getter Convertions

        public string ChunkId { get { return System.Text.Encoding.ASCII.GetString(_ChunkId); } }
        public int ChunkSize { get { return BitConverter.ToInt32(_ChunkSize, 0); } }
        public string Format { get { return System.Text.Encoding.ASCII.GetString(_Format); } }
        public string Subchunk1Id { get { return System.Text.Encoding.ASCII.GetString(_Subchunk1Id); } }
        public int Subchunk1Size { get { return BitConverter.ToInt32(_Subchunk1Size, 0); } }
        public int AudioFormat { get { return BitConverter.ToInt16(_AudioFormat, 0); } }
        public int NumChannels { get { return BitConverter.ToInt16(_NumChannels, 0); } }
        public int SampleRate { get { return BitConverter.ToInt32(_SampleRate, 0); } }
        public int ByteRate { get { return BitConverter.ToInt32(_ByteRate, 0); } }
        public int BlockAlign { get { return BitConverter.ToInt16(_BlockAlign, 0); } }
        public int BitsPerSample { get { return BitConverter.ToInt16(_BitsPerSample, 0); } }
        public string Subchunk2Id { get { return System.Text.Encoding.ASCII.GetString(_Subchunk2Id); } }
        public int Subchunk2Size { get { return BitConverter.ToInt32(_Subchunk2Size, 0); } }
        public byte[] Data { get { return _Data; } }

        public byte[] LeftSamples { get; }
        public byte[] RightSamples { get; }

        #endregion

        #region Creation Helpers

        public static Wav CreateWav(byte[] rawData)
        {
            var wav = new Wav()
            {
                _ChunkId = SubArray(rawData, 0, 4),
                _ChunkSize = SubArray(rawData, 4, 4),
                _Format = SubArray(rawData, 8, 4),
                _Subchunk1Id = SubArray(rawData, 12, 4),
                _Subchunk1Size = SubArray(rawData, 16, 4),
                _AudioFormat = SubArray(rawData, 20, 2),
                _NumChannels = SubArray(rawData, 22, 2),
                _SampleRate = SubArray(rawData, 24, 4),
                _ByteRate = SubArray(rawData, 28, 4),
                _BlockAlign = SubArray(rawData, 32, 2),
                _BitsPerSample = SubArray(rawData, 34, 2),
                _Subchunk2Id = SubArray(rawData, 36, 4),
                _Subchunk2Size = SubArray(rawData, 40, 4),
                _Data = SubArray(rawData, 44, rawData.Length - 44),
                _RawData = rawData,
            };

            if (wav.NumChannels > 1)
                wav = GetDualChannel();

            if (ValidateWav(wav))
                return wav;
            else
                throw new FormatException("File not in correct WAV format.");
        }

        private static T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        private static bool ValidateWav(Wav wav)
        {
            bool result = true;

            if (wav.ChunkId != "RIFF") result = false;
            if (wav.Format != "WAVE") result = false;
            if (wav.Subchunk1Id != "fmt ") result = false;
            if (wav.Subchunk2Id != "data") result = false;
            if (wav.ChunkId != "RIFF") result = false;

            return result;
        }

        private static Wav GetDualChannel(Wav wav)
        {
            var data = wav.Data;
            var dataLength = data.Length;

            var leftSample = true;
            var left = new byte[dataLength / 2];
            var right = new byte[dataLength / 2];

            for(int i=0;i<dataLength;i+=4)
            {
                
            }

            return wav;
        }

        #endregion
    }
}
