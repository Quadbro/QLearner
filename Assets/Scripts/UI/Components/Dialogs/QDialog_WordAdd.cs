using System;

public class QDialog_WordAdd : QDialog {

	public QInputField inputWord;
	public QInputField inputTranslations;

	public QButtonText buttonAdd;
	public QButtonText buttonCancel;

	public void Initialize(DictionaryData dict, Action actionAdd = null) {

		inputWord.KeyPlaceholder = "dialog_wordadd_word";
		inputTranslations.KeyPlaceholder = "dialog_wordadd_translation";

		buttonAdd.Initialize (new QButtonData ("general_add", () => {
			dict.AddWord(inputWord.text, inputTranslations.text);
			if (actionAdd != null) {
				actionAdd();
			}
			Hide();
		}));

		buttonCancel.Initialize (new QButtonData ("dialog_btn_cancel",  Hide ));

		Show ();
	}


}




