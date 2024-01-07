using System;
using System.Collections.Generic;

public enum ElementEnum
{
    Metal = 0, 
    Wood = 1,
    Water = 2,
    Fire = 3,
    Earth = 4,
    Wind = 5,
    Light = 6, 
    Dark = 7, 
    Space = 8, 
    Time = 9, 
    Spirit = 10
}
public class ElementHelper
{
    public static int ElementCount = 11;
    public static string GetElementString(List<ElementEnum> list) {
        var sList = new int[ElementCount];
        foreach (ElementEnum element in list) {
            sList[(int)element] += 1;
        }
        var result = "";
        foreach(int s in sList) {
            result += s;
        }
        return result;
    }

    public static List<ElementEnum> GetElementList(string eneryString)
    {
        var list = new List<ElementEnum>();
        var sList = eneryString.Split("");
        for (int i = 0; i < sList.Length; i++)
        {
            ElementEnum element = (ElementEnum) i;
            var size = int.Parse(sList[i]);
            while(size > 0)
            {
                list.Add(element);
                size--;
            }
        }
        return list;
    }

    public static bool RemoveElemens(string origin, string target, out string result)
    {
        result = "";
        if (origin.Length != target.Length) return false;
        for (int i = 0; i < origin.Length; i++)
        {
            if (origin[i] < target[i]) return false;
            result += Math.Max(0, (origin[i] - target[i]));
        }
        return true;
    }

    public static bool AddElements(string origin, string target, out string result)
    {
        result = "";
        if (origin.Length != target.Length) return false;
        for (int i = 0; i < origin.Length; i++)
        {
            result += Math.Min(63, (origin[i] + target[i]));
        }
        return true;
    }
}
