using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using EZInput;
using GAME.BL;
namespace GAME.BL
{   
    class Program
    {


        static int[] bulletX = new int[100];
        static int[] bulletY = new int[100];
        static int[] bulletHealth = new int[100];
        static int bulletcount = 0;
        static bool[] isbulletactive = new bool[100];
        static int player_health = 4;
        static void Main(string[] args)
        {
            
            int[,] hero = {
                             { 47, 0,92,16,0,0},
                             { 0,2,0,17,124,22}
            };
            int[] enemy = {17,2,16};

            Cordinates ob = new Cordinates();
            ecordinates obe1 = new ecordinates();
            char[,] maze = new char[25, 77];
            ob.brow_x = 14;
            ob.brow_y = 13;
            obe1.enemy1x = 20;
            obe1.enemy1y = 10;
            readData(maze);
            printMaze(maze);
            printHero(ob,hero);
            print_e(enemy,obe1);
            string enemy_direction = "left";
            bool gamevariable = true;
           
            while (gamevariable)
            {
                show_player_health();
                Thread.Sleep(90);
                //printScore();
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                   moveup(maze, ob, hero);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    //           moveDown(maze, ref bro_x, ref bro_y);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveleft(maze, ob, hero);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveright(maze, ob ,hero);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                //    generate_bullet(ref bro_x, ref bro_y);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    generate_bullet(ob);
                }

                check_move_down(ob, hero, maze);
                move_enemy(ob,maze, enemy, obe1, ref enemy_direction);
                movebullet(maze,enemy,obe1);
                check_collission(ref enemy_direction,ob,obe1);
        //        check_score();
                Thread.Sleep(100);
            
            
            
            }

        }
        
