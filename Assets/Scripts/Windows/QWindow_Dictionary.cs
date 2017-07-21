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
        _dictAddnputField.Btn.Initialize(new QButtonData(null, AddDictAction));
        _dictAddnputField.KeyPlaceholder = "dictionary_add_placeholder";

        var rt = _dictAddnputField.GetComponent<RectTransform>();
        rt.offsetMin = new Vector2(0, -80);
        rt.offsetMax = new Vector2(0, 0);

        RespawnDictionaries();
    }

    protected override void OnStart() {
        base.OnStart();

    }

    private void RespawnDictionaries() {
        containerContent.ClearAllChildren();
        containerWindows.ClearAllChildren();

        for (var i = 0; i < QApp.Instance.User.dictionaries.Count; i++) {
            var dictionaryData = QApp.Instance.User.dictionaries[i];
            var dictButton = Create<QButtonText>(prefab_DictionaryItem, containerContent);
            dictButton.Initialize(new QButtonData(null, () => {

                var dictWindow = SpawnWindow<QWindow_Dictionary_Open>(prefab_OpenedDictionaryWindow);
                dictWindow.Data.languageHeaderKey = dictionaryData.name;
                dictWindow.SelectedDictionary = dictionaryData;
                if (dictionaryData.words.Count == 0) {
                    dictionaryData.words.Add(new WordData("Dog", new List<string> {"Собака", "Друг"}));
                    dictionaryData.words.Add(new WordData("Cat", new List<string> { "кошка", "кот" }));
                    dictionaryData.words.Add(new WordData("Car", new List<string> { "Машина", "бублик", "мопед" }));
                    dictionaryData.words.Add(new WordData("Mother", new List<string> { "Мама" }));
                    dictionaryData.words.Add(new WordData("House", new List<string> { "Дом", "Апартаменты" }));

                }

				/*
                foreach (var w in dictionaryData.words) {
                    w.progress = Random.Range(0f, 1f);
                }*/
                dictWindow.AwakeCycle();


                dictWindow.Activate();
            }));

            dictButton.SetTextStrict(string.Format("{0}) {1}", i+1, dictionaryData.name));
        }

        scrollRect.ScrollToTop();

    }

    private void AddDictAction() {
        var text = _dictAddnputField.text;

        if (!string.IsNullOrEmpty(text)) {
            QApp.Instance.User.CreateDictionary(text);
            QApp.Instance.SaveAppData();;

            RespawnDictionaries();
        }
    }

    protected override void OnUpdate() {
    }

    protected override void OnActivate() {
    }

    protected override void OnDeactivate() {
    }
}
