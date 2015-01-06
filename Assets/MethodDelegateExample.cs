using UnityEngine;
using System;
using System.Collections;

//Named separately
public class MethodDelegateExample : MonoBehaviour 
{
    public enum Method
    {
        Cool,
        Awesome,
        Smart,
        Great
    }

    public Method method;

    private delegate string MethodDelegate(string t);
    private static MethodDelegate[] methodDelegates =
	{
		Cool, 
        Awesome, 
        Smart, 
        Great
	};

    MethodDelegate m;
    void Update()
    {
        m = methodDelegates[(int)method];
        string t = "Sarah";
        Debug.Log(m(t));
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
