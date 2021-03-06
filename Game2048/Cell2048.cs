﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048 {
    class Cell2048 {
        public int Value;

        private Rectangle rectangle;

        private static int margin;
        private static Dictionary<int, Color> colorDictionary;

        public int XCoordinate;
        public int YCoordinate;
        public int Size;

        private SolidBrush brushRectangle;
        private SolidBrush brushValue;

        static Cell2048() {
            Cell2048.margin = 4;
            Cell2048.colorDictionary = new Dictionary<int, Color>();

            colorDictionary.Add(2, Color.Yellow);
            colorDictionary.Add(4, Color.DarkRed);
            colorDictionary.Add(8, Color.DarkOrange);
            colorDictionary.Add(16, Color.Green);
            colorDictionary.Add(32, Color.Blue);
            colorDictionary.Add(64, Color.Purple);
            colorDictionary.Add(128, Color.DarkCyan);
            colorDictionary.Add(256, Color.DarkMagenta);
            colorDictionary.Add(512, Color.ForestGreen);
            colorDictionary.Add(1024, Color.DarkSalmon);
            colorDictionary.Add(2048, Color.DarkTurquoise);
            colorDictionary.Add(4096, Color.HotPink);
            colorDictionary.Add(8192, Color.Black);
            colorDictionary.Add(16384, Color.MidnightBlue);
            colorDictionary.Add(32768, Color.Violet);
        }

        public Cell2048(int XCoordinate, int YCoordinate, int size, int value) {
            this.Value = value;
            this.Size = size;
            this.XCoordinate = XCoordinate + Cell2048.margin / 2;
            this.YCoordinate = YCoordinate + Cell2048.margin / 2;

            int sizeRectangle = this.Size - Cell2048.margin;
            this.rectangle = new Rectangle(this.XCoordinate, this.YCoordinate, sizeRectangle, sizeRectangle);
            this.brushValue = new SolidBrush(Color.White);
            this.setBrush(Cell2048.colorDictionary[this.Value]);
        }

        private void setBrush(Color color) {
            this.brushRectangle = new SolidBrush(color);
        }

        public void draw(Graphics graphics) {
            graphics.FillRectangle(this.brushRectangle ,this.rectangle);

            FontFamily fontFamily = new FontFamily("Comic Sans MS");
            Font font = new Font(fontFamily, 16, FontStyle.Bold);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(this.Value.ToString(), font, this.brushValue, this.rectangle, stringFormat);
            this.clean();
        }

        private void clean() {
            this.brushRectangle.Dispose();
            this.brushValue.Dispose();
        }
    }
}
