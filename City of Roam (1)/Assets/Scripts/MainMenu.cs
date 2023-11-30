using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

 

    public void PlayGame()
    {
        SceneManager.LoadScene(1);

        gameObject.SetActive(false);    


       
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
