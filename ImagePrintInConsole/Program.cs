using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace ImagePrintInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string img_path = @"C:\Users\jagyu\OneDrive\사진\gif\zuttomayo-20200627-152651-000.gif";

            Basic_Gif_v4(img_path, true, true);
        }
        static void Basic(string img_path)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(237, 69);
            ConsoleColor[,] colors = picker.Colors_Changed_Console_Color();

            Drawer drawer = new Drawer();

        }
        static void Basic_Gif_v1(string img_path, bool use_read = false, int image_width = 237, int image_height = 69)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(image_width, image_height);
            var colors = picker.Colors_Changed_Console_Color_gif();

            Drawer drawer = new Drawer();

            if (use_read == true)
            {
                System.Console.WriteLine("Ready");
                System.Console.Read();
                System.Console.Clear();
            }


            foreach (var item in colors)
            {
                for (int x = 0; x < picker.ConsoleColor_X; x++)
                    for (int y = 0; y < picker.ConsoleColor_Y; y++)
                    {
                        drawer.Color_Write(x, y, item[x, y]);
                    }
            }

            System.Console.SetCursorPosition(0, picker.ConsoleColor_Y + 1);
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
        static void Basic_Gif_v2(string img_path, bool use_read = false, int image_width = 237, int image_height = 69)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(image_width, image_height);
            var colors = picker.Colors_Changed_Console_Color_gif();

            Drawer drawer = new Drawer();

            if (use_read == true)
            {
                System.Console.WriteLine("Ready");
                System.Console.Read();
                System.Console.Clear();
            }


            for(int frame = 0; frame < colors.Count; frame++)
            {
                for(int x = 0; x < picker.ConsoleColor_X; x++)
                {
                    for(int y = 0; y < picker.ConsoleColor_Y; y++)
                    {
                        if(frame == 0)
                        {
                            drawer.Color_Write(x, y, colors[frame][x, y]);
                        }
                        else
                        {
                            if(colors[frame][x,y] != colors[frame - 1][x, y])
                            {
                                drawer.Color_Write(x, y, colors[frame][x, y]);
                            }
                        }
                    }
                }
            }

            System.Console.SetCursorPosition(0, picker.ConsoleColor_Y + 1);
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
        static void Basic_Gif_v3(string img_path, bool use_read = false, bool use_delay = false, bool use_black_screen = false, int image_width = 237, int image_height = 69)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(image_width, image_height);
            var colors = picker.Colors_Changed_Console_Color_gif();

            Drawer drawer = new Drawer();

            if (use_read == true)
            {
                System.Console.WriteLine("Ready");
                System.Console.Read();
                System.Console.Clear();
            }


            foreach (var item1 in colors)
            {
                List<Vector2> xylists = new List<Vector2>();
                for (int x = 0; x < picker.ConsoleColor_X; x++)
                    for (int y = 0; y < picker.ConsoleColor_Y; y++)
                    {
                        xylists.Add(new Vector2(x, y));
                    }

                Shuffle<Vector2> shuffle = new Shuffle<Vector2>();
                shuffle.Shuffle_List(xylists);

                foreach (var item2 in xylists)
                {
                    drawer.Color_Write((int)item2.X, (int)item2.Y, item1[(int)item2.X, (int)item2.Y]);
                }
                if(use_delay == true)
                    foreach (var item2 in xylists)
                    {
                        drawer.Color_Write((int)item2.X, (int)item2.Y, item1[(int)item2.X, (int)item2.Y]);
                    }
                if(use_black_screen == true)
                {
                    foreach (var item2 in xylists)
                    {
                        drawer.Color_Write((int)item2.X, (int)item2.Y, System.Console.BackgroundColor);
                    }
                    if (use_delay == true)
                        foreach (var item2 in xylists)
                         {
                        drawer.Color_Write((int)item2.X, (int)item2.Y, System.Console.BackgroundColor);
                         }
                } 
            }

            System.Console.SetCursorPosition(0, picker.ConsoleColor_Y + 1);
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
        static void Basic_Gif_v4(string img_path, bool use_read = false, bool use_delay = false, bool use_black_screen = false, int image_width = 237, int image_height = 69)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(image_width, image_height);
            var colors = picker.Colors_Changed_Console_Color_gif();

            Drawer drawer = new Drawer();

            if (use_read == true)
            {
                System.Console.WriteLine("Ready");
                System.Console.Read();
                System.Console.Clear();
            }


            for(int frame = 0; frame < colors.Count; frame++)
            {
                List<Vector2> xylists = new List<Vector2>();
                for (int x = 0; x < picker.ConsoleColor_X; x++)
                    for (int y = 0; y < picker.ConsoleColor_Y; y++)
                    {
                        xylists.Add(new Vector2(x, y));
                    }

                Shuffle<Vector2> shuffle = new Shuffle<Vector2>();
                shuffle.Shuffle_List(xylists);

                foreach (var item2 in xylists)
                {
                    if(frame == 0)
                    {
                        drawer.Color_Write((int)item2.X, (int)item2.Y, colors[frame][(int)item2.X, (int)item2.Y]);
                    }
                    else
                    {
                        if(colors[frame][(int)item2.X, (int)item2.Y] != colors[frame-1][(int)item2.X, (int)item2.Y])
                        {
                            drawer.Color_Write((int)item2.X, (int)item2.Y, colors[frame][(int)item2.X, (int)item2.Y]);
                        }
                    }
                    
                }
                if (use_delay == true)
                    foreach (var item2 in xylists)
                    {
                        if (frame == 0)
                        {
                            drawer.Color_Write((int)item2.X, (int)item2.Y, colors[frame][(int)item2.X, (int)item2.Y]);
                        }
                        else
                        {
                            if (colors[frame][(int)item2.X, (int)item2.Y] != colors[frame - 1][(int)item2.X, (int)item2.Y])
                            {
                                drawer.Color_Write((int)item2.X, (int)item2.Y, colors[frame][(int)item2.X, (int)item2.Y]);
                            }
                        }

                    }

                if (use_black_screen == true)
                {
                    foreach (var item2 in xylists)
                    {
                        drawer.Color_Write((int)item2.X, (int)item2.Y, System.Console.BackgroundColor);
                    }
                    if (use_delay == true)
                        foreach (var item2 in xylists)
                        {
                            drawer.Color_Write((int)item2.X, (int)item2.Y, System.Console.BackgroundColor);
                        }
                }
            }

            System.Console.SetCursorPosition(0, picker.ConsoleColor_Y + 1);
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
        static void Basic_v1(string img_path, bool use_read = false, int image_width = 237, int image_height = 69)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(image_width, image_height);
            ConsoleColor[,] colors = picker.Colors_Changed_Console_Color();

            Drawer drawer = new Drawer();

            if (use_read == true)
            {
                System.Console.WriteLine("Ready");
                System.Console.Read();
                System.Console.Clear();
            }

            for (int x = 0; x < picker.ConsoleColor_X; x++)
                for (int y = 0; y < picker.ConsoleColor_Y; y++)
                {
                    drawer.Color_Write(x, y, colors[x, y]);
                }
            System.Console.SetCursorPosition(0, picker.ConsoleColor_Y + 1);
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
        static void Basic_v2(string img_path, bool use_read = false, bool chaos = false, int chaos_times = 500, int image_width = 237, int image_height = 69)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(image_width, image_height);
            ConsoleColor[,] colors = picker.Colors_Changed_Console_Color();

            Drawer drawer = new Drawer();

            List<int> xl = new List<int>();
            List<int> yl = new List<int>();
            for (int i = 0; i < picker.ConsoleColor_X; i++)
                xl.Add(i);
            for (int i = 0; i < picker.ConsoleColor_Y; i++)
                yl.Add(i);
            Shuffle<int> shuffle = new Shuffle<int>();
            shuffle.Shuffle_List(xl);
            shuffle.Shuffle_List(yl);

            if (use_read == true)
            {
                System.Console.WriteLine("Ready");
                System.Console.Read();
                System.Console.Clear();
            }

            if (chaos == true)
                drawer.Chaos_line(chaos_times, false, 0, picker.ConsoleColor_X, 0, picker.ConsoleColor_Y);

            foreach (var x in xl)
            {
                foreach (var y in yl)
                {
                    drawer.Color_Write(x, y, colors[x, y]);
                }
            }

            System.Console.SetCursorPosition(0, picker.ConsoleColor_Y + 1);
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
        static void Basic_v3(string img_path, int n, bool use_read = false, bool chaos = false, int chaos_times = 500, int image_width = 237, int image_height = 69)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(image_width, image_height);
            ConsoleColor[,] colors = picker.Colors_Changed_Console_Color();

            Drawer drawer = new Drawer();

            List<int> xl = new List<int>();
            List<int> yl = new List<int>();
            for (int i = 0; i < picker.ConsoleColor_X; i++)
                xl.Add(i);
            for (int i = 0; i < picker.ConsoleColor_Y; i++)
                yl.Add(i);
            Shuffle<int> shuffle1 = new Shuffle<int>();
            shuffle1.Shuffle_List(xl);
            shuffle1.Shuffle_List(yl);

            var xll = Cut_off_List(xl, n);
            var yll = Cut_off_List(yl, n);

            if (use_read == true)
            {
                System.Console.WriteLine("Ready");
                System.Console.Read();
                System.Console.Clear();
            }

            if (chaos == true)
                drawer.Chaos_line(chaos_times, false, 0, picker.ConsoleColor_X, 0, picker.ConsoleColor_Y);

            Shuffle<List<int>> shuffle2 = new Shuffle<List<int>>();
            shuffle2.Shuffle_List(xll);
            shuffle2.Shuffle_List(yll);

            foreach (var itemx1 in xll)
            {
                shuffle1.Shuffle_List(itemx1);
                foreach (var itemy1 in yll)
                {
                    shuffle1.Shuffle_List(itemy1);
                    foreach (var itemx2 in itemx1)
                    {
                        foreach (var itemy2 in itemy1)
                        {
                            drawer.Color_Write(itemx2, itemy2, colors[itemx2, itemy2]);
                        }
                    }
                }
            }

            System.Console.SetCursorPosition(0, picker.ConsoleColor_Y + 1);
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
        static void Basic_v4(string img_path, bool use_read = false, bool chaos = false, int add_chaos_times = 0, int image_width = 237, int image_height = 69)
        {
            RGB_picker picker = new RGB_picker();
            picker.Set_img_path(img_path);
            picker.Set_size(image_width, image_height);
            ConsoleColor[,] colors = picker.Colors_Changed_Console_Color();

            List<Vector2> xylists = new List<Vector2>();
            for (int x = 0; x < picker.ConsoleColor_X; x++)
                for (int y = 0; y < picker.ConsoleColor_Y; y++)
                {
                    xylists.Add(new Vector2(x, y));
                }
            Shuffle<Vector2> shuffle = new Shuffle<Vector2>();
            shuffle.Shuffle_List(xylists);

            Drawer drawer = new Drawer();

            if (use_read == true)
            {
                System.Console.WriteLine("Ready");
                System.Console.Read();
                System.Console.Clear();
            }

            if (chaos == true)
                drawer.Chaos_Write(add_chaos_times, false, 0, picker.ConsoleColor_X, 0, picker.ConsoleColor_Y);

            foreach (var item in xylists)
            {
                drawer.Color_Write((int)item.X, (int)item.Y, colors[(int)item.X, (int)item.Y]);
            }
            System.Console.SetCursorPosition(0, picker.ConsoleColor_Y + 1);
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
        
        static List<List<int>> Cut_off_List(List<int> list, int n)
        {
            List<List<int>> ret = new List<List<int>>();
            List<int> temp;
            int t = (int)(list.Count / n);
            for (int i = 0; i < n - 1; i++)
            {
                temp = new List<int>();
                for (int j = t * i; j < t * (i + 1); j++)
                {
                    temp.Add(list[j]);
                }
                ret.Add(temp);
            }
            temp = new List<int>();
            for (int i = t * (n - 1); i < list.Count; i++)
            {
                temp.Add(list[i]);
            }
            ret.Add(temp);

            return ret;
        }
    }
}
