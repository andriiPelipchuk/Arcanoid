using System;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static Action<GameObject> deleteProjectile;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        InteractionColision(collision.gameObject);
    }
    private void InteractionColision(GameObject projectile)
    {
        deleteProjectile?.Invoke(projectile);
        Destroy(projectile);
    }
}
