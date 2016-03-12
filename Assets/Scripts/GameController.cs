using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : BaseController<GameController>
{
    public bool paused = false;

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


}
