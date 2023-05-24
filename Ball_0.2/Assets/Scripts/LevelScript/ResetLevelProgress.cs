using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevelProgress : MonoBehaviour
{
    public void ResetGameProgress()
    {
        PlayerPrefs.DeleteKey("UnlockedLevelIndex");
        // Дополнительные действия для сброса прогресса, если необходимо
        // Например, сброс других сохраненных значений, настройки и т.д.
        // PlayerPrefs.DeleteAll(); // Для сброса всех сохраненных значений в PlayerPrefs
    }
}

