using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QCG_WordHeader : MonoBehaviour {

	public QButtonImage ref_DeleteSelectedButton;
	public QButtonImage ref_TrainSelectedButton;
	public QButtonImage ref_ClearSelectedButton;
    public QButtonImage ref_MoveSelectedButton;

	public QButtonImage ref_AddButton;

	public QLocalizedText ref_TooltipText;

    public Toggle ref_Toggle;


	private List<QButtonImage> _buttons;

	public void Initialize() {
		
		_buttons = new List<QButtonImage> ();
		_buttons.Add (ref_DeleteSelectedButton);
		_buttons.Add (ref_TrainSelectedButton);
		_buttons.Add (ref_ClearSelectedButton);
		_buttons.Add (ref_MoveSelectedButton);
		_buttons.Add (ref_AddButton);

		ref_TooltipText.Clear();

		ref_TrainSelectedButton.tooltipTranslationKey = "general_learn";
		ref_ClearSelectedButton.tooltipTranslationKey = "general_reset";
		ref_DeleteSelectedButton.tooltipTranslationKey = "general_delete";
		ref_MoveSelectedButton.tooltipTranslationKey = "general_move";
		ref_AddButton.tooltipTranslationKey = "general_add";


		foreach (var b in _buttons) {
			b.OnHoverStartEvent += (text) => {
				ref_TooltipText.Key = b.tooltipTranslationKey;
			};

			b.OnHoverEndEvent += (text) => {
				ref_TooltipText.Clear();
			};
		}

	}
}
