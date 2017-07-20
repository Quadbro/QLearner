using System;
using UnityEngine;
using UnityEngine.EventSystems;
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
        this.key = window.Data.languageHeaderKey;
        this.action = window.Activate;
    }
}


public class QButtonText : Button {
    private QLocalizedText _text;
    private QButtonData _data;
    private QColorScheme _colorScheme;

    public float textFadeDuration = 0.1f;

    public void Initialize(QButtonData data) {
        _text = gameObject.GetRequiredComponentInChildren<QLocalizedText>();
        _data = data;
        _colorScheme = QManager_Theme.Instance.CurrentScheme;
        _text.Key = _data.key;

        _text.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);

        //targetGraphic.CrossFadeAlpha(0, textFadeDuration, true);
    }

    public void SetTextStrict(string str) {
        _text.Key = null;
        _text.text = str;
    }

    public override void OnPointerClick(PointerEventData eventData) {
        base.OnPointerClick(eventData);
        _data.action();
    }

    public override void OnPointerExit(PointerEventData eventData) {
        base.OnPointerExit(eventData);

       
        _text.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);

        _text.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);
        //targetGraphic.CrossFadeAlpha(0, textFadeDuration, true);
    }

    public override void OnPointerEnter(PointerEventData eventData) {
        base.OnPointerEnter(eventData);

        _text.CrossFadeColor(_colorScheme.highlight, textFadeDuration, true, true);
        //targetGraphic.CrossFadeAlpha(0.5f, textFadeDuration, true);

    }

    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);

        _text.CrossFadeColor(_colorScheme.pressed, textFadeDuration, true, true);

    }

    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);

        if (currentSelectionState == SelectionState.Highlighted) {
            _text.CrossFadeColor(_colorScheme.highlight, textFadeDuration, true, true);
        } else {
            _text.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);
        }
    }
}
