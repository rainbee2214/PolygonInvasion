using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	public static GameController controller;
	public static Vector2 OUT_OF_VIEW = new Vector2(-40f, -15f);
    public static int POOL_SIZE = 80;

    public static string DEFAULT_COLOR = "Red";
    public static string DEFAULT_SHAPE = "Triangle";
    public static float DEFULT_DELAY = 0.25f;
    public static float DEFAULT_VELOCITY = 1f;

	public List<GameObject> bulletPool;
	public int poolSize = 10;
	public int frontOfPool;

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

    // add currentColor, currentDelay, and currentVelocity
    //**These will change each time a round is sent
    //Add method to setup round?

    #region Properties
    private Transform polygonEmitter;
	public Transform PolygonEmitter
	{
		get{return polygonEmitter;}
	}
        
    private int health = 100;
    public int Health
    {
        get {return health;}
        set { health -= value; }
    }

    private int currentLevel = 1;
    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }
    #endregion

	void Start () 
	{
		CreateBulletPool();
	}

	void Update () 
	{
	}

	
	public void CreateBulletPool()
	{
		//Create bullet pool;
		for (int i = 0; i < poolSize; i++)
		{
			bulletPool.Add(Instantiate(Resources.Load("Prefabs/Bullet", typeof(GameObject)), new Vector2(100f,100f), Quaternion.identity) as GameObject);
			bulletPool[i].name = i+"Bullet";
			bulletPool[i].gameObject.GetComponent<Bullet>().parentObject = this.gameObject;
			bulletPool[i].transform.parent = this.transform;
		}
	}

	public void IncrementFrontOfBulletPool()
	{
		frontOfPool++;
		if (frontOfPool >= poolSize) frontOfPool = 0;
	}

	public int GetFrontOfBulletPool()
	{
		return frontOfPool;
	}
}
