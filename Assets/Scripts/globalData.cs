using UnityEngine;
using System.Collections;

public static class globalData{

    static int score;
    static int path;
    static string last;
    public static void setScore(int s)
    {
        score = s;
    }
    public static void setPath(int p)
    {
        path = p;
    }
    public static int getScore()
    {
        return score;
    }
    public static int getPath()
    {
        return path;
    }
    public static void setLast(string l)
    {
        last = l;
    }
    public static string getLast()
    {
        return last;
    }
}
