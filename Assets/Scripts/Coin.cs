using System.Collections;
using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Action addCoin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        addCoin?.Invoke();
        gameObject.SetActive(false);
    }
}
