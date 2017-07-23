using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class QDialog_WordMove : QDialog {


    public Dropdown dictionariesDropdown;


	public QButtonText buttonMove;
	public QButtonText buttonCancel;

	public void Initialize(DictionaryData dict, List<WordData> wordsToTransfer, Action actionAdd = null) {

	    dictionariesDropdown.options.Clear();


	    foreach (var dictionaryData in QApp.Instance.User.dictionaries) {
	        dictionariesDropdown.options.Add(new Dropdown.OptionData(dictionaryData.name));
        }


	    dictionariesDropdown.RefreshShownValue();



        buttonMove.Initialize (new QButtonData ("general_move", () => {

            var selectedDict = QApp.Instance.User.dictionaries[dictionariesDropdown.value];

            if (selectedDict != dict) {
                selectedDict.MergeWords(wordsToTransfer);
                dict.RemoveWords(wordsToTransfer);

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




