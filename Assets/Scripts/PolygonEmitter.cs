using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PolygonEmitter : MonoBehaviour 
{
	List<GameObject> polygonPool;
	int poolSize = 80;

	void Start () 
	{
		CreatePolygonPool();	
	}
	
	void Update () 
	{
		
	}	

	void CreatePolygonPool()
	{
		polygonPool = new List<GameObject>();
		for (int i = 0; i < poolSize; i++)
		{
			polygonPool.Add(Instantiate(Resources.Load("Prefabs/Polygon", typeof(GameObject))) as GameObject);
		}
		for (int i = 0; i < poolSize; i++)
		{
			polygonPool[i].transform.parent = transform;
			polygonPool[i].gameObject.name = "Polygon"+i;
			polygonPool[i].gameObject.GetComponent<Polygon>().ConfigurePolygon(i*0.25f);
			polygonPool[i].gameObject.GetComponent<Polygon>().UnFreezePolygon();
		}
		int index = 0;
		for (int i = 0; i < poolSize; i++)
		{
			if (i%10 == 0 && i != 0) index++;
			if (index >= polygonPool[i].gameObject.GetComponent<Polygon>().materials.Length) index = 0;
			polygonPool[i].gameObject.GetComponent<Polygon>().SetMaterial(index);
		}
	}
}
