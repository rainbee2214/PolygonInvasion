using UnityEngine;
using System.Collections;
using System;

public class Grapher : MonoBehaviour 
{
	public enum FunctionOption {
		Linear,
		AbsoluteValue,
		Quadratic,
		Exponential,
		Logarithmic,
		Sine, 
		Cosecant, 
		Cosine, 
		Secant, 
		Tangent, 
		Cotangent, 
		//ArcSine,
		//ArcCosine, 
		ArcTangent,
		SemiCircle,
		SemiCircleBottom
	}
	
	public FunctionOption function;
	
	private delegate float FunctionDelegate (float x);
	private static FunctionDelegate[] functionDelegates =
	{
		Linear,
		AbsoluteValue,
		Quadratic,
		Exponential,
		Logarithmic,
		Sine, 
		Cosecant, 
		Cosine, 
		Secant, 
		Tangent, 
		Cotangent,
		//ArcSine,
		//ArcCosine, 
		ArcTangent,
		SemiCircle,
		SemiCircleBottom
	};
	
	public GameObject point;
	public bool polarCoordinates = false;

	public Color[] colors;
	//[Range(10, 100)]
	int range = 10;
	//[Range(10, 20)]
	public int step = 1;
	
	int numberOfPoints;
	GameObject[] points;
	
	Vector2 origin = new Vector2(0f,0f);
	
	void Start () 
	{
		CreatePool();
		if (colors.Length == 0) 
		{
			colors = new Color[1];
			colors[0] = Color.black;
		}
	}

	void CreatePool()
	{
		origin = transform.position;
		numberOfPoints = range*step;
		//Create points
		points = new GameObject[(int)numberOfPoints];
		Vector2 temp = transform.position;
		int colorStep = numberOfPoints/colors.Length;
		int changeColor = 0;
		Color currentColor = Color.black;
		for (int i = 0; i < numberOfPoints; i++)
		{
			if (i == colorStep)
			{
				if (i >= colors.Length) currentColor = colors[colors.Length -1];
				else currentColor = colors[i];
				changeColor += colorStep;	
			}
			points[i] = Instantiate (point, origin, Quaternion.identity) as GameObject;
			points[i].transform.parent = transform;
			points[i].name = "Point"+i;
			temp.x = origin.x + (i/10f);
			points[i].transform.position = temp;
			points[i].renderer.material.color = currentColor;
			//if (polarCoordinates) points[i].transform.position = SwitchToPolar(temp);
		}
	}

	void Update () 
	{
		FunctionDelegate f = functionDelegates[(int)function];
		for (int i = 0; i < numberOfPoints; i++) 
		{
			Vector3 point = points[i].transform.position;
			point.y =  f(point.x);
			if (polarCoordinates) point = SwitchToPolar(point, i);
			points[i].transform.position = point;
		}
	}

	Vector3 SwitchToPolar(Vector3 point, int i)
	{
		double r = Math.Sqrt((point.x*point.x) + (point.y*point.y));
		point.x = (float)(r*Math.Cos(i));
		point.y = (float)(r*Math.Sin(i));

		if (point.x > 1000f) point.x = 0f;
		if (point.y > 1000f) point.y = 0f;
		//point.x = r : r = sqrt(x^2 + y^2);
		//point.y = theta : tan(theta) = y/x --> theta = arctan(y/x)
		//x = rcos(theta)
		//y = rsin(theta);

		return point;
	}
	
	private static float Linear(float x)
	{
		return x;
	}
	
	private static float AbsoluteValue(float x)
	{
		if (x < 0) return -x;
		else return x;
	}
	
	private static float Quadratic(float x)
	{
		return x*x;
	}
	
	private static float Exponential(float x)
	{
		return Mathf.Exp (x);
	}
	
	private static float Logarithmic(float x)
	{
		if (x == 0f) x+= 0.000001f;
		if ( x < 0f) x *= -1f;
		return Mathf.Log(x);
	}
	
	private static float Sine(float x)
	{
		return Mathf.Sin(Mathf.PI * x + Time.timeSinceLevelLoad);
	}
	
	private static float Cosecant(float x)
	{
		return 1 / (Mathf.Sin(Mathf.PI * x + Time.timeSinceLevelLoad));
	}
	
	private static float Cosine(float x)
	{
		return Mathf.Cos(Mathf.PI * x + Time.timeSinceLevelLoad);
	}
	
	private static float Secant(float x)
	{
		return 1 / (Mathf.Cos(Mathf.PI * x + Time.timeSinceLevelLoad));
	}
	
	private static float Tangent(float x)
	{
		return Mathf.Tan(Mathf.PI * x + Time.timeSinceLevelLoad);
	}
	
	private static float Cotangent(float x)
	{
		return 1 / (Mathf.Tan(Mathf.PI * x + Time.timeSinceLevelLoad));
	}
	
	private static float ArcSine(float x)
	{
		return Mathf.Asin(Mathf.PI * x);
	}
	
	private static float ArcCosine(float x)
	{
		return Mathf.Acos(Mathf.PI * x);
	}
	
	private static float ArcTangent(float x)
	{
		return Mathf.Atan(Mathf.PI * x);
	}
	
	private static float SemiCircle(float x)
	{
		return Mathf.Sqrt(1 - x*x);
	}
	
	private static float SemiCircleBottom(float x)
	{
		return -Mathf.Sqrt(1 - x*x);
	}
}

