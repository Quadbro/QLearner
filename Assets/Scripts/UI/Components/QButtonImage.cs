using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QButtonImage : Button {
    private QButtonData _data;
    private QColorScheme _colorScheme;


	public bool toShowTooltip = false;

	public string tooltipTranslationKey;

    public float textFadeDuration = 0.1f;

	public delegate void ButtonStringAction (string text);
	public event ButtonStringAction OnHoverStartEvent;
	public event ButtonStringAction OnHoverEndEvent;

    public void Initialize(QButtonData data) {
        _data = data;
        _colorScheme = QManager_Theme.Instance.CurrentScheme;

        targetGraphic.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);
    }

    public override void OnPointerClick(PointerEventData eventData) {
        base.OnPointerClick(eventData);
        _data.action();
    }

    public override void OnPointerExit(PointerEventData eventData) {
        base.OnPointerExit(eventData);
        targetGraphic.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);

		//StopHover ();

		if (OnHoverEndEvent != null) {
			OnHoverEndEvent (tooltipTranslationKey);
		}
	}

    public override void OnPointerEnter(PointerEventData eventData) {
        base.OnPointerEnter(eventData);
		targetGraphic.CrossFadeColor(_colorScheme.highlight, textFadeDuration, true, true);


		if (OnHoverStartEvent != null) {
			OnHoverStartEvent (tooltipTranslationKey);
		}
		//StartHover(new Vector3(transform.position.x, transform.position.y - 18f, 0f));
	}

    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);

        targetGraphic.CrossFadeColor(_colorScheme.pressed, textFadeDuration, true, true);

		//StopHover ();
	}

    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);

        if (currentSelectionState == SelectionState.Highlighted) {
            targetGraphic.CrossFadeColor(_colorScheme.highlight, textFadeDuration, true, true);
        }
        else {
            targetGraphic.CrossFadeColor(_colorScheme.normal, textFadeDuration, true, true);
        }

		//StopHover ();
    }



	void StartHover(Vector3 position) {
		if (toShowTooltip) {
			QTooltip.Instance.ShowTooltip (tooltipTranslationKey, position);
		}
	}
	void StopHover() {
		QTooltip.Instance.HideTooltip();
	}
}
