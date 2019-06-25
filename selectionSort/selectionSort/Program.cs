using System;
using System.Collections.Generic;
using static System.Console;

namespace selectionSort
{
  class Program
  {
    static void Main(string[] args)
    {
      List<int> numbs = new List<int>();
      for (int i = 5; i>0; i--)
      {
        numbs.Add(i);
      }
      numbs.ForEach(Write);

      WriteLine("\n-----------------");

      WriteLine(numbs);
      int outer = 0;
      int inner = 0;
      for (int current = 0; current < numbs.Count - 1; current++)
      {
        outer++;

        int smallest = current; // smallest = current = 5

        for (int i = current + 1; i < numbs.Count; i++)
        {
          inner++;
          // numbs[i] = 4
          if (numbs[i] < numbs[smallest])
          {
            smallest = i;
          }
        }

        var temp = numbs[current];
        numbs[current] = numbs[smallest];
        numbs[smallest] = temp;
        foreach (var i in numbs)
        {
          Write(i);
        }
        WriteLine("");
        
      }
      WriteLine("outer: {0}", outer);
      WriteLine("inner: {0}", inner);

      ReadLine();
    }
  }
}
