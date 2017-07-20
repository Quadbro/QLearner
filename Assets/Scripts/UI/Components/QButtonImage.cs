using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QButtonImage : Button {
    private QButtonData _data;
    private QColorScheme _colorScheme;

    public float textFadeDuration = 0.1f;

    public void Initialize(QButtonData data) {
        _data = data;
        _colorScheme = QManager_Theme.Instance.CurrentScheme;

        targetGraphic.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);

        //targetGraphic.CrossFadeAlpha(0, textFadeDuration, true);
    }

    public override void OnPointerClick(PointerEventData eventData) {
        base.OnPointerClick(eventData);
        _data.action();
    }

    public override void OnPointerExit(PointerEventData eventData) {
        base.OnPointerExit(eventData);

        targetGraphic.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);
        //targetGraphic.CrossFadeAlpha(0, textFadeDuration, true);
    }

    public override void OnPointerEnter(PointerEventData eventData) {
        base.OnPointerEnter(eventData);

        targetGraphic.CrossFadeColor(_colorScheme.highlight, textFadeDuration, true, true);
        //targetGraphic.CrossFadeAlpha(0.5f, textFadeDuration, true);

    }

    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);

        targetGraphic.CrossFadeColor(_colorScheme.pressed, textFadeDuration, true, true);
    }

    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);

        targetGraphic.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);
    }
}