        static void show_player_health()
        {
            Console.SetCursorPosition(80, 3);
            Console.WriteLine("PLAYER HEATH:{0}",player_health);


        }
        static void check_collission( ref string  enemy_direction,Cordinates ob,ecordinates obe1)
        {
            if (enemy_direction == "left")
            {
                if (obe1.enemy1x == ob.brow_x + 3 && obe1.enemy1y == ob.brow_y + 1)
                {
                    player_health--;
                    enemy_direction = "right";
                }

            }
            else if (enemy_direction == "right")
            {
                if (obe1.enemy1x == ob.brow_x - 3 && obe1.enemy1y == ob.brow_y + 1)
                {
                    player_health--;
                    enemy_direction = "left";
                }

            }
        }
        static void readData(char[,] maze)
        {
            StreamReader fp = new StreamReader("D:\\business application files\\maze.txt");
            string record;

            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {

                for (int x = 0; x < 77; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;


            }

            fp.Close();
        }
        static void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void printHero(Cordinates ob, int[,] hero)
        {
            Console.SetCursorPosition(ob.brow_x, ob.brow_y);
            Console.Write(" ");
            Console.Write((char)hero[1, 1]);
            Console.SetCursorPosition(ob.brow_x, ob.brow_y + 1);
            Console.Write((char)hero[1, 3]);
            Console.Write((char)hero[1, 4]);
            Console.Write((char)hero[0, 3]);
            Console.SetCursorPosition(ob.brow_x, ob.brow_y + 2);
            Console.Write(" ");
            Console.Write((char)hero[1, 5]);


        }
        static void eraseHero(Cordinates ob)
        {
            Console.SetCursorPosition(ob.brow_x, ob.brow_y);
            Console.Write(" ");
            Console.SetCursorPosition(ob.brow_x + 1, ob.brow_y);
            Console.Write(" ");
            Console.SetCursorPosition(ob.brow_x, ob.brow_y + 1);
            Console.Write(" ");
            Console.SetCursorPosition(ob.brow_x + 1,ob.brow_y + 1) ;
            Console.Write(" ");
            Console.SetCursorPosition(ob.brow_x + 2, ob.brow_y + 1);
            Console.Write(" ");
            Console.SetCursorPosition(ob.brow_x + 1, ob.brow_y + 2);
            Console.Write(" ");



        }

        static void moveup(char[,] maze, Cordinates ob, int[,] hero)
        {

            int maze_x = ob.brow_y;
            int maze_y = ob.brow_x;
            //Console.SetCursorPosition(bro_x,bro_y-4);
            //Console.WriteLine("d") ;
            if (maze[maze_x - 1, maze_y] == '%')
            {
                Console.SetCursorPosition(ob.brow_x, ob.brow_y);
                eraseHero(ob);
                ob.brow_y = ob.brow_y - 4;
                printHero(ob, hero);

                //   Console.SetCursorPosition(bro_x, bro_y);

            }

        }
        static void moveleft(char[,] maze,Cordinates ob, int[,] hero)
        {

            int maze_x = ob.brow_y;
            int maze_y =ob.brow_x;
            if (maze[maze_x, maze_y - 1] == ' ')
            {
                Console.SetCursorPosition(ob.brow_x, ob.brow_y);
                eraseHero(ob);
                ob.brow_x = ob.brow_x - 1;
                printHero(ob, hero);

                //   Console.SetCursorPosition(bro_x, bro_y);



            }
        }

        static void moveright(char[,] maze,  Cordinates ob, int[,] hero)
        {
            int maze_x = ob.brow_y;
            int maze_y = ob.brow_x;
            if (maze[maze_x, maze_y + 3] == ' ')
            {
                Console.SetCursorPosition(ob.brow_x, ob.brow_y);
                eraseHero(ob);
                ob.brow_x = ob.brow_x + 1;
                printHero(ob, hero);

                //   Console.SetCursorPosition(bro_x, bro_y);

            }



        }
        static void check_move_down(Cordinates ob, int[,] hero, char[,] maze)
        {

            int maze_x = ob.brow_y;
            int maze_y = ob.brow_x;
            if (maze[maze_x + 3, maze_y] == ' ')
            {
                Console.SetCursorPosition(ob.brow_x, ob.brow_y);
                eraseHero(ob);
                ob.brow_y = ob.brow_y + 1;
                printHero(ob, hero);

                //   Console.SetCursorPosition(bro_x, bro_y);

            }

        }
        static void erase_e(int[] enemy, ecordinates obe1)
        {
            Console.SetCursorPosition(obe1.enemy1x, obe1.enemy1y);
            Console.Write(" ");
            Console.Write(" ");
            Console.Write(" ");


        }

        static void print_e(int[] enemy, ecordinates obe1)
        {
            char ch = (char)enemy[0];
            char ch1 = (char)enemy[1];
            char ch2 = (char)enemy[2];

            Console.SetCursorPosition(obe1.enemy1x, obe1.enemy1y);
            Console.WriteLine(ch);
            Console.SetCursorPosition(obe1.enemy1x + 1, obe1.enemy1y);
            Console.WriteLine(ch1);
            Console.SetCursorPosition(obe1.enemy1x + 2, obe1.enemy1y);
            Console.WriteLine(ch2);


        }
        static void move_enemy(Cordinates ob, char[,] maze, int[] enemy, ecordinates obe1, ref string enemy_direction)
        {
            

            int maze_x = obe1.enemy1y;
            int maze_y = obe1.enemy1x;

            if (enemy_direction == "left")
            {
                if (maze[maze_x, maze_y - 1] == ' ')
                {

                    Console.SetCursorPosition(obe1.enemy1x, obe1.enemy1y);
                    erase_e(enemy, obe1);

                    obe1.enemy1x =obe1.enemy1x  - 1;
                    Console.SetCursorPosition(obe1.enemy1x,obe1.enemy1y);
                    print_e(enemy,obe1);

                }
                else if ( obe1.enemy1x== ob.brow_x+3 && obe1.enemy1y==ob.brow_y+1)
                {
                    Console.ReadLine();
                    enemy_direction = "right";
                } 
                else
                {

                    //enemy_healt--;
                    enemy_direction = "right";

                }



            }
            else
            {

                if (maze[maze_x, maze_y + 3] == ' ')
                {
                    Console.SetCursorPosition(obe1.enemy1x,obe1.enemy1y);
                    erase_e(enemy,obe1);

                    obe1.enemy1x =obe1.enemy1x+1;
                    Console.SetCursorPosition(obe1.enemy1x, obe1.enemy1y);
                    print_e(enemy,obe1);

                }
                else if (maze[maze_x, maze_y + 1] == '|')
                {
                    enemy_direction = "left";
                    Console.SetCursorPosition(obe1.enemy1x, obe1.enemy1y);
                    print_e(enemy,obe1);

                }
                
                else
                {
                    Console.SetCursorPosition(obe1.enemy1x, obe1.enemy1y);
                    print_e(enemy, obe1);

                    //        enemy_healt--;
                    enemy_direction = "left";

                }

            }



         }
        static void generate_bullet(Cordinates ob)
        {
            bulletX[bulletcount] = ob.brow_x + 4;
            bulletY[bulletcount] = ob.brow_y + 1;
            bulletHealth[bulletcount] = 4;
            isbulletactive[bulletcount] = true;
            Console.SetCursorPosition(ob.brow_x + 4, ob.brow_y + 1);
            Console.Write("*");
            bulletcount++;

        }
        static void makebulletinactive(int x)
        {

            isbulletactive[x] = false;
        }

        static void erasebullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");

        }
        static void prinbullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("*");


        }
        static void movebullet(char[,] maze,int[]enemy,ecordinates obe1)
        {
            for (int x = 0; x < bulletcount; x++)
            {

                int maze_x = bulletY[x];
                int maze_y = bulletX[x];
                 //HashSet<(int x, int y)> emptyCells = new HashSet<(int x, int y)>();
                if (maze[bulletY[x] , bulletX[x]+1] == ' ')
                {
                    bulletHealth[x]--;
                    erasebullet(bulletX[x], bulletY[x]);
                    bulletX[x] = bulletX[x] + 1;
                    prinbullet(bulletX[x], bulletY[x]);
                }

                else if (maze[bulletY[x] , bulletX[x]+1] == '%' || maze[bulletY[x] , bulletX[x] + 1] == '|' || maze[bulletY[x] , bulletX[x] + 1] == '*')
                {

                    erasebullet(bulletX[x], bulletY[x]);
                    makebulletinactive(x);

                }
                else if (bulletY[x] == obe1.enemy1y|| bulletX[x] == obe1.enemy1x)
                {
                    erasebullet(bulletX[x], bulletY[x]);
                    makebulletinactive(x);

                }
                




            }
        }







    }
}
