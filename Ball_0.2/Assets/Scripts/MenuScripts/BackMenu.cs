using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMenu : MonoBehaviour
{
   // public void PlayGame()
   // {n
   //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   // }

    public void BackButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
