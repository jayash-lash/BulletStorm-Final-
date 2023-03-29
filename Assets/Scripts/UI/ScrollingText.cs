using System;
using TMPro;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private RectTransform _rectTransform;
    private RectTransform _textRectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _textRectTransform = _textMeshPro.GetComponent<RectTransform>();
    }

    private void Update()
    {
        _textRectTransform.anchoredPosition += Vector2.left * (_scrollSpeed * Time.deltaTime);
        if (_textRectTransform.anchoredPosition.x < -_textRectTransform.rect.width)
        {
            _textRectTransform.anchoredPosition = new Vector2(_rectTransform.rect.width, 0);
        }
    }
}