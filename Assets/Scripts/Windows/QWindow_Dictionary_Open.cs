using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

public delegate void ActionWordline (QCG_WordLine line);

public class QWindow_Dictionary_Open : QWindow {

    public GameObject prefab_WordLine;
    public QCG_WordHeader headerRef;

    private List<QCG_WordLine> _wordLines;

    public DictionaryData SelectedDictionary {
        get { return _selectedDictionary; }
        set { _selectedDictionary = value; }
    }

    private DictionaryData _selectedDictionary;



    protected override void OnAwake() {
        base.OnAwake();

        if (_selectedDictionary == null) {
            return;
        }

		headerRef.Initialize ();

		headerRef.ref_Toggle.isOn = false;

		headerRef.ref_TrainSelectedButton.Initialize (new QButtonData(null, () => {
			if (_wordLines.Any(item => item.ref_Toggle.isOn)) {
				ActionWithWords((QCG_WordLine line) => {
					line.WordDataRef.progress = 1f;
					line.ref_ProgresImage.fillAmount = 1f;
				});
			} else {
				QManager_Dialog.Instance.ShowInfo("dialog_info_no_selection");
			}
		}));

		headerRef.ref_ClearSelectedButton.Initialize (new QButtonData(null, () => {
			if (_wordLines.Any(item => item.ref_Toggle.isOn)) {
				ActionWithWords((QCG_WordLine line) => {
					line.WordDataRef.progress = 0f;
					line.ref_ProgresImage.fillAmount = 0f;
				});
			} else {
				QManager_Dialog.Instance.ShowInfo("dialog_info_no_selection");
			}
		}));

		headerRef.ref_DeleteSelectedButton.Initialize (new QButtonData(null, () => {
			if (_wordLines.Any(item => item.ref_Toggle.isOn)) {
				QManager_Dialog.Instance.ShowConfirm("dialog_title_delete", "dialog_confirm_delete_content", () => {
					ActionWithWords((QCG_WordLine line) => {
						line.ref_Toggle.isOn = false;
						_selectedDictionary.words.Remove(line.WordDataRef);
						Destroy(line.gameObject);
					});
				});
			} else {
				QManager_Dialog.Instance.ShowInfo("dialog_info_no_selection");
			}
		}));

		headerRef.ref_MoveSelectedButton.Initialize (new QButtonData(null, () => {
			if (_wordLines.Any(item => item.ref_Toggle.isOn)) {
				foreach (var line in _wordLines) {
					if (line.ref_Toggle.isOn) {

					}
				}
			} else {
				QManager_Dialog.Instance.ShowInfo("dialog_info_no_selection");
			}

		}));

		headerRef.ref_AddButton.Initialize (new QButtonData(null, () => {
			QManager_Dialog.Instance.ShowWordAdd(_selectedDictionary, () => {
				RespawnLines();
			});
		}));

		// Select all toggle
		headerRef.ref_Toggle.onValueChanged.AddListener ((value) => {
			foreach (var line in _wordLines) {
				line.ref_Toggle.isOn = value;
			}
		});


		RespawnLines ();
        
    }

    protected override void OnStart() {
        base.OnStart();
    }

    protected override void OnUpdate() {
    }

    protected override void OnActivate() {
    }

    protected override void OnDeactivate() {
        if (_parentWindow) {
            if (_parentWindow.WindowGroup != null) {
                _parentWindow.WindowGroup.Unlink(this);
            }
        }

        Destroy(gameObject);
    }

	private bool ActionWithWords(ActionWordline a) {
		var changed = false;
		foreach (var line in _wordLines) {
			if (line != null) {
				if (line.ref_Toggle.isOn) {
					changed = true;
					a (line);
				}
			}
		}
		if (changed) {
			UpdateLines ();
			QApp.Instance.SaveAppData();
		}

		return changed;
	}

	private void UpdateLines() {
		_wordLines.RemoveAll(item => item == null);
	}

	private void RespawnLines() {
		containerContent.ClearAllChildren ();

		_wordLines= new List<QCG_WordLine>();

		foreach (var wordData in _selectedDictionary.words) {
			var wordLine = Create<QCG_WordLine>(prefab_WordLine, containerContent);

			var hexColor = ColorUtility.ToHtmlStringRGBA(QManager_Theme.Instance.CurrentScheme.highlight);

			wordLine.WordDataRef = wordData;
			wordLine.ref_Toggle.isOn = false;
			wordLine.ref_WordText.text = string.Format("<color=#{0}>{1}</color> - {2}", hexColor, wordData.word, wordData.GetPrettyTranslations());
			wordLine.ref_ProgresImage.fillAmount = wordData.progress;
			wordLine.ref_ProgresImage.color = QManager_Theme.Instance.CurrentScheme.highlight;

			_wordLines.Add(wordLine);
		}
	}
}
