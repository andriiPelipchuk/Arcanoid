using System.Collections;
using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    public static Action<GameObject> giveProjectile;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        InteractionColision(collision.gameObject);
    }

    private void InteractionColision(GameObject projectile)
    {
        giveProjectile?.Invoke(projectile);
        Destroy(projectile);
        gameObject.SetActive(false);
    }
}
