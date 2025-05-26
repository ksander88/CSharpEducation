Console.WriteLine("Добро пожаловать в игру Крестики-Нолики!");
Console.Write("Введите имя первого игрока: ");
string player1 = Console.ReadLine();
Console.Write("Введите имя второго игрока: ");
string player2 = Console.ReadLine();
Console.WriteLine($"Игрок {player1} играет за X, игрок {player2} играет за O");
char[,] playingField = new char[3, 3]
      {
          { ' ', ' ', ' ' },
          { ' ', ' ', ' ' },
          { ' ', ' ', ' ' }
      };
bool isPlayerTurn = true;
while (true)
{
    DrawPlayingField(playingField);
    string currentPlayer = isPlayerTurn ? player1 : player2;
    char symbol = isPlayerTurn ? 'X' : 'O';
    Console.WriteLine($"\nХод игрока {currentPlayer} ({symbol})");
    bool validMove = false;
    while (!validMove)
    {
        Console.Write("Введите номер клетки (1-9): ");
        if (int.TryParse(Console.ReadLine(), out int cellNumber) && cellNumber >= 1 && cellNumber <= 9)
        {
            int row = (cellNumber - 1) / 3;
            int col = (cellNumber - 1) % 3;
            if (playingField[row, col] == ' ')
            {
                playingField[row, col] = symbol;
                validMove = true;
                if (CheckWin(playingField, symbol))
                {
                    DrawPlayingField(playingField);
                    Console.WriteLine($"Игрок {currentPlayer} победил!");
                    return;
                }
                if (IsDraw(playingField))
                {
                    DrawPlayingField(playingField);
                    Console.WriteLine("Ничья!");
                    return;
                }

                isPlayerTurn = !isPlayerTurn;
            }
            else
            {
                Console.WriteLine("Клетка уже занята!");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод. Введите число от 1 до 9.");
        }
    }
}

static void DrawPlayingField(char[,] playingField)
{
    Console.WriteLine("\nИгровое поле:");
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($" {playingField[i, 0]} | {playingField[i, 1]} | {playingField[i, 2]} ");
        if (i < 2) Console.WriteLine("-----------");
    }
}

static bool CheckWin(char[,] field, char symbol)
{
    for (int i = 0; i < 3; i++)
    {
        if ((field[i, 0] == symbol && field[i, 1] == symbol && field[i, 2] == symbol) ||
            (field[0, i] == symbol && field[1, i] == symbol && field[2, i] == symbol))
            return true;
    }

    if ((field[0, 0] == symbol && field[1, 1] == symbol && field[2, 2] == symbol) ||
        (field[0, 2] == symbol && field[1, 1] == symbol && field[2, 0] == symbol))
        return true;

    return false;
}

static bool IsDraw(char[,] field)
{
    foreach (char cell in field)
    {
        if (cell == ' ')
            return false;
    }
    return true;
}