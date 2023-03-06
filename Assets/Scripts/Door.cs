using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Action wonPopUp;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        wonPopUp?.Invoke();
    }
}
