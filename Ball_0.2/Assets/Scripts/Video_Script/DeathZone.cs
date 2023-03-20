using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WhiteBall;



public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        if (player == null)
            return;
        player.TakeDamage(100f);
    }
}
