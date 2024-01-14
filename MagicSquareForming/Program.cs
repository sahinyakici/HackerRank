using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    public static int formingMagicSquare(List<List<int>> s)
    {
        List<int> arr = TransformList(s);
        List<List<int>> possibleCombinations = new List<List<int>>
        {
            new List<int> { 8, 1, 6, 3, 5, 7, 4, 9, 2 },
            new List<int> { 4, 3, 8, 9, 5, 1, 2, 7, 6 },
            new List<int> { 2, 9, 4, 7, 5, 3, 6, 1, 8 },
            new List<int> { 6, 7, 2, 1, 5, 9, 8, 3, 4 },
            new List<int> { 6, 1, 8, 7, 5, 3, 2, 9, 4 },
            new List<int> { 8, 3, 4, 1, 5, 9, 6, 7, 2 },
            new List<int> { 4, 9, 2, 3, 5, 7, 8, 1, 6 },
            new List<int> { 2, 7, 6, 9, 5, 1, 4, 3, 8 }
        };
        int possibleCombinationLength = possibleCombinations.Count,smaller = 99;
        for (int i = 0; i < possibleCombinationLength; i++)
        {
            int value = CalculateValueForCombination(arr,possibleCombinations[i]);
            if (smaller > value)
            {
                smaller = value;
            }
        }

        return smaller;
    }

    private static int CalculateValueForCombination(List<int> arr, List<int> combination)
    {
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            count += Math.Abs(arr[i] - (combination[i]));
        }

        return count;
    }

    private static List<int> TransformList(List<List<int>> nestedList)
    {
        return nestedList.SelectMany(item => item).ToList();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.formingMagicSquare(s);
        Console.WriteLine(result);
    }
}