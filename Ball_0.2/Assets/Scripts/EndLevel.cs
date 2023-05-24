using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WhiteBall;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            CompleteLevel(currentLevelIndex);
            SceneManager.LoadScene(currentLevelIndex + 1);
        }
    }

    private void CompleteLevel(int levelIndex)
    {
        int unlockedLevelIndex = PlayerPrefs.GetInt("UnlockedLevelIndex", 0);
        if (levelIndex >= unlockedLevelIndex)
        {
            unlockedLevelIndex = levelIndex + 1;
            PlayerPrefs.SetInt("UnlockedLevelIndex", unlockedLevelIndex);
            PlayerPrefs.Save();
        }
    }
}
