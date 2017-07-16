using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class QButtonData {
    public string key;
    public Action action;

    public QButtonData(string key, Action action) {
        this.key = key;
        this.action = action;
    }

    public QButtonData(QWindow window) {
        this.key = window.data.languageHeaderKey;
        this.action = window.Activate;
    }
}


public class QButton : MonoBehaviour {

    private Button _btn;
    private QLocalizedText _text;
    private QButtonData _data;


    public void Initialize(QButtonData data) {
        _btn = gameObject.GetRequiredComponentInChildren<Button>();
        _text = gameObject.GetRequiredComponentInChildren<QLocalizedText>();
        _data = data;

        _btn.onClick.AddListener(() => _data.action());
        _text.Key = _data.key;
    }
}
