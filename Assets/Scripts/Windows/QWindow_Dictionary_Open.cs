﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QWindow_Dictionary_Open : QWindow {

    public GameObject prefab_WordLine;

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

        _wordLines= new List<QCG_WordLine>();

        foreach (var wordData in _selectedDictionary.words) {
            var wordLine = Create<QCG_WordLine>(prefab_WordLine, containerContent);

            var hexColor = ColorUtility.ToHtmlStringRGBA(QManager_Theme.Instance.CurrentScheme.highlight);

            wordLine.ref_Toggle.isOn = false;
            wordLine.ref_WordText.text = string.Format("<color=#{0}>{1}</color> - {2}", hexColor, wordData.word, wordData.GetPrettyTranslations());
            wordLine.ref_ProgresImage.fillAmount = wordData.progress;
            wordLine.ref_ProgresImage.color = QManager_Theme.Instance.CurrentScheme.highlight;

            var wdCopy = wordData;
            wordLine.ref_RemoveButton.Initialize(new QButtonData(null, () => {
                _selectedDictionary.words.Remove(wdCopy);
                Destroy(wordLine.gameObject);
            }));

            _wordLines.Add(wordLine);
        }
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
}
