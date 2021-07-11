using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lesson_4;


class Task1
{
    static void Main(string[] args)
    {
        Execute(10000);
        
    }

    static void Execute(int i)
    {
        var ArraySet = SetDataToArray(i);
        var HashSet = SetDataToHash(i);
        var SearchData = new Data() { Entity = "String 847" };
        var sw1 = HashContains(HashSet, SearchData);
        var sw2 = ArrayContains(ArraySet, SearchData.Entity);
        var result = Print(sw1, sw2);
        Console.WriteLine(result);
    }

    private static string Print(string sw1,string sw2)
    {
        return $"Found in HasSet for {sw1} ms. Found in Array for {sw2} ms";
    }

    private static string HashContains(HashSet<Data> hash, Data search)
    {

        var sw = new Stopwatch();
        sw.Start();
        hash.Contains(search);
        sw.Stop();

        return sw.Elapsed.ToString();

    }

    private static string ArrayContains(string[] array, string search)
    {
        var sw = new Stopwatch();
        sw.Start();
        array.Contains(search);
        sw.Stop();

        return sw.Elapsed.ToString();
    }

    static HashSet<Data> SetDataToHash(int i)
    {
        var hashSet = new HashSet<Data>();
        for (int j = 0; j < i; j++)
        {
            var data = new Data() { Entity = "String " + j };
            hashSet.Add(data);
        }

        return hashSet;
    }

    static string[] SetDataToArray(int i)
    {
        string[] ArrayData = new string[i];

        for (int j = 0; j < i; j++)
        {
            ArrayData[j] = "String " + j;
        }

        return ArrayData;
    }

}
