using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Console.WriteLine("Введите что-нибудь, чтобы закрыть...");
            Console.ReadKey();
        }
        /// <summary>
        /// объединила задания 9.1- 9.3
        /// </summary>
        static void Task1()
        {

            using (var accountA = new BankAccount("123456", 1000m, "Savings"))
            {
                accountA.Deposit(500m);
                Console.WriteLine($"Баланс счета A: {accountA.Balance}");

                using (var accountB = new BankAccount("654321", 2000m, "Checking"))
                {
                    if (accountA.Transfer(accountB, 300m))
                    {
                        Console.WriteLine($"Перевод выполнен. Баланс счета A: {accountA.Balance}");
                        Console.WriteLine($"Баланс счета B: {accountB.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Недостаточно средств.");
                    }
                }
            }
        }
        /// <summary>
        /// Домашнее задание 9.1
        /// </summary>
        static void Task2()
        {
            List<Song> songs = new List<Song>();

            Song song1 = new Song("Jingle Bells", "James Lord Pierpont", null);
            Song song2 = new Song("Last Christmas", "Wham!", song1);
            Song song3 = new Song("All I Want for Christmas Is You", "Mariah Carey", song2);
            Song song4 = new Song("Santa Claus Is Coming to Town", "John Frederick Coots and Haven Gillespie", song3);

            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);
            songs.Add(song4);

            foreach (var song in songs)
            {
                song.PrintInfo();
            }

            if (song1.Equals(song2))
            {
                Console.WriteLine($"Песни {song1.Name} и {song2.Name} одинаковы.");
            }
            else
            {
                Console.WriteLine($"Песни {song1.Name} и {song2.Name} различны.");
            }

            try
            {
                Song mySong = new Song();
                Console.WriteLine("Создание объекта прошло успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка: {ex.Message}");
            }
        }

    }
}
