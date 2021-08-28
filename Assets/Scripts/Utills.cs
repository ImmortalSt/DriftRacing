using UnityEngine;
using System.Collections.Generic;
using System;

public static class Utills
{
    public static float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp;

        temp = b;
        b = a;
        a = temp;
    }
    public static int FindLowestZIndex(Vector3[] massive)
    {
        Vector3 lowest = new Vector3(0, 0, float.MaxValue);
        int result = -1;

        for(int i = 0; i < massive.Length; i++)
        {
            if (massive[i].z < lowest.z)
            {
                lowest = massive[i];
                result = i;
            }
        }
        return result;
    }
    public static float GetSign(float value)
    {
        if (value < 0)
            return -1;
        else
            return 1;
    }
    public static void RemoveLast<T>(this List<T> target)
    {
        if (target.Count != 0)
            target.RemoveAt(target.Count - 1);
    }
    public static Vector2 Rotate(this Vector2 target, float angle)
    {
        angle *= -Mathf.Deg2Rad;
        var cos = Mathf.Cos(angle);
        var sin = Mathf.Sin(angle);
        var newX = target.x * cos - target.y * sin;
        var newY = target.x * sin + target.y * cos;

        return new Vector2(newX, newY);
    }
    public static Vector3 Rotate(this Vector3 target, float angle)
    {
        angle *= -Mathf.Deg2Rad;
        var cos = Mathf.Cos(angle);
        var sin = Mathf.Sin(angle);
        var newX = target.x * cos - target.y * sin;
        var newY = target.x * sin + target.y * cos;

        return new Vector3(newX, 0, newY);
    }
    public static Vector2Int Rotate(this Vector2Int target, float angle)
    {
        angle *= -Mathf.Deg2Rad;
        var cos = Mathf.Cos(angle);
        var sin = Mathf.Sin(angle);
        var newX = target.x * cos - target.y * sin;
        var newY = target.x * sin + target.y * cos;

        return new Vector2Int((int)newX, (int)newY);
    }
    public static bool Contains<T>(this T target, T[] elements) where T : IEquatable<T>
    {
        foreach (var k in elements)
        {
            if (target.Equals(k))
            {
                return true;
            }

        }
        return false;
    }
}
