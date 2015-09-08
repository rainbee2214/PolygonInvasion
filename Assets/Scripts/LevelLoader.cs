using UnityEngine;
using System.Collections;
using SSS.Level;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        Level.Load(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
