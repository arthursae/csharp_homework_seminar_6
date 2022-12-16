// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

void OutputIntersectionPointCoordinates(double[] intersectionPoint)
{
    Console.Write("Точка пересечения двух прямых: ");
    Console.Write("[{0}]", string.Join(", ", intersectionPoint));
    Console.WriteLine(); // removes the trailing % symbol in the terminal
}

double[] FindIntersectionPoint(double[,] linearFunctions)
{
    double[] intersectionPointXY = new double[2];
    double b1 = linearFunctions[0,0];
    double k1 = linearFunctions[0,1];
    double b2 = linearFunctions[1,0];
    double k2 = linearFunctions[1,1];
    double x = (b2 - b1) / (k1 - k2); // NOTE: (k1 - k2) cannot be equal 0, check this condition before calling this method!
    intersectionPointXY[0] = x;
    double y = k1 * x + b1;
    intersectionPointXY[1] = y;
    return intersectionPointXY;
}

bool IsParallel(double[,] linearFunctions)
{
    double k1 = linearFunctions[0,1];
    double k2 = linearFunctions[1,1];
    return (k1 - k2 == 0);
}

double[,] GetSlopeAndYInterceptData()
{
    double[,] linearFunctions = new double[2,2];

    for (int i = 0; i < 2; i++)
    {
        int order = i + 1;

        for (int j = 0; j < 2; j++)
        {
            string id = (j == 0) ? "b" : "k";
            Console.Write("Введите коэффициент " + id + order + " для " + order + "-й прямой: ");
            string userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out _))
            {
                linearFunctions[i, j] = Convert.ToInt32(userInput);
            }
            else
            {
                Console.WriteLine("Неправильный тип данных, повторите ввод!");
                return GetSlopeAndYInterceptData();
            }
        }
    }

    return linearFunctions;
}

Console.Clear();
double[,] linearFunctions = new double[2,2];
linearFunctions = GetSlopeAndYInterceptData();
if (!IsParallel(linearFunctions))
{
    double[] intersectionPoint = new double[2];
    intersectionPoint = FindIntersectionPoint(linearFunctions);
    OutputIntersectionPointCoordinates(intersectionPoint);
}
else
{
    Console.WriteLine("Прямые не пересекаются");
}
