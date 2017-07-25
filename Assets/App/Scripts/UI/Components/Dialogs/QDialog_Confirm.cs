using System;
using UnityEngine.UI;
using UnityEngine;

public class QDialog_Confirm : QDialog {

	public QLocalizedText textHeader;
	public QLocalizedText textContent;

	public QButtonText buttonYes;
	public QButtonText buttonNo;

	private void DefaultActionYes () {
		Hide ();
	}

	private void DefaultActionNo () {
		Hide ();
	}

	public void Initialize(string keyHeader, string keyContent, Action actionYes = null, Action actionNo = null) {
		textHeader.Key = keyHeader;
		textContent.Key = keyContent;

		buttonYes.Initialize (new QButtonData ("dialog_btn_yes",  DefaultActionYes + actionYes));
		buttonNo.Initialize (new QButtonData ("dialog_btn_no", DefaultActionNo + actionNo));

		Show ();
	}
}

