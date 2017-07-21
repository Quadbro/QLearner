using System;
using UnityEngine.UI;
using UnityEngine;

public class QTooltip : QSingleton<QTooltip> {
	public bool IsActive {
		get {
			return gameObject.activeSelf;
		}
	}

	public QLocalizedText Text;

	private RectTransform _rectTransform;


	protected override void OnAwake () {
		_rectTransform = GetComponent<RectTransform> ();
		HideTooltip ();
	}

	protected override void OnStart () {

	}

	protected override void OnUpdate () {

	}
		

	public void ShowTooltip(string key, Vector3 pos) {
		Text.Key = key;
	

		_rectTransform.localPosition = pos;
		transform.position = pos;

		gameObject.SetActive(true);
	}

	public void HideTooltip() {
		gameObject.SetActive (false);
	}
}

