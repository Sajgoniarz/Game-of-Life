using System;
using System.Configuration;

namespace Game_Of_Life
{
    public class Settings
    {
        public readonly int Width;
        public readonly int Height;
        public readonly bool Fullscreen;
        public readonly int PixelSize;
        public readonly int Density;
        public readonly int TickTime;
        public readonly int[] Survivors;
        public readonly int[] Reproductors;
        Converter<char, int> charTointConverter = new Converter<char, int>(charToIntConverter);

        public Settings()
        {
            var config = ConfigurationManager.AppSettings;
            Fullscreen = bool.Parse(config["Fullscreen"]);
            Width = int.Parse(config["WindowWidth"]);
            Height = int.Parse(config["WindowHeight"]);
            PixelSize = int.Parse(config["PixelSize"]);
            Density = int.Parse(config["Density"]);
            TickTime = int.Parse(config["TickTime"]);
            Survivors = Array.ConvertAll(config["Survivors"].ToCharArray(), charTointConverter);
            Reproductors = Array.ConvertAll(config["Reproductors"].ToCharArray(), charTointConverter);
        }

        private static int charToIntConverter(char input)
        {
            return input - '0';
        }
    }
}
