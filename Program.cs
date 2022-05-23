using System;

namespace matrix_rotation
{
  class Program
  {
    static void Main(string[] args)
    {
      int rotations = 1;
      int inputArrayWidth = 12;
      int inputArrayHeight = 7;

      int[,] inputArray = Write2DArray(inputArrayHeight, inputArrayWidth);

      Print2DArray(inputArray, "Input");
      
      int rotationAmounts = rotations % 4;
      
      int[,] outputArray = inputArray;

      switch(rotationAmounts) {
        case 0:
          // Full rotation(s) will always return the starting array
        break;
        case 1:
        case 2:
        case 3:

          for(int i = rotationAmounts; i > 0; i--)
          {
            outputArray = Rotate90Degrees(outputArray);
          }
          
          break;
        default:
        Console.WriteLine("How?");
        break;
      }

      Print2DArray(outputArray, "Output");
    }

    public static int[,] Rotate90Degrees(int[,] array) {

      int inputArrayWidth = array.GetLength(1);
      int inputArrayHeight = array.GetLength(0);

      int outputArrayWidth = inputArrayWidth;
      int outputArrayHeight = inputArrayHeight;

      // if the array is not symmetrical then we will have to flip the width and height when we rotate 90 degrees
      if (outputArrayWidth != outputArrayHeight) {
        outputArrayWidth = inputArrayHeight;
        outputArrayHeight = inputArrayWidth;
      }

      int[,] outputArray = new int[outputArrayHeight, outputArrayWidth];
      int[,] tempArray = new int[outputArrayHeight, outputArrayWidth];;

      // Diagonally flip the array
      for(int i = 0; i < inputArrayHeight; i++) 
      {
        for(int j = 0; j < inputArrayWidth; j++)
        {
          tempArray[j, i] = array[i, j];
        }
      }

      // Flip the array on the y axis
      for(int i = 0; i < outputArrayHeight; i++) 
      {
        for(int j = 0; j < outputArrayWidth; j++)
        {
          outputArray[i, j] = tempArray[i, outputArrayWidth - 1 - j];
        }
      }

      return outputArray;
    }

    public static int[,] Write2DArray(int arrayWidth, int arrayHeight) {

      int [,] array = new int[arrayWidth, arrayHeight];

      int count = 1;

      for (int i = 0; i < arrayWidth; i++)
      {
        for (int j = 0; j < arrayHeight; j++)
        {
          array[i, j] = count;
          count++;
        }
      }

      return array;
    }

    public static void Print2DArray(int [,] array, string title)
    {
      Console.WriteLine(title);

      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
        {
          Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
      }
    }
  }
}
