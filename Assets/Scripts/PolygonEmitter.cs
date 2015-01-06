using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PolygonEmitter : MonoBehaviour 
{
	List<GameObject> polygonPool;
	int poolSize = GameController.POOL_SIZE;
	int currentSize = 20;
	public List<int> currentPolygonIndexes;

	public int frontOfCurrentRound = 0;
	int frontOfPool = 0;

	public bool sendRound;
    public string nextColor = GameController.DEFAULT_COLOR;
    public float nextDelay = GameController.DEFULT_DELAY;
    public float nextVelocity = GameController.DEFAULT_VELOCITY;
    public string nextShape = GameController.DEFAULT_SHAPE;

	void Start () 
	{
		CreatePolygonPool();	
		SendRound();
	}
	
	void FixedUpdate () 
	{
		if (sendRound) SendRound();
	}	

	void SendRound()
	{
        //reset rotation on polygons
		sendRound = false;
		int count = frontOfCurrentRound;
		for (int i = 0; i < currentSize; i++)
		{
            if (count >= poolSize)
            {
                count = 0;
                Debug.Log("Restarting pool");
            }
            SendPolygon(nextShape, nextColor, count, i * nextDelay);
			count++;
		}
		frontOfCurrentRound = count;
	}

	void SendPolygon(string shape, string color, int index, float delay, float velocity = 1f)
	{
		currentPolygonIndexes.Add(index);
		if (index < 10) polygonPool[index].name = "0"+index+"Current";
		else polygonPool[index].name = index+"Current";
		polygonPool[index].transform.parent = transform;
        polygonPool[index].gameObject.SetActive(true);
        Polygon polygon = polygonPool[index].gameObject.GetComponent<Polygon>();
        polygon.SetVelocity(velocity);
        polygon.ConfigurePolygon(shape, "right", color, 0.1f, delay, 100f);
        polygon.UnFreezePolygon();
	}

	public void ResetPolygon(int index)
	{
		currentPolygonIndexes.Remove(index);
		polygonPool[index].name = "Pooled";
		polygonPool[index].transform.parent = transform;
		polygonPool[index].transform.rotation = Quaternion.identity;
		polygonPool[index].gameObject.GetComponent<Polygon>().FreezePolygon();
        polygonPool[index].gameObject.SetActive(false);
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
            polygonPool[i].gameObject.SetActive(false);
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
