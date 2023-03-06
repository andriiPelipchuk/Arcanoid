using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _velocity;
    private Rigidbody2D _rb;

    public int _speedMove = 100;


    private void Update()
    {
        _velocity = _rb.velocity;
    }

    public void SetDirection(Vector3 directionMove)
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.AddForce(directionMove.normalized * _speedMove, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var direction = Vector3.Reflect(_velocity, collision.contacts[0].normal);
        _rb.velocity = direction.normalized * _speedMove;
    }

}
