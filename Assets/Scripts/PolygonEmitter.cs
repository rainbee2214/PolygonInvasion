using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PolygonEmitter : MonoBehaviour 
{
	List<GameObject> polygonPool;
	int poolSize = 80;
	int frontOfPool;

	public List<int> currentPolygonIndexes;
	int currentSize = 20;
	public int frontOfCurrentRound;

	public bool sendRound;

	void Start () 
	{
		CreatePolygonPool();	
		frontOfCurrentRound = 0;
		frontOfPool = 0;
		SendRound();
	}
	
	void Update () 
	{
		if (sendRound) SendRound();
	}	

	void SendRound()
	{
		sendRound = false;
		int count = frontOfCurrentRound;
		for (int i = 0; i < currentSize; i++)
		{
			if (count >= poolSize) count = 0;
			SendPolygon(count, i*0.25f);
			count++;
		}
		frontOfCurrentRound = count;
	}

	void SendPolygon(int index, float delay)
	{
		currentPolygonIndexes.Add(index);
		if (index < 10) polygonPool[index].name = "0"+index+"Current";
		else polygonPool[index].name = index+"Current";
		polygonPool[index].transform.parent = transform;
		polygonPool[index].gameObject.GetComponent<Polygon>().ConfigurePolygon("triangle", "right", "red", 0.1f, delay, 100f);
		polygonPool[index].gameObject.GetComponent<Polygon>().UnFreezePolygon();
	}

	public void ResetPolygon(int index)
	{
		currentPolygonIndexes.Remove(index);
		polygonPool[index].name = "Pooled";
		polygonPool[index].transform.parent = transform;
		polygonPool[index].transform.rotation = Quaternion.identity;
		polygonPool[index].gameObject.GetComponent<Polygon>().FreezePolygon();
	}

	public Transform GetFrontPolygon()
	{
		if (currentPolygonIndexes.Count == 0) return null;
		return polygonPool[currentPolygonIndexes[0]].transform;
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
