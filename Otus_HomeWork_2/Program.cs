
using System.Security.Cryptography.X509Certificates;

namespace Otus_HomeWork_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCheck = false; 
            string name = "";
            string versionBot = "1.0.0";
            string dateRelise = "16.08.2025";

            do 
            {
                if(string.IsNullOrEmpty(name))
                    Console.WriteLine("Добро пожаловать в прогрaмму!");
                else
                    Console.WriteLine("Добро пожаловать в прогрaмму, "+ name + "!");
                Console.WriteLine("доступные комманды:");
                
                if (string.IsNullOrEmpty(name))
                    Console.WriteLine("/start, /help, /info, /exit");
                else
                    Console.WriteLine("/start, /help, /info, /echo, /exit");
                Console.WriteLine("------------------------------------------------");

                var inputData = Console.ReadLine();

                switch (inputData)
                {
                    case "/start":
                        Start(ref name);
                        break;
                    case "/help":
                        Help(name);
                        break;
                    case "/info":
                        Info(versionBot, dateRelise);
                        break;
                    case string s when !string.IsNullOrEmpty(name) && s.StartsWith("/echo ") && !(s.Equals("/echo") || s.Equals("/echo ")):
                        Echo(s.Replace("/echo ",""));
                        break;
                    case "/exit":
                        exitCheck = true;
                        break;
                    default:
                        Console.WriteLine("Не корректная команда или не задан параметр, повторите ввод. Если есть проблеммы, воспользуйтесь /help");
                        Pause();
                        break;
                }
            } while (!exitCheck);
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static void Help(string name)
        {
            string tabul;
            Console.Clear();
            if (!string.IsNullOrEmpty(name))
            {
                tabul = "  ";
                Console.WriteLine(name + ",");
            }
            else 
                tabul = ""; 

            Console.WriteLine(tabul + "Команда /start запускает знакомство, после которого достуны дополнительные команды");
            Console.WriteLine(tabul + "Команда /help  информация по командам (этот текст)");
            if (!string.IsNullOrEmpty(name))
                Console.WriteLine(tabul + "Команда /echo <String>  режим ЭХО. Выводи в консоль <string>. Параметр <string> обязаителен для ввода.");

            Console.WriteLine(tabul + "Команда /info  версия программы и дата релиза");
            Console.WriteLine(tabul + "Команда /exit  выход из программы");
            Pause();
        }

        static void Echo(string stringInput)
        {
            Console.WriteLine(stringInput);
            Pause();
        }

        static void Start(ref string name)
        {
            Console.WriteLine("Давайите познакомимся, укажите как к вам обращаться");
            name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Очень приятно, " + name);
                Pause();
            }
            else 
            {
                Console.Clear() ;
            }    
        }
        static void Info(string versionBotInt, string dateReliseInt)
        {
            Console.WriteLine("Версия программы: " + versionBotInt);
            Console.WriteLine("Версия программы: " + dateReliseInt);
            Pause();
        }
    }
}
