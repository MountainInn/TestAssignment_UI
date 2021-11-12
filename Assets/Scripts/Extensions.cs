using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;
using UnityEngine.EventSystems;

static public class ListExtensions
{
    static public T GetRandom<T>(this List<T> list)
    {
        int id = UnityEngine.Random.Range(0, list.Count);
        return list[id];
    }

    static public T ExtractRandom<T>(this List<T> list)
    {
        int id = UnityEngine.Random.Range(0, list.Count);
        T r = list[id];
        list.RemoveAt(id);
        return r;
    }
}
