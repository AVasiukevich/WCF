using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientWCF
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            var factory = new ChannelFactory<IContractProcess>(new BasicHttpBinding(),
                new EndpointAddress(new Uri(@"http://127.0.0.1:60001/IContractProcess")));
            var channel = factory.CreateChannel();

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1.Список всех процессов");
            Console.WriteLine("2.Выбрать процесс по PID");
            Console.WriteLine("3.Запустить процесс");
            Console.WriteLine("4.Оставить процесс");
            Console.WriteLine("5.Показать информацию о потоках");
            Console.WriteLine("6.Показать информацию о модулях");
            var input = Int32.Parse(Console.ReadLine());

            if (input > 0 && input <= 6)
            {
                switch (input)
                {
                    case 1: { Console.WriteLine(channel.ShowAllProcess()); }; break;
                    case 2:
                        {
                            Console.Write("Введите ID процесса: ");
                            Console.WriteLine(channel.ShowSelectedProcess(Int32.Parse(Console.ReadLine())));
                        }; break;
                    case 3:
                        {
                            Console.WriteLine("Введите имя процесса:");
                            var name = Console.ReadLine();
                            Console.WriteLine(channel.StartProcess(name));
                        }; break;
                    case 4:
                        {
                            Console.WriteLine("Введите имя процесса:");
                            var name = Console.ReadLine();
                            Console.WriteLine(channel.CloseProcess(name));
                        }; break;
                    case 5:
                        {
                            Console.Write("Введите имя процесса: ");
                            var name = Console.ReadLine();
                            Console.WriteLine(channel.ShowThreads(name));
                        }; break;
                    case 6:
                        {
                            Console.Write("Введите имя процесса: ");
                            var name = Console.ReadLine();
                            Console.WriteLine(channel.ShowModules(name));
                        }; break;
                    default:
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}

