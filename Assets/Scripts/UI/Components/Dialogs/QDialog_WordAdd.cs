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


			var input_word = PolishInput(inputWord.text);
			var input_translations = PolishInput(inputTranslations.text);

			var rawTranslations = inputTranslations.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			var translations = new List<string>();

			foreach (var tr in rawTranslations) {
				translations.Add(PolishInput(tr));
			}

			// No need to add without translation
			if (translations.Count > 0) {

				// Check if we already have such word
				var checkWord = dict.CheckWord(input_word);

				if (checkWord != null) {
					checkWord.AddTranslationsRaw(translations);
				} else {
					dict.AddWord(input_word, translations);
				}

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


	private string PolishInput(string input) {
		return System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", " ");
	}

}




