using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using BUSINESS_APPLICATION;
using BUSINESS_APPLICATION.BL;

namespace BUSINESS_APPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {

            creative();
            int choice = HEAD();
            while (true)
            {
                if (choice == 1)
                {
                    Console.Beep();

                    owner_login();
                }
                else if (choice == 2)
                {


                }
                else if (choice == 3)
                {
                    Console.Beep();

                    break;
                }

            }


        }

        static void creative()
        {
            for (int i = 0; i < 5; i++)
            {


                Console.WriteLine("*********************************************************************************************************          ");
                Console.WriteLine("*=======================================================================================================*    ");
                Console.WriteLine("*                                                                                                       *     ");
                Console.WriteLine("*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ * ");
                Console.WriteLine("*                                                                                                       * ");
                Console.WriteLine("*                                                                                                       *         ");
                Console.WriteLine("*                                      WELCOME TO PSL                                                   * ");
                Console.WriteLine("*                                                                                                       * ");
                Console.WriteLine("*                                                                                                       * ");
                Console.WriteLine("*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++* ");
                Console.WriteLine("*                                                                                                       *");
                Console.WriteLine("*=======================================================================================================*     ");
                Console.WriteLine("*********************************************************************************************************          ");
                Console.Beep();
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                else if (i == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                }
                else if (i == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                }
                else if (i == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                else if (i == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
                else if (i == 6)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                }

                Thread.Sleep(110);
                Console.Clear();



            }
        }


        static int HEAD()
        {
            Console.Clear();
            header();
            int option;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(25, 15);
            Console.WriteLine("1.PRESS FOR OWNER");
            Console.SetCursorPosition(25, 16);
            Console.WriteLine("2.PRESS FOR PLAYER");
            Console.SetCursorPosition(25, 17);
            Console.Write("3.PRESS FOR EXIST");
            option = int.Parse(Console.ReadLine());
            return option;


        }

        static void owner_login()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            header();
            Console.ForegroundColor = ConsoleColor.Cyan;

            //string name;
            //string membershiop;
            Owner ob = new Owner();
             
            Console.SetCursorPosition(30, 14);
            Console.Write("ENTER YOUR NAME:");
            ob.name = Console.ReadLine();
            Console.SetCursorPosition(30, 14);
            Console.Write("ENTER YOUR MEMBERSHIOP CODE:");
            ob.membership = Console.ReadLine();
            check_is_valid_owner(ob);

        }

        static void check_is_valid_owner(Owner ob)
        {

            
            string[] file_data = new string[2];
            string path = "D:\\business application files\\owner.txt";
            StreamReader file = new StreamReader(path);
            Console.ForegroundColor = ConsoleColor.Cyan;

            List<string> Owner = new List<string>();
            for (int i = 0; i < 2; i++)
            {
                Owner.Add(file.ReadLine());
            }

            if (Owner[0] == ob.name && Owner[1] == ob.membership)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(1000);
                Console.WriteLine("nice");
                Owner_Manu();
            }
            else
            {
                Console.Clear();
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(30, 15);

                Console.WriteLine("MEMBERSHIP CODE OR USERNAME INCORRECT ");
                Thread.Sleep(1000);

            }







        }

        static void header()
        {
            Console.WriteLine("*********************************************************************************************************          ");
            Console.WriteLine("*=======================================================================================================*    ");
            Console.WriteLine("*                                                                                                       *     ");
            Console.WriteLine("*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ * ");
            Console.WriteLine("*                                                                                                       * ");
            Console.WriteLine("*                                                                                                       *         ");
            Console.WriteLine("*                                      OWNER===========MANU                                             * ");
            Console.WriteLine("*                                                                                                       * ");
            Console.WriteLine("*                                                                                                       * ");
            Console.WriteLine("*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++* ");
            Console.WriteLine("*                                                                                                       *");
            Console.WriteLine("*=======================================================================================================*     ");
            Console.WriteLine("*********************************************************************************************************          ");


        }



        static void Owner_Manu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            header();
            //int option;
            Owner ob = new Owner();
            bool check;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("1.CHOSE PLAYERS");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("2.CREATE OR CHANGE NAME OF YOUR TEAM");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("3.SELECT CPTAIN");
            Console.SetCursorPosition(30, 17);

            Console.WriteLine("4.SHOW PROCESS ");
            Console.SetCursorPosition(30, 18);

            Console.Write("5.CHANGE YOUR PASSWORD OR USERNAME");
            Console.SetCursorPosition(30, 19);
            Console.Write("6.DELETE PLAYER");

            ob.option = int.Parse(Console.ReadLine());
            check = chech_valid_option( ob);
            if (check == true)
            {


                if (ob.option == 1)
                {
                    showplayer();
                    Console.Beep();


                }
                else if (ob.option == 2)
                {
                    Console.Beep();

                    Teamname();
                }
                else if (ob.option == 3)
                {
                    Console.Beep();

                    Select_captain();
                }
                else if (ob.option == 4)
                {
                    Console.Beep();

                    Show_process();
                }
                else if (ob.option == 5)
                {
                    Console.Beep();

                    CHANGE_PASSWORD();
                }
                else if (ob.option == 6)
                {
                    delete_player();
                }


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID INPUT");

                while (check == false)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    header();
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("1.CHOSE PLAYERS");
                    Console.WriteLine("2.CREATE OR CHANGE NAME OF YOUR TEAM");
                    Console.WriteLine("3.SELECT CPTAIN");
                    Console.WriteLine("4.SHOW PROCESS");
                    Console.Write("5.CHANGE YOUR PASSWORD OR USERNAME");
                    ob.option = int.Parse(Console.ReadLine());
                    check = chech_valid_option(ob);
                    if (check == false)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(30, 15);
                        Console.WriteLine("INVALID INPUT");


                    }
                    if (ob.option == 1)
                    {
                        showplayer();

                        Console.Beep();

                    }
                    else if (ob.option == 2)
                    {
                        Console.Beep();

                        Teamname();
                    }
                    else if (ob.option == 3)
                    {
                        Console.Beep();

                                    Select_captain();
                    }
                    else if (ob.option == 4)
                    {
                        Console.Beep();
                        Show_process();
                    }
                    else if (ob.option == 5)
                    {
                        Console.Beep();
                                        CHANGE_PASSWORD();
                    }
                    else if(ob.option==6)
                    {
                        delete_player();
                    }
                
                
                }

            }

            

        }

        static bool chech_valid_option(Owner ob)
        {
            bool flag = false;
            if (ob.option == 1 || ob.option == 2 || ob.option == 3 || ob.option == 4 || ob.option == 5 || ob.option == 6)
            {
                flag = true;

            }

            return flag;




        }

        static void showplayer()
        {
            Console.Clear();
            string path = "D:\\business application files\\players.txt";
            StreamReader file = new StreamReader(path);
            string line;
            int idx = 0;
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("NO__NAME_____COUNTRY__ CATAGEORY ");
            Console.SetCursorPosition(20, 6);

            Console.WriteLine("________________________________ ");

            while ((line = file.ReadLine()) != null)
            {

                idx++;

                Console.SetCursorPosition(20, 6 + idx);

                Console.Write("{0}.{1}", idx, line);
                Console.WriteLine();
            }
            Console.SetCursorPosition(20, idx + 8);
            Console.Write("ENTER THE PLAYER NO FOR SLELECTION:");
            Owner ob=new Owner(); 
            ob.playerno = int.Parse(Console.ReadLine());
            Console.Beep();

            select_this_player(ob);



        }


        static void select_this_player(Owner ob)
        {
            string path = "D:\\business application files\\players.txt";
            StreamReader file = new StreamReader(path);
            string line;
            int idx = 0;
            while ((line = file.ReadLine()) != null)
            {

                idx++;
                if (idx == ob.playerno)
                {
                    string path1 = "D:\\business application files\\owner1.txt";
                    StreamWriter file1 = new StreamWriter(path1, true);
                    file1.WriteLine(line);
                    file1.Flush();
                    file1.Close();
                }

            }
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("PLAYER HAVE BEEN ADDED IN YOUR TEAM");
            Console.Beep();

            Thread.Sleep(2000);
            Owner_Manu();





        }


        static void Show_process()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 8);
            Console.Beep();

            Console.WriteLine("*******************YOUR PROCESS*******************");
            Thread.Sleep(2000);
            Console.Clear();
            Console.SetCursorPosition(30, 3);
            string path = "D:\\business application files\\team_name.txt";
            StreamReader file = new StreamReader(path);
            string line;
            line = file.ReadLine();
            file.Close();

            string path1 = "D:\\business application files\\team_captain.txt";
            StreamReader file1 = new StreamReader(path1);
            string line1;
            line1 = file1.ReadLine();
            file1.Close();

            Console.SetCursorPosition(30, 3);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("YOUR TEAM NAME");
            Console.SetCursorPosition(30, 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---{0}--------------------------------------------------", line);
            Console.SetCursorPosition(30, 5);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("YOUR TEAM CAPTAIN NAME");
            Console.SetCursorPosition(30, 6);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("NAME------COUNTRY--CATAGEORY");
            Console.SetCursorPosition(30, 7);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--{0}------------------------------------------", line1);

            Console.SetCursorPosition(30, 8);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------------------------------------------------");

            Console.SetCursorPosition(30, 9);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------YOUR PLAYER LIST-----------------------");
            int idx3 = 0;

            string path3 = "D:\\business application files\\owner1.txt";
            StreamReader file3 = new StreamReader(path3);
            string line4;
            while ((line4 = file3.ReadLine()) != null)
            {

                idx3++;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(20, 12 + idx3);

                Console.Write("{0}.{1}", idx3, line4);
                Console.WriteLine();

            }
            file3.Close();

            Console.ReadLine();

            Owner_Manu();



        }

        static void Teamname()
        {
            Console.Clear();
            header();
            string path = "D:\\business application files\\team_name.txt";
            StreamReader file = new StreamReader(path);
            string line;
            line=file.ReadLine();


            if (line == null)

            {
                Console.SetCursorPosition(30, 13);
                Console.WriteLine("Your Team Name is NOt Selected Yet");
            }
            else
            {
                Console.SetCursorPosition(30, 13);
                Console.WriteLine("Your Team Name is :{0}", line);
            }
            file.Close();

            Console.SetCursorPosition(30, 14);
            Console.Write("Enter  YOur Team Name For Changening Or Creatining:");
            Owner ob = new Owner();
             ob.Team_name = Console.ReadLine();
            string path1 = "D:\\business application files\\team_name.txt";
            StreamWriter file1 = new StreamWriter(path1);
            file1.WriteLine(ob.Team_name);
            file1.Flush();
            file1.Close();
            Console.Clear();
            Console.SetCursorPosition(30, 14);
            Console.Write("TEAM NAME HAVE BEEN CHANGED:");
            
            Console.ReadLine();
            Owner_Manu();



        }

        static void Select_captain()
        {

            Console.Clear();
            string path = "D:\\business application files\\owner1.txt";
            StreamReader file = new StreamReader(path);
            string line;
            int idx = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 1);
            Console.WriteLine("YOUR TEAM PLAYER");
            Console.SetCursorPosition(20, 4);
            Console.WriteLine("------------------------------");
            Console.SetCursorPosition(20, 3);
            Console.WriteLine("NO--NAME---COUNTRY---CATAGEORY");
            Console.SetCursorPosition(20, 2);
            Console.WriteLine("------------------------------");

            Console.ForegroundColor = ConsoleColor.Red;

            while ((line = file.ReadLine()) != null)
            {

                idx++;

                Console.SetCursorPosition(20, 6 + idx);

                Console.Write("{0}.{1}", idx, line);
                Console.WriteLine();

            }
            file.Close();

            Console.SetCursorPosition(20, idx + 8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ENTER PLAYER NO FOR SELECTING AS A CAPTAIN");
            Console.Beep();

            Owner ob = new Owner();
             ob.captain = int.Parse(Console.ReadLine());

            string path1 = "D:\\business application files\\owner1.txt";
            StreamReader file1 = new StreamReader(path1);
            string line1;
            int idx1 = 0;
            while ((line1 = file1.ReadLine()) != null)
            {
                idx1++;
                if (ob.captain == idx1)
                {
                    string path2 = "D:\\business application files\\team_captain.txt";
                    StreamWriter file2 = new StreamWriter(path2);
                    file2.WriteLine(line1);
                    file2.Flush();
                    file2.Close();
                }
            }
            Console.Clear();

            Console.SetCursorPosition(30, 10);
            Console.Beep();
            Console.WriteLine("SELECTION OF CAPTAIN HAVE BEEN DONE");
            Thread.Sleep(2000);
            Owner_Manu();
        }
        static void CHANGE_PASSWORD()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            header();

            string path = "D:\\business application files\\owner.txt";
            StreamReader file = new StreamReader(path);
            string line;
            line = file.ReadLine();
            string line2 = file.ReadLine();
            file.Close();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("YOUR USER NAME IS:{0}", line);
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("YOUR PASSWORD IS:{0}", line2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("--------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(30, 15);
            Console.Write("ENTER YOUR NEW USERNAME:");
            string username = Console.ReadLine();
            Console.SetCursorPosition(30, 17);
            Console.Write("ENTER YOUR NEW PASSWORD:");
            int PASSWORD = int.Parse(Console.ReadLine());

            string path1 = "D:\\business application files\\owner.txt";
            StreamWriter file1 = new StreamWriter(path1);
            file1.WriteLine(username);
            file1.WriteLine(PASSWORD);
            file1.Flush();
            file1.Close();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("-------------------PASSWORD AND USERNAME HAVE BEEN CHANGED-------------------------------");
            Thread.Sleep(2000);

        }
         static void delete_player()
        {



            Console.Clear();
            string path = "D:\\business application files\\owner1.txt";
            StreamReader file = new StreamReader(path);
            string line;
            int idx = 0;
            List<string> player = new List<string>();
            while ((line = file.ReadLine()) != null)
            {

                idx++;
                Console.SetCursorPosition(20, 6 + idx);
                Console.Write("{0}.{1}", idx, line);
                Console.WriteLine();
                 player.Add(line);
            }
            file.Close();
            Console.SetCursorPosition(20, idx + 8);
            Console.Write("ENTER THE PLAYER NO FOR DELETE:");
            Owner ob = new Owner();
            ob.delete_player = int.Parse(Console.ReadLine());
            player.RemoveAt(ob.delete_player-1);

            StreamWriter file1 = new StreamWriter(path); 
             for(int i=0; i<player.Count; i++)
            {

                file1.WriteLine(player[i]);





            }

            file1.Flush();
            file1.Close();
            Console.Clear();
            Console.SetCursorPosition(20, 15);
            
            Console.WriteLine("PLAYER HAVE BEEN REMOV" +
                "ED");
            Thread.Sleep(2000);
            Owner_Manu();

        }











    }

}
