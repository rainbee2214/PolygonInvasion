using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PolygonEmitter : MonoBehaviour 
{
	List<GameObject> polygonPool;
	int poolSize = 80;

	public List<GameObject> currentPolygons;
	int currentSize = 20;

	public bool sendRound;

	void Start () 
	{
		CreatePolygonPool();	
		SendRound();
	}
	
	void Update () 
	{
		if (sendRound) SendRound();
		Debug.Log(GetFrontPolygon());
	}	

	void SendRound()
	{
		sendRound = false;
		for (int i = 0; i < currentSize; i++)
		{
			if (i < polygonPool.Count)
			{
				currentPolygons.Add(polygonPool[i]);
				polygonPool.RemoveAt(i);
			}
		}
		for (int i = 0; i < currentPolygons.Count; i++)
		{
			currentPolygons[i].name = (i+"Current");
			currentPolygons[i].gameObject.GetComponent<Polygon>().UnFreezePolygon();
		}
	}

	public void PopPolygon(int index)
	{
		currentPolygons[index].gameObject.GetComponent<Polygon>().ResetPolygon();
		polygonPool.Add(currentPolygons[index]);
		currentPolygons.RemoveAt(index);
		polygonPool[polygonPool.Count - 1].name = (polygonPool.Count+"");
	}

	public Transform GetFrontPolygon()
	{
		return currentPolygons[0].transform;
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
			polygonPool[i].gameObject.GetComponent<Polygon>().FreezePolygon();
			polygonPool[i].name = i+"Pooled";
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
