using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QWindow_Dictionary : QWindow {

    public ScrollRect scrollRect;
    public GameObject prefab_InputField;

    public GameObject prefab_DictionaryItem;

    private QInputFieldButton _dictAddnputField;

    protected override void OnAwake() {
        base.OnAwake();


        RespawnDictionaries();
    }

    protected override void OnStart() {
        base.OnStart();

    }

    private void RespawnDictionaries() {
        containerContent.ClearAllChildren();

        _dictAddnputField = Create<QInputFieldButton>(prefab_InputField, containerContent);
        _dictAddnputField.Btn.Initialize(new QButtonData(null, AddDictAction));
        _dictAddnputField.KeyPlaceholder = "dictionary_add_placeholder";

        foreach (var dictionaryData in QApp.Instance.User.dictionaries) {
            var dictButton = Create<QButtonText>(prefab_DictionaryItem, containerContent);
            dictButton.Initialize(new QButtonData(null, () => {
                Debug.Log(dictionaryData.name);
            }));

            dictButton.SetTextStrict(dictionaryData.name);
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

    private QButtonText SpawnButton(QButtonData b, Transform parent, GameObject prefab) {
        var btn = Create<QButtonText>(prefab, parent);
        btn.Initialize(b);
        return btn;
    }
}
