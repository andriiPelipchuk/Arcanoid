using System.Collections;
using System;
using UnityEngine;

public class Fine : MonoBehaviour
{
    public static Action<GameObject> takeAwayProjectile;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        InteractionColision(collision.gameObject);
    }

    private void InteractionColision(GameObject projectile)
    {
        takeAwayProjectile?.Invoke(projectile);
        Destroy(projectile);
        gameObject.SetActive(false);
    }
}
