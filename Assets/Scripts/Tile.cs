using System;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static Action addCoin;

    [SerializeField] private int _number, _maxNumber;

    public Color[] colorsArr;

    private SpriteRenderer _spriteRend;

    private void Awake()
    {
        _spriteRend = gameObject.GetComponent<SpriteRenderer>();
        InteractionColision();
    }

    private void AddText()
    {
        var textChield = gameObject.transform.GetChild(0);
        var text = textChield.GetComponent<TextMeshPro>();
        text.text = _number.ToString();
    }


    private void SelectColor(Color color)
    {
        _spriteRend.color = color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _number--;
        InteractionColision();
    }
    private void InteractionColision()
    {
        if (_number <= 0)
        {
            addCoin?.Invoke();
            Destroy(gameObject);
        }
        AddText();
        SelectColor(colorsArr[Mathf.Clamp((int)(_number / (_maxNumber * 1f) * colorsArr.Length), 0, colorsArr.Length - 1)]);
    }
}
