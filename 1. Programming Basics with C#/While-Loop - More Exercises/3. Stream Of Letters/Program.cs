using System;

namespace _3._Stream_Of_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string letter = "";
            string text = "";
            string fullText = "";
            char lett = ' ';
            bool C = false;
            bool O = false;
            bool N = false;
            while(true)
            {
                
                if (C == true && O == true && N == true)
                {
                    text += " ";
                    C = false;
                    O = false;
                    N = false;
                    fullText += text;
                    text = "";
                }
                letter = Console.ReadLine();
                if(letter == "End")
                {
                    break;
                }
                lett = char.Parse(letter);
                if((lett >= 'a' && lett <= 'z') || (lett >= 'A' && lett <= 'Z'))
                {
                    if(lett == 'c' && C == false)
                    {
                        C= true;
                        continue;
                    }
                    else if(lett =='c' && C == true)
                    {
                        text += lett;
                        continue;
                    }
                    if (lett == 'o' && O == false)
                    {
                        O = true;
                        continue;
                    }
                    else if (lett == 'o' && O == true)
                    {
                        text += lett;
                        continue;
                    }
                    if (lett == 'n' && N == false)
                    {
                        N = true;
                        continue;
                    }
                    else if (lett == 'n' && N == true)
                    {
                        text += lett;
                        continue;
                    }


                    text += lett;
                }

                
                
            }
            Console.WriteLine(fullText);
        }
    }
}
