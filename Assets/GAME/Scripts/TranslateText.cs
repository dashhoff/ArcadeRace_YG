using System;
using UnityEngine;
using TMPro;
using YG;

public class TranslateText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _en;
    [SerializeField] private string _ru;

    public void Start()
    {
        if (_text == null)
            _text = GetComponent<TMP_Text>();
        
        Translate();
    }

    public void Translate()
    {
        if (YandexGame.lang == "ru")
            _text.text = _ru;
        else
            _text.text = _en;
    }
}
