using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] levelNames; // ћассив имен уровней
    private int unlockedLevelIndex = 0; // »ндекс последнего разблокированного уровн€

    private void Start()
    {
        // ѕолучаем сохраненное значение последнего разблокированного уровн€
        unlockedLevelIndex = PlayerPrefs.GetInt("UnlockedLevelIndex", 0);
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex <= unlockedLevelIndex)
        {
            SceneManager.LoadScene(levelNames[levelIndex]);
        }
        else
        {
            Debug.Log("Level locked. Complete previous levels to unlock.");
            // «десь можно добавить сообщение или эффект, указывающий, что уровень заблокирован
        }
    }

    public void CompleteLevel(int levelIndex)
    {
        if (levelIndex == unlockedLevelIndex)
        {
            unlockedLevelIndex++;

            // —охран€ем значение разблокированного уровн€
            PlayerPrefs.SetInt("UnlockedLevelIndex", unlockedLevelIndex);
            PlayerPrefs.Save();
        }
    }
}
