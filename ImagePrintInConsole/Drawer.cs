using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ImagePrintInConsole
{
    class Drawer
    {
        public void Draw_line(Vector2 dot1, Vector2 dot2)
        {
            if (dot1.X > dot2.X)
            {
                Vector2 temp = dot1;
                dot1 = dot2;
                dot2 = temp;
            }
            if (dot1.X == dot2.X)
            {
                float low_y = dot1.Y;
                float high_y = dot2.Y;
                if (dot1.Y > dot2.Y)
                {
                    low_y = dot2.Y;
                    high_y = dot1.Y;
                }
                for (int i = (int)Math.Round(low_y, 0); i <= (int)Math.Round(high_y, 0); i++)
                {
                    System.Console.SetCursorPosition((int)Math.Round(dot1.X, 0), i);
                    System.Console.WriteLine("*");
                }
            }
            if (dot1.Y == dot2.Y)
            {
                float left_x = dot1.X;
                float right_x = dot2.X;
                if (dot1.X > dot2.X)
                {
                    left_x = dot2.X;
                    right_x = dot1.X;
                }
                for (int i = (int)Math.Round(left_x, 0); i <= (int)Math.Round(right_x, 0); i++)
                {
                    System.Console.SetCursorPosition(i, (int)Math.Round(dot1.Y, 0));
                    System.Console.WriteLine("*");
                }
            }
            if (dot1.X != dot2.X && dot1.Y != dot2.Y)
            {
                float gradient = (dot2.Y - dot1.Y) / (dot2.X - dot1.X);
                float y_intercept = (-gradient) * dot1.X + dot1.Y;
                List<Vector2> dot_lists = new List<Vector2>();
                List<int> delete_list = new List<int>();
                for (float i = dot1.X; i <= dot2.X; i += 0.01f)
                {
                    dot_lists.Add(new Vector2((int)Math.Round(i, 0), (int)Math.Round(gradient * i + y_intercept, 0)));

                }
                for (int i = 0; i < dot_lists.Count - 1; i++)
                {
                    if (gradient > 1 || gradient < -1)
                    {
                        if (dot_lists[i].Y == dot_lists[i + 1].Y)
                            delete_list.Add(i);
                    }
                    else if ((-1 < gradient && gradient < 0) || (0 < gradient && gradient < 1))
                    {
                        if (dot_lists[i].X == dot_lists[i + 1].X)
                            delete_list.Add(i);
                    }
                }
                delete_list.Reverse();
                foreach (var items in delete_list)
                {
                    dot_lists.RemoveAt(items);
                }
                foreach (var items in dot_lists)
                {
                    System.Console.SetCursorPosition((int)items.X, (int)items.Y);
                    System.Console.WriteLine("*");
                }
            }
        }
        public void Chaos_line(int count, Boolean auto_full_screen = false, int x_start = 0, int x_end = 237, int y_start = 0, int y_end = 69)
        {
            Random rand = new Random();
            if (auto_full_screen == true)
            {
                x_end = System.Console.WindowWidth;
                y_end = System.Console.WindowHeight - 1;
            }
            for (int i = 0; i < count; i++)
            {
                Draw_line(new Vector2(rand.Next(x_start, x_end), rand.Next(y_start, y_end)), new Vector2(rand.Next(x_start, x_end), rand.Next(y_start, y_end)));
                switch (i % 16)
                {
                    case 0:
                        System.Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case 1:
                        System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 2:
                        System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 3:
                        System.Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 4:
                        System.Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case 5:
                        System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 6:
                        System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 7:
                        System.Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 8:
                        System.Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case 9:
                        System.Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 10:
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 11:
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 12:
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 13:
                        System.Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 14:
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 15:
                        System.Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.SetCursorPosition(0, y_end);
        }
        public void Chaos_Write(int add_times = 0, Boolean auto_full_screen = false, int x_start = 0, int x_end = 237, int y_start = 0, int y_end = 69)
        {
            Random rand = new Random();
            if (auto_full_screen == true)
            {
                x_end = System.Console.WindowWidth;
                y_end = System.Console.WindowHeight - 1;
            }

            List<Vector2> xylists = new List<Vector2>();
            for (int x = x_start; x < x_end-x_start; x++)
                for (int y = y_start; y < y_end-y_start; y++)
                {
                    xylists.Add(new Vector2(x, y));
                }
            Shuffle<Vector2> shuffle = new Shuffle<Vector2>();
            shuffle.Shuffle_List(xylists);

            for (int i = 0; i < xylists.Count; i++)
            {
                switch (i % 16)
                {
                    case 0:
                        System.Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case 1:
                        System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 2:
                        System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 3:
                        System.Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 4:
                        System.Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case 5:
                        System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 6:
                        System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 7:
                        System.Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 8:
                        System.Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case 9:
                        System.Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 10:
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 11:
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 12:
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 13:
                        System.Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 14:
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 15:
                        System.Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                System.Console.SetCursorPosition((int)xylists[i].X, (int)xylists[i].Y);
                System.Console.Write("*");
            }

            shuffle.Shuffle_List(xylists);
            for (int i = 0; i < add_times; i++)
            {
                switch (i % 16)
                {
                    case 0:
                        System.Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case 1:
                        System.Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 2:
                        System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 3:
                        System.Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 4:
                        System.Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case 5:
                        System.Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 6:
                        System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 7:
                        System.Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 8:
                        System.Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case 9:
                        System.Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 10:
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 11:
                        System.Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 12:
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 13:
                        System.Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 14:
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 15:
                        System.Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                System.Console.SetCursorPosition((int)xylists[i].X, (int)xylists[i].Y);
                System.Console.Write("*");
            }

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.SetCursorPosition(0, y_end);
        }
        public void Color_Write(int x, int y, ConsoleColor color)
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.ForegroundColor = color;
            System.Console.WriteLine("*");
        }
    }
}
