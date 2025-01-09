using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arr) {
        int j = 0, k = 1;
        int minimum = 0;

        foreach (var j in arr.Lenght)
        {
            foreach (var k in arr.Lenght)
            {
                int old;
                if (arr[j] > arr[k])
                {
                    out old = arr[j];
                    arr[j] = arr[k];
                    arr[k] = old;
                }
            }
            minimum++;
        }
        return minimum;
    }

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(arr);

        Console.WriteLine(res);
    }
}
