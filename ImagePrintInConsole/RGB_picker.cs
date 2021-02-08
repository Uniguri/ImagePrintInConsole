using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Numerics;

namespace ImagePrintInConsole
{
    class RGB_picker
    {
        private Bitmap bitmap;
        private string _img_path;
        private int _size_of_x;
        private int _size_of_y;

        public string img_path
        {
            get
            {
                return _img_path;
            }
        }
        public int size_of_x
        {
            get
            {
                return _size_of_x;
            }
        }
        public int size_of_y
        {
            get
            {
                return _size_of_y;
            }
        }
        public int ConsoleColor_X
        {
            get
            {
                return (int)bitmap.Width / size_of_x;
            }
        }
        public int ConsoleColor_Y
        {
            get
            {
                return (int)bitmap.Height / size_of_y;
            }
        }

        public bool Set_img_path(string path)
        {
            Boolean ret = false;
            if (File.Exists(path) == true)
            {
                ret = true;
                _img_path = path;
                bitmap = new Bitmap(img_path);
            }
            return ret;
        }
        public void Set_size(int console_size_x, int console_size_y, bool use_ratio = false)
        {
            if (use_ratio == true)
            {
                if (bitmap.Width > bitmap.Height)
                {
                    _size_of_y = (int)(bitmap.Height / console_size_y) + 1;
                    _size_of_x = (int)(bitmap.Width / bitmap.Height * size_of_y) + 1;
                }
                else
                {
                    _size_of_x = (int)(bitmap.Width / console_size_x) + 1;
                    _size_of_y = (int)(bitmap.Height / bitmap.Width * size_of_x) + 1;
                }

            }
            else
            {
                _size_of_x = (int)(bitmap.Width / console_size_x) + 1;
                _size_of_y = (int)(bitmap.Height / console_size_y) + 1;
            }

        }

        private Color Select_Representive_Color(int x_start, int x_end, int y_start, int y_end)
        {
            Color color;
            int a = 0;
            int r = 0;
            int g = 0;
            int b = 0;
            for (int x = x_start; x < x_end; x++)
            {
                for (int y = y_start; y < y_end; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    a += color.A;
                    r += color.R;
                    g += color.G;
                    b += color.B;
                }
            }
            a = a / ((x_end - x_start) * (y_end - y_start));
            r = r / ((x_end - x_start) * (y_end - y_start));
            g = g / ((x_end - x_start) * (y_end - y_start));
            b = b / ((x_end - x_start) * (y_end - y_start));
            color = Color.FromArgb(a, r, g, b);
            return color;
        }
        private System.ConsoleColor Select_Console_Color(Color target_color, bool use_manhattan_distance = true)
        {
            List<Color> color_lists = new List<Color>();
            Color similiar_color = new Color();
            System.ConsoleColor ret = ConsoleColor.White;
            double low = 100000;
            double temp;
            {
                color_lists.Add(Color.Black);
                color_lists.Add(Color.DarkBlue);
                color_lists.Add(Color.DarkCyan);
                color_lists.Add(Color.DarkRed);
                color_lists.Add(Color.DarkMagenta);
                color_lists.Add(Color.Gray);
                color_lists.Add(Color.DarkGray);
                color_lists.Add(Color.Blue);
                color_lists.Add(Color.Green);
                color_lists.Add(Color.Cyan);
                color_lists.Add(Color.Red);
                color_lists.Add(Color.Magenta);
                color_lists.Add(Color.Yellow);
                color_lists.Add(Color.White);
            }
            foreach (Color items in color_lists)
            {
                if (use_manhattan_distance == true)
                    temp = Math.Abs(target_color.A - items.A) + Math.Abs(target_color.R - items.R) + Math.Abs(target_color.G - items.G) + Math.Abs(target_color.B - items.B);
                else
                    temp = Math.Sqrt(Math.Pow(target_color.A - items.A, 2) + Math.Pow(target_color.R - items.R, 2) + Math.Pow(target_color.G - items.G, 2) + Math.Pow(target_color.B - items.B, 2));

                if (temp < low)
                {
                    low = temp;
                    similiar_color = items;
                }
            }

            switch (similiar_color.ToArgb())
            {
                case -16777216:
                    ret = ConsoleColor.Black;
                    break;
                case -16777077:
                    ret = ConsoleColor.DarkBlue;
                    break;
                case -16741493:
                    ret = ConsoleColor.DarkCyan;
                    break;
                case -7667712:
                    ret = ConsoleColor.DarkRed;
                    break;
                case -7667573:
                    ret = ConsoleColor.DarkMagenta;
                    break;
                case -8355712:
                    ret = ConsoleColor.Gray;
                    break;
                case -5658199:
                    ret = ConsoleColor.DarkGray;
                    break;
                case -16776961:
                    ret = ConsoleColor.Blue;
                    break;
                case -16744448:
                    ret = ConsoleColor.Green;
                    break;
                case -16711681:
                    ret = ConsoleColor.Cyan;
                    break;
                case -65536:
                    ret = ConsoleColor.Red;
                    break;
                case -65281:
                    ret = ConsoleColor.Magenta;
                    break;
                case -256:
                    ret = ConsoleColor.Yellow;
                    break;
                case -1:
                    ret = ConsoleColor.White;
                    break;
            }

            return ret;
        }

        public ConsoleColor[,] Colors_Changed_Console_Color()
        {
            ConsoleColor[,] ret = new ConsoleColor[ConsoleColor_X, ConsoleColor_Y];
            for (int x = 0; x < ConsoleColor_X; x++)
            {
                for (int y = 0; y < ConsoleColor_Y; y++)
                {
                    ret[x, y] = Select_Console_Color(Select_Representive_Color(x * size_of_x, (x + 1) * size_of_x, y * size_of_y, (y + 1) * size_of_y));
                }
            }

            return ret;
        }
        public List<ConsoleColor[,]> Colors_Changed_Console_Color_gif()
        {
            List<ConsoleColor[,]> ret = new List<ConsoleColor[,]>();
            ConsoleColor[,] temp;
            Guid[] guid = bitmap.FrameDimensionsList;
            System.Drawing.Imaging.FrameDimension fd = new System.Drawing.Imaging.FrameDimension(guid[0]);
            int framecount = bitmap.GetFrameCount(fd);
            for (int frame = 0; frame < framecount; frame++)
            {
                bitmap.SelectActiveFrame(fd, frame);
                temp = new ConsoleColor[ConsoleColor_X, ConsoleColor_Y];
                for (int x = 0; x < ConsoleColor_X; x++)
                {
                    for (int y = 0; y < ConsoleColor_Y; y++)
                    {
                        temp[x, y] = Select_Console_Color(Select_Representive_Color(x * size_of_x, (x + 1) * size_of_x, y * size_of_y, (y + 1) * size_of_y));
                    }
                }
                ret.Add(temp);
            }

            return ret;
        }
    }
}
