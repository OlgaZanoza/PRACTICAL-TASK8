/*
Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

Console.Clear();
Console.WriteLine("Ввести размер массива");
int m = InputNumbers("Ввести m: ");
int n = InputNumbers("Ввести n: ");
int range = InputNumbers("Ввести диапазон: от 1 до ");
int[,] array = new int[m, n];
CreateArray(array);
WriteArray(array);
int minSumLine = 0;
int sumLine = SumLineElements(array, 0);
for (int i = 1; i < array.GetLength(0); i++)
{
  int tempSumLine = SumLineElements(array, i);
  if (sumLine > tempSumLine)
  {
    sumLine = tempSumLine;
    minSumLine = i;
  }
}

Console.WriteLine($"\n{minSumLine+1} - номер строки с наименьшей суммой ({sumLine}) элементов ");
int SumLineElements(int[,] array, int i)
{
  int sumLine = array[i,0];
  for (int j = 1; j < array.GetLength(1); j++)
  {
    sumLine += array[i,j];
  }
  return sumLine;
}

int InputNumbers(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

void CreateArray(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      array[i, j] = new Random().Next(range);
    }
  }
}

void WriteArray (int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      Console.Write(array[i,j] + " ");
    }
    Console.WriteLine();
  }
}



/*
Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

Console.Clear();
Console.WriteLine("Ввести размер массива");
int lengthM = 4;
int lengthN = 4;

var randomArray = GetFillArray(lengthM, lengthN);
var arraySpiral = GetArray(lengthM, lengthN, randomArray.number, randomArray.arrayNumber);

int[,] spiral = SpiralCentre(lengthM, lengthN, arraySpiral.num, arraySpiral.arrayNum);
PrintArray(spiral);

(int[,] arrayNumber, int number) GetFillArray(int m, int n)
{
    int[,] array = new int[m, n];
    int number = 1;
    for (int i = 0; i < n; i++)
    {
        array[0, i] = number;
        number++;
    }
    for (int j = 1; j < m; j++)
    {
        array[j, m - 1] = number;
        number++;
    }
    for (int i = n - 2; i >= 0; i--)
    {
        array[m - 1, i] = number;
        number++;
    }
    for (int j = m - 2; j > 0; j--)
    {
        array[j, 0] = number;
        number++;
    }

    return (array, number);
}
(int[,] arrayNum, int num) GetArray(int m, int n, int number, int[,] array)
{
    int i = 1;
    int j = 1;
    while (number < m * n)
    {
        while (array[i, j + 1] == 0)
        {
            array[i, j] = number;
            number++;
            j++;
        }
        while (array[i + 1, j] == 0)
        {
            array[i, j] = number;
            number++;
            i++;
        }
        while (array[i, j - 1] == 0)
        {
            array[i, j] = number;
            number++;
            j--;
        }
        while (array[i - 1, j] == 0)
        {
            array[i, j] = number;
            number++;
            i--;
        }
    }
    return (array, number);
}

int[,] SpiralCentre(int m, int n, int number, int[,] array)
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (array[i, j] == 0)
            {
                array[i, j] = number;
            }
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i,j] < 10)
            {
                Console.Write($"{array[i, j]}  ");
            }
            else
            {
                Console.Write($"{array[i, j]} ");
            }
        }
        Console.WriteLine();
    }
}



/*
Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

Console.Clear();
Console.WriteLine("Ввести размер массива");
int m = InputNumbers("Ввести m: ");
int n = InputNumbers("Ввести n: ");
int range = InputNumbers("Ввести диапазон: от 1 до ");

int[,] array = new int[m, n];
CreateArray(array);
WriteArray(array);

Console.WriteLine("Упорядочненный массив: ");
OrderArrayLines(array);
WriteArray(array);

void OrderArrayLines(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      for (int k = 0; k < array.GetLength(1) - 1; k++)
      {
        if (array[i, k] < array[i, k + 1])
        {
          int temp = array[i, k + 1];
          array[i, k + 1] = array[i, k];
          array[i, k] = temp;
        }
      }
    }
  }
}

int InputNumbers(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

void CreateArray(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      array[i, j] = new Random().Next(range);
    }
  }
}

void WriteArray(int[,] array)
{
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      Console.Write(array[i, j] + " ");
    }
    Console.WriteLine();
  }
}




/*
Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1
*/

Console.Clear();
Console.WriteLine("Ввести размер массива X  Y  Z:");
int x = InputNumbers("Ввести X: ");
int y = InputNumbers("Ввести Y: ");
int z = InputNumbers("Ввести Z: ");
Console.WriteLine("");

int[,,] array3D = new int[x, y, z];
CreateArray(array3D);
WriteArray(array3D);

int InputNumbers(string input)
{
  Console.Write(input);
  int output = Convert.ToInt32(Console.ReadLine());
  return output;
}

void WriteArray (int[,,] array3D)
{
  for (int i = 0; i < array3D.GetLength(0); i++)
  {
    for (int j = 0; j < array3D.GetLength(1); j++)
    {
      Console.Write($"X({i}) Y({j}) ");
      for (int k = 0; k < array3D.GetLength(2); k++)
      {
        Console.Write( $"Z({k})={array3D[i,j,k]}; ");
      }
      Console.WriteLine();
    }
    Console.WriteLine();
  }
}

void CreateArray(int[,,] array3D)
{
  int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
  int  number;
  for (int i = 0; i < temp.GetLength(0); i++)
  {
    temp[i] = new Random().Next(10, 100);
    number = temp[i];
    if (i >= 1)
    {
      for (int j = 0; j < i; j++)
      {
        while (temp[i] == temp[j])
        {
          temp[i] = new Random().Next(10, 100);
          j = 0;
          number = temp[i];
        }
          number = temp[i];
      }
    }
  }
  int count = 0; 
  for (int x = 0; x < array3D.GetLength(0); x++)
  {
    for (int y = 0; y < array3D.GetLength(1); y++)
    {
      for (int z = 0; z < array3D.GetLength(2); z++)
      {
        array3D[x, y, z] = temp[count];
        count++;
      }
    }
  }
}