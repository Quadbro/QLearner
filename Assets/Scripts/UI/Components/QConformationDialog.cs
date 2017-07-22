using System;
using UnityEngine.UI;
using UnityEngine;

public class QConformationDialog : QSingleton<QConformationDialog> {

	public QLocalizedText textHeader;
	public QLocalizedText textContent;

	public QButtonText buttonYes;
	public QButtonText buttonNo;

	protected override void OnAwake () {
		Hide ();
	}

	protected override void OnStart () {

	}

	protected override void OnUpdate () {

	}

	private void DefaultActionYes () {
		Hide ();
	}

	private void DefaultActionNo () {
		Hide ();
	}
		

	public void Show(string keyHeader, string keyContent, Action actionYes, Action actionNo = null) {
		textHeader.Key = keyHeader;
		textContent.Key = keyContent;

		buttonYes.Initialize (new QButtonData ("dialog_btn_yes", DefaultActionYes + actionYes));
		buttonNo.Initialize (new QButtonData ("dialog_btn_no", DefaultActionNo + actionNo));

		gameObject.SetActive(true);
	}

	public void Hide() {
		gameObject.SetActive (false);
	}
}

