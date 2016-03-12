using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PolygonSpawner : MonoBehaviour
{
    public static PolygonSpawner spawner;

    List<Polygon> polygonPool;
    int poolSize = 50;
    int topOfPool;

    GameObject polygonPrefab;

    Sprite[] polygonSprites;
    public Color[] colors;

    int level = 0; //level is actually level + 1

    int topPolygon; //this will be the nexy polygon type to send
    public bool levelUp;

    public bool sendRound;
    public P.Direction dir = P.Direction.Down;
    public int numberToSend = 10;
    public float sendDelay = 1.25f;

    public float roundDelay = 1f;

    public bool runGame = true;
    bool runningGame = false;

    int roundCount = 0;
    int maxRoundCount = 8;

    void Awake()
    {
        spawner = this;

        polygonSprites = Resources.LoadAll<Sprite>("Sprites/Polygons");
        polygonPrefab = Resources.Load<GameObject>("Prefabs/Polygon");
        CreatePolygonPool();

    }


    void Update()
    {
        if (sendRound)
        {
            sendRound = false;
            StartCoroutine(SendRound(polygonSprites[topPolygon], colors[roundCount], dir, numberToSend, sendDelay));
        }

        if (levelUp)
        {
            levelUp = false;
            LevelUp();
            topPolygon = 0;
        }

        if (runGame && !runningGame) StartCoroutine(SendRounds());
    }

    public void LevelUp()
    {
        level++;
    }

    IEnumerator SendRounds()
    {
        topPolygon = 0;
        roundCount = 0;
        runningGame = true;
        //while (runGame)
        //{
        //    StartCoroutine(SendRound(polygonSprites[topPolygon], colors[roundCount], dir, numberToSend, sendDelay));
        //    yield return new WaitForSeconds(roundDelay + numberToSend*sendDelay);
        //}
        while (runGame)
        {
            yield return StartCoroutine(SendRound(polygonSprites[topPolygon], colors[roundCount], dir, numberToSend, sendDelay));
            while (GameController.controller.paused) yield return null;
            yield return new WaitForSeconds(roundDelay);
        }
        runningGame = false;
        yield return null;
    }

    IEnumerator SendRound(Sprite polygonSprite, Color color, P.Direction dir = P.Direction.Right, int number = 10, float delayBetween = 1.25f)
    {
        Debug.Log("Sending round");
        for (int i = 0; i < number; i++)
        {
            polygonPool[topOfPool].transform.position = transform.position;
            polygonPool[topOfPool].gameObject.SetActive(true);
            polygonPool[topOfPool].Send(polygonSprite, color, transform.position, dir);
            topOfPool++;
            if (topOfPool >= polygonPool.Count) topOfPool = 0;
            yield return new WaitForSeconds(delayBetween);
            while (GameController.controller.paused) yield return null;
        }
        Debug.Log("Done sending");
        roundCount++;
        if (roundCount == maxRoundCount)
        {
            Debug.Log("End of Round!");
            runGame = false;
            roundCount = 0;
        }

        topPolygon++;
        if ((topPolygon > polygonSprites.Length) || (topPolygon > level)) topPolygon = 0;

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
