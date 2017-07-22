using System;

public class QDialog_Info : QDialog {

	public QLocalizedText textContent;

	public QButtonText buttonOk;

	public void Initialize(string keyContent, Action action = null) {
		textContent.Key = keyContent;
		buttonOk.Initialize (new QButtonData ("dialog_btn_ok",  DefaultActionOk + action));
		Show ();
	}

	private void DefaultActionOk () {
		Hide ();
	}
}


