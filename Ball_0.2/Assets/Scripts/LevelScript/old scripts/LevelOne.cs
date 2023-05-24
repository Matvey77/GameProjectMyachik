using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour
{

    public void OpenScene()
    {
        SceneManager.LoadScene("Level_Nice_1");
    }
}
