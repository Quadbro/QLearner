using System;
using System.Linq;
using System.Collections.Generic;

public class QDialog_WordAdd : QDialog {

	public QInputField inputWord;
	public QInputField inputTranslations;

	public QButtonText buttonAdd;
	public QButtonText buttonCancel;

	public void Initialize(DictionaryData dict, Action actionAdd = null) {

		inputWord.KeyPlaceholder = "dialog_wordadd_word";
		inputTranslations.KeyPlaceholder = "dialog_wordadd_translation";

		buttonAdd.Initialize (new QButtonData ("general_add", () => {

			if (string.IsNullOrEmpty(inputWord.text) || string.IsNullOrEmpty(inputTranslations.text)) {
				return;
			}


			var input_word = inputWord.text.TrimAndNormalize();
			var rawTranslations = inputTranslations.text.Split(new [] { Environment.NewLine }, StringSplitOptions.None);
			var translations = new List<string>();

			foreach (var tr in rawTranslations) {
				translations.Add(tr.TrimAndNormalize());
			}

			// No need to add without translation
			if (translations.Count > 0) {

                // Try add this word to dict (all cases handled by data class)
                dict.MergeWord(new WordData(input_word, translations));

				if (actionAdd != null) {
					actionAdd();
				}

				QApp.Instance.SaveAppData();

				Hide();
			}
		}));

		buttonCancel.Initialize (new QButtonData ("dialog_btn_cancel",  Hide ));

		Show ();
	}


	

}




