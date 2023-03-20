using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;

    public void DestroyHeart()
    {
        _healthBar.transform.GetChild(0).gameObject.SetActive(false);
        _healthBar.transform.GetChild(0).SetAsLastSibling();
    }
}
