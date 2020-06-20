using System.Collections;
using System.Collections.Generic;


public static class DataStorage
{
    private static List<int> FigurePool = new List<int>();

   public static void AddValue(int Val)
    {
        FigurePool.Add(Val);
    }

    public static void ClearValue()
    {
        FigurePool.Clear();
    }
    public static List<int> GetValues()
    {
        return FigurePool;
    }

    public static bool IsNull()
    {
        if (FigurePool.Count == 0)
            return true;
        return false;
    }


}
