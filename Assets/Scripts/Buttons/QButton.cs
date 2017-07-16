using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class QButtonData {
    public string text;
    public Action action;

    public QButtonData(string text, Action action) {
        this.text = text;
        this.action = action;
    }
}


public class QButton : MonoBehaviour {

    private Button _btn;
    private Text _text;
    private QButtonData _data;


    public void Initialize(QButtonData data) {
        _btn = gameObject.GetRequiredComponentInChildren<Button>();
        _text = gameObject.GetRequiredComponentInChildren<Text>();
        _data = data;

        _btn.onClick.AddListener(() => _data.action());
        _text.text = _data.text;
    }
}
