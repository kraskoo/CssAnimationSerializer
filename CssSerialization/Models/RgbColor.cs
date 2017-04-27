namespace Models
{
    using System;

    public struct RgbColor
    {
        public RgbColor(byte red, byte green, byte blue) : this()
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public byte Red { get; }

        public byte Green { get; }

        public byte Blue { get; }

        public static implicit operator string(RgbColor rgb)
        {
            return string.Format(
                "#{0}",
                BitConverter.ToString(
                    new[] { rgb.Red, rgb.Green, rgb.Blue })
                .Replace("-", string.Empty));
        }
    }
}