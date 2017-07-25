using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QWindow_Dictionary : QWindow {

    public ScrollRect scrollRect;
    public GameObject prefab_InputField;

    public GameObject prefab_DictionaryItem;
    public GameObject prefab_OpenedDictionaryWindow;

    private QInputFieldButton _dictAddnputField;

    protected override void OnAwake() {
        base.OnAwake();
        _dictAddnputField = Create<QInputFieldButton>(prefab_InputField, scrollRect.transform);
        _dictAddnputField.Btn.Initialize(new QButtonData(null, () => {
            var text = _dictAddnputField.text;

            if (!string.IsNullOrEmpty(text)) {
                QApp.Instance.User.CreateDictionary(text);
                QApp.Instance.SaveAppData(); 

                RespawnDictionaries();
            }

            _dictAddnputField.text = string.Empty;
        }));
        _dictAddnputField.KeyPlaceholder = "dictionary_add_placeholder";

        var rt = _dictAddnputField.GetComponent<RectTransform>();
        rt.offsetMin = new Vector2(0, -80);
        rt.offsetMax = new Vector2(0, 0);

        //RespawnDictionaries();
    }

    protected override void OnStart() {
        base.OnStart();

    }

    private void RespawnDictionaries() {
        containerContent.ClearAllChildren();
        containerWindows.ClearAllChildren();

        for (var i = 0; i < QApp.Instance.User.dictionaries.Count; i++) {
            var dictionaryData = QApp.Instance.User.dictionaries[i];
            var dictLine = Create<QCG_DictionaryLine>(prefab_DictionaryItem, containerContent);

            dictLine.ref_DictionaryButton.Initialize(new QButtonData(null, () => {

                var dictWindow = SpawnWindow<QWindow_Dictionary_Open>(prefab_OpenedDictionaryWindow);
                dictWindow.Data.languageHeaderKey = dictionaryData.name;
                dictWindow.SelectedDictionary = dictionaryData;
                if (dictionaryData.GetWordsCount() == 0) {
                    dictionaryData.AddWord(new WordData("Dog", new List<string> {"Собака", "Друг"}));
                    dictionaryData.AddWord(new WordData("Cat", new List<string> { "кошка", "кот" }));
                    dictionaryData.AddWord(new WordData("Car", new List<string> { "Машина", "бублик", "мопед" }));
                    dictionaryData.AddWord(new WordData("Mother", new List<string> { "Мама" }));
                    dictionaryData.AddWord(new WordData("House", new List<string> { "Дом", "Апартаменты" }));

                }

				/*
                foreach (var w in dictionaryData.words) {
                    w.progress = Random.Range(0f, 1f);
                }*/
                dictWindow.AwakeCycle();


                dictWindow.Activate();
            }));

            dictLine.ref_DeleteButton.Initialize(new QButtonData(null, () => { 
                QManager_Dialog.Instance.ShowConfirm("dialog_title_delete", "dialog_confirm_delete_content", () => {
                    QApp.Instance.User.RemoveDictionary(dictionaryData);
                    Destroy(dictLine.gameObject);
                    QApp.Instance.SaveAppData();
                });
            }));


            dictLine.ref_WordNameText.text = dictionaryData.name;

            dictLine.ref_WordsLeftText.text = string.Format("{0}:\n{1}/{2}",
                QManager_Localization.Instance.GetLocalizedValue("dictionary_words_learned_text"),
                dictionaryData.GetLearnedWordsCount(),
                dictionaryData.GetWordsCount());

            //dictLine.ref_DictionaryButton.SetTextStrict();

        }

        scrollRect.ScrollToTop();

    }

    protected override void OnUpdate() {
    }

    protected override void OnActivate() {
        RespawnDictionaries();
    }

    protected override void OnDeactivate() {
    }
}
