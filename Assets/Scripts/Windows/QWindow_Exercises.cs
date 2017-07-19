using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QWindow_Exercises : QWindow {


    public float widthBarier = 200f;
    public int minimumExercicesCols = 2;
    private float _sidePaddingDivider = 20f;


    public ScrollRect scrollRect;
    public GameObject linePrefab;
    public GameObject dropdownPrefab;
    public GameObject prefab_Button_ExerciseItem;

    private VerticalLayoutGroup _containerVGL;
    private RectTransform _containerRT;

    protected override void OnAwake() {
        base.OnAwake();
        
        _containerVGL = containerContent.gameObject.GetRequiredComponent<VerticalLayoutGroup>();
        _containerRT = containerContent.gameObject.GetRequiredComponent<RectTransform>();

        foreach (var prefab in subWindows) {
            SpawnWindow(prefab);
        }

        foreach (var w in _windowGroup.windows) {
            w.AwakeCycle();
        }

        RespawnButtons();
    }

    protected override void OnStart() {
        base.OnStart();

        foreach (var w in _windowGroup.windows) {
            w.StartCycle();
        }
    }

    protected override void OnUpdate() {
    }

    protected override void OnActivate() {
        RespawnButtons();
    }

    protected override void OnDeactivate() {
    }


    public void RespawnButtons() {
        
        containerContent.ClearAllChildren();

        var dropGO = Instantiate(dropdownPrefab);
        dropGO.transform.SetParent(containerContent.transform);

        var width = _containerRT.rect.width;
        var bOffset = (int)(width / _sidePaddingDivider);

        _containerVGL.padding.left = bOffset;
        _containerVGL.padding.right = bOffset;

        var rows = (int)(width / widthBarier);
        if (rows < minimumExercicesCols) {
            rows = minimumExercicesCols;
        }

        var currentRow = SpawnNewLine();

        for (var i = 0; i < _windowGroup.windows.Count; i++) {
            SpawnButton(new QButtonData(_windowGroup.windows[i].Data.languageHeaderKey, _windowGroup.windows[i].Activate), currentRow.transform);

            if ((i + 1) % rows == 0) {
                currentRow = SpawnNewLine();
            }
        }

        scrollRect.ScrollToTop();
    }

    private HorizontalLayoutGroup SpawnNewLine() {
        var go = Instantiate(linePrefab);
        go.transform.SetParent(containerContent.transform);
        return go.GetComponent<HorizontalLayoutGroup>();
    }


    private QButtonText SpawnButton(QButtonData b, Transform parent) {
        var btn = Create<QButtonText>(prefab_Button_ExerciseItem, parent);
        btn.Initialize(b);
        return btn;
    }
}
