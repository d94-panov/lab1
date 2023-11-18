using System;

class Program
{
    static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // массив игрового поля с ячейками от 0 до 9
    static int currentPlayer = 1; // по умолчанию первый игрок
    static int cellChoice; // выбор ячейки игроком
    static int gameStatus = 0; // проверка состояния игры (победа, ничья, поражение)

    static void Main(string[] args)
    {
        do
        {
            Console.Clear(); // очистка консоли
            Console.WriteLine("Игрок 1: X и Игрок 2: O");
            Console.WriteLine("\n");
            Console.WriteLine(currentPlayer % 2 == 0 ? "Ход Игрока 2" : "Ход Игрока 1");
            Console.WriteLine("\n");
            DisplayBoard(); // вывод текущего состояния игрового поля

            // проверка на ввод правильной ячейки
            bool validInput = false;
            do
            {
                string input = Console.ReadLine();
                validInput = int.TryParse(input, out cellChoice);

                if (!validInput || cellChoice < 1 || cellChoice > 9 || arr[cellChoice] == 'X' || arr[cellChoice] == 'O')
                {
                    Console.WriteLine("Введите корректное число");
                    validInput = false;
                }
            } while (!validInput);

            // установка символа Х или 0 в выбранной ячейке
            arr[cellChoice] = (currentPlayer % 2 == 0) ? 'O' : 'X';
            currentPlayer++;
            gameStatus = CheckWin(); // проверка выигрышных условий
        } while (gameStatus != 1 && gameStatus != -1);

        Console.Clear();
        DisplayBoard();

        if (gameStatus == 1)
        {
            Console.WriteLine("Игрок {0} побеждает", (currentPlayer % 2) + 1);
        }
        else
        {
            Console.WriteLine("Ничья");
        }
        Console.ReadLine();
    }

    // вывод игрового поля в консоль
    private static void DisplayBoard()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
        Console.WriteLine("     |     |      ");
    }

    // проверка выигрышных условий
    private static int CheckWin() // метод для проверки состояния игры после каждого хода
    {
        // проверка горизонтальных линий
        if (arr[1] == arr[2] && arr[2] == arr[3]) return 1;
        else if (arr[4] == arr[5] && arr[5] == arr[6]) return 1;
        else if (arr[6] == arr[7] && arr[7] == arr[8]) return 1;

        // проверка вертикальных линий
        else if (arr[1] == arr[4] && arr[4] == arr[7]) return 1;
        else if (arr[2] == arr[5] && arr[5] == arr[8]) return 1;
        else if (arr[3] == arr[6] && arr[6] == arr[9]) return 1;

        // проверка диагональных линий
        else if (arr[1] == arr[5] && arr[5] == arr[9]) return 1;
        else if (arr[3] == arr[5] && arr[5] == arr[7]) return 1;

        // проверка на ничью если все ячейки заполнены
        else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9') return -1;

        else // иначе игра продолжается
        {
            return 0;
        }
    }
}
