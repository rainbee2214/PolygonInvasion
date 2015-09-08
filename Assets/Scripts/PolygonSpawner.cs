using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PolygonSpawner : MonoBehaviour 
{
	List<Polygon> polygonPool;
	int poolSize = 50;
    int topOfPool;

    GameObject polygonPrefab;

    Sprite[] polygonSprites;
    public Color[] colors;

	void Awake () 
	{
        polygonSprites = Resources.LoadAll<Sprite>("Sprites/Polygons");
        polygonPrefab = Resources.Load<GameObject>("Prefabs/Polygon");
		CreatePolygonPool();	
	}
   
    public bool sendRound;
    public P.Direction dir = P.Direction.Down;
    void Update()
    {
        if (sendRound)
        {
            sendRound = false;
            StartCoroutine(SendRound(polygonSprites[Random.Range(0, polygonSprites.Length)], colors[Random.Range(0, colors.Length)], dir));
        }

    }

    IEnumerator SendRound(Sprite polygonSprite, Color color, P.Direction dir = P.Direction.Right,int number = 10, float delayBetween = 1.25f)
	{
        Debug.Log("Sending round");
        for (int i = 0; i < number; i++)
        {
            polygonPool[topOfPool].transform.position = transform.position;
            polygonPool[topOfPool].gameObject.SetActive(true);
            polygonPool[topOfPool].Send(polygonSprite, color, transform.position,dir);
            topOfPool++;
            if (topOfPool >= polygonPool.Count) topOfPool = 0;
            yield return new WaitForSeconds(delayBetween);
        }
        Debug.Log("Done sending");
        yield return null;
	}




	void CreatePolygonPool()
	{
		polygonPool = new List<Polygon>();
        for (int i = 0; i < poolSize; i++)
        {
            polygonPool.Add(Instantiate<GameObject>(polygonPrefab).GetComponent<Polygon>());
            polygonPool[i].name = "Polygon" + i;
            polygonPool[i].transform.SetParent(transform);
            polygonPool[i].gameObject.SetActive(false);
        }
    }
}
