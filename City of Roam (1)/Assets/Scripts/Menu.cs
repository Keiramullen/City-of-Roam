using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Awake()
    {
 
        GameStateManager.onGameOver += Open;

        gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        GameStateManager.onGameOver -= Open;
    }
    private void Open()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        GameStateManager.Restart();
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
