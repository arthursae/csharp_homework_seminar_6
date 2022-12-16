// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3

void OutputResult(int[] numbers, int counter)
{
    Console.Write("Количество чисел больше нуля в массиве ");
    Console.Write("{0}", string.Join(", ", numbers));
    Console.Write(" -> " + counter);
    Console.WriteLine(); // removes the trailing % symbol in the terminal
}

int CountNumbersAboveZero(int[] numbers)
{
    int counter = 0;
    foreach (int number in numbers) if (number > 0) counter++;
    return counter;
}

int[] CollectUserInputNumbersIntoArray(int numOfElements)
{
    int[] numbers = new int[numOfElements];

    for (int i = 0; i < numOfElements; i++)
    {
        int order = i + 1;
        Console.Write("Введите число " + order + " из " + numOfElements + ": ");
        string userInput = Console.ReadLine();

        if (Int32.TryParse(userInput, out _))
        {
            numbers[i] = Convert.ToInt32(userInput);
        }
        else
        {
            Console.WriteLine("Неправильный тип данных, повторите ввод!");
            return CollectUserInputNumbersIntoArray(numOfElements);
        }
    }
    return numbers;
}

string GetUserInputData(string msg)
{
    Console.Write(msg);
    string userInput = Console.ReadLine();
    return userInput;
}

int GetNumberOfElementsInArray(string msg)
{
    string userInput = GetUserInputData(msg);

    if (Int32.TryParse(userInput, out _))
    {
        int numOfElements = Math.Abs(Convert.ToInt32(userInput));
        return numOfElements > 0 ? numOfElements : GetNumberOfElementsInArray(msg);
    } 
    else
    {
        return GetNumberOfElementsInArray(msg);
    }
}

Console.Clear();
int numOfElements = GetNumberOfElementsInArray("Введите нужное количество элементов в массиве: ");
int[] numbers = CollectUserInputNumbersIntoArray(numOfElements);
int aboveZeroCounter = CountNumbersAboveZero(numbers);
OutputResult(numbers, aboveZeroCounter);
