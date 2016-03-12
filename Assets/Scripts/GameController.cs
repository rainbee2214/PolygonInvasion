using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : BaseController<GameController>
{
    public bool pause;

     bool paused = false;
    public bool Paused
    {
        get { return paused; }
        set
        {
            if (value)
            {
                //pausing game
                Debug.Log("Pausing game");
            }
            else
            {
                Debug.Log("Unpausing game");
                PolygonSpawner.spawner.UnpausePolygons();
                //unpausing game
            }
            paused = value;
        }
    }

    public bool unPaused = false;

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
       if (pause) Paused = pause;
    }

}
