using System.Reflection.Emit;
using System;
using System.Diagnostics;
using System.Threading;

namespace Потоки
{
    internal class Program
    {
        public static List<Polsovatel> polsovatels = new();

        static void Main(string[] args)
        {   
            Console.WriteLine("Нажми F2");
            ConsoleKeyInfo key = Console.ReadKey();
            for (; key.Key == ConsoleKey.F2; key = Console.ReadKey(), Klavisha(key))
            { 
                Console.WriteLine("Введи имя. После начнется обратный отсчет, твоя задача - печатать текст.");

                string? name = Console.ReadLine();
                int Time = 60;
                Console.Clear();
                string TextRead = "Почему от алкоголя люди кажутся красивее и сексуальнее? Исследование, опубликованное в 2003 году, показало, что мужчины и женщины, употреблявшие умеренное количество алкоголя, находили лица представителей противоположного пола на 25 процентов более привлекательными, чем их трезвые сверстники. На основе этого исследования ученые из Лондонского университета Рохэмпотна выяснили, что алкоголь ухудшает способность воспринимать асимметрию на лицах и снижает предпочтение симметричных лиц перед асимметричными. Ведь красота это что? Симметрия, то есть «правильные» черты лица и фигуры. На способность их распознавать и влияет алкоголь, меняя работу префронтальной коры. А его влияние на лобную долю усиливает наше желание сближаться с другими людьми. Последний гвоздь в крышку гроба: воздействие на вентральный стриатум, который включает импульсивное и нелогичное поведение. Почему это плохо? Ну не то чтобы плохо, скорее неэффективно. Я за то, чтобы любая коммуникация - особенно сексуальная - доставляла всем участникам максимум кайфа. А если вы на утро жалеете о содеянном, или, что ещё хуже, с содроганием смотрите на человека в постели - это уже не максимум. Про секс нужно вспоминать с наслаждением, а не с отвращением. Это если вы вообще его запомните, ведь на гиппокамп, хранилище памяти, алкоголь тоже плохо влияет. Чтобы не случалось всякой фигни, можете соблюдать золотое правило, первый секс с новым партнёром - на трезвую (или хотя бы полутрезвую) голову.";
                string YourText = "";

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(0, 1);
                Console.WriteLine(TextRead);
                Console.WriteLine("Нажми любую клавишу, чтобы начать");
                Console.ReadKey();

                Thread thread = new(x =>
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    int i = 0;
                    Console.SetCursorPosition(0, 1);
                    for (char console_char_text = Console.ReadKey().KeyChar; Time != 0; i++, console_char_text = Console.ReadKey().KeyChar)
                    {
                        if (console_char_text == TextRead[i])
                            YourText += TextRead[i];
                        else
                            i--;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 1);
                        Console.Write(YourText);
                    }
                });

                thread.Start();
                Stopwatch sw = Stopwatch.StartNew();
                while (Time != 0)
                {
                    Time = Convert.ToInt32(60 - sw.ElapsedMilliseconds / 1000);
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(Time);
                    Thread.Sleep(1000);
                }
                Thread.Sleep(10000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Время вышло! ...");
                Polsovatel chel = new(name, Math.Round((double)YourText.Length / 60.0, 2), YourText.Length);
                polsovatels.Add(chel);

                Console.WriteLine("Имя: " + chel.Name + "\nСимволов в секунду: " + chel.Simvol_Sekund + "\nВсего символов: " + chel.Vsego_Simvol);
                Console.WriteLine("Для перехода в топ нажми f1. Для повторного прохождения - f2");
            }
        }
        private static void Klavisha(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.F1)
            {
                Console.WriteLine(Top_Polsovatelei.Name);
                foreach (Polsovatel user in polsovatels)
                {
                    Console.WriteLine("\n" + user.Name + "\n" + user.Simvol_Sekund + "\n" + user.Vsego_Simvol);
                    Console.WriteLine("---------------------");
                }
            }
        }
    } 
}