using UnityEngine;
using System;
using System.Collections;

public class FunctionDelegateExample : MonoBehaviour 
{
    public enum FunctionOption
    {
        Cool,
        Awesome,
        Smart,
        Great
    }

    public FunctionOption function;

    private delegate string FunctionDelegate(string t);
    private static FunctionDelegate[] functionDelegates =
	{
		Cool, 
        Awesome, 
        Smart, 
        Great
	};
	
    void Update()
    {
        FunctionDelegate f = functionDelegates[(int)function];
        string t = "Sarah";
        Debug.Log(f(t));
    }

    public static string Cool(string t)
    {
        return (t+" is cool.");
    }

    public static string Awesome(string t)
    {
        return (t+" is awesome.");
    }

    public static string Smart(string t)
    {
        return (t+" is smart.");
    }

    public static string Great(string t)
    {
        return (t+" is great.");
    }
}
