using UnityEngine;
using System.Collections;

public class QWindow_Dictionary : QWindow {

    public GameObject prefab_TopContainer;
    public GameObject prefab_InputField;
    public GameObject prefab_ButtonAdd;
    public GameObject prefab_DictionatyItem;

    private QInputField _dictAddnputField;

    protected override void OnAwake() {
        base.OnAwake();


        RespawnDictionaries();
    }

    protected override void OnStart() {
        base.OnStart();

    }

    private void RespawnDictionaries() {
        containerContent.ClearAllChildren();

        _dictAddnputField = Create<QInputField>(prefab_InputField, containerContent.transform);
        _dictAddnputField.KeyPlaceholder = "dictionary_add_placeholder";

        var buttonAddDict = Create<QButtonText>(prefab_ButtonAdd, containerContent.transform);
        buttonAddDict.Initialize(new QButtonData("dictionary_add_btn_text", AddDictAction));

        foreach (var dictionaryData in QApp.Instance.User.dictionaries) {
            var dictButton = Create<QButtonText>(prefab_DictionatyItem, containerContent.transform);
            dictButton.Initialize(new QButtonData(null, () => {
                Debug.Log(dictionaryData.name);
            }));

            dictButton.SetTextStrict(dictionaryData.name);
        }
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

    private QButtonText SpawnButton(QButtonData b, Transform parent, GameObject prefab) {
        var btn = Create<QButtonText>(prefab, parent);
        btn.Initialize(b);
        return btn;
    }
}
