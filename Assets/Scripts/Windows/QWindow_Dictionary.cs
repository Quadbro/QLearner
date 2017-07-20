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

        for (var i = 0; i < QApp.Instance.User.dictionaries.Count; i++) {
            var dictionaryData = QApp.Instance.User.dictionaries[i];
            var dictButton = Create<QButtonText>(prefab_DictionaryItem, containerContent);
            dictButton.Initialize(new QButtonData(null, () => { Debug.Log(dictionaryData.name); }));

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

    private QButtonText SpawnButton(QButtonData b, Transform parent, GameObject prefab) {
        var btn = Create<QButtonText>(prefab, parent);
        btn.Initialize(b);
        return btn;
    }
}
