using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public static GameController controller;

	void Awake()
	{
		if (controller == null)
		{
			DontDestroyOnLoad(gameObject);
			controller = this;
		}
		else if (controller != this)
			Destroy(gameObject);
	}

	public Transform polygonEmitter;
	public Transform PolygonEmitter
	{
		get{return polygonEmitter;}
	}

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}
}
