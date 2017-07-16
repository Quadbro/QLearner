using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QWindow_Exercises : QWindow {

    public string[] exercises;


    public float widthBarier = 200f;
    public int minimumExercicesCols = 2;


    public GameObject linePrefab;

    private VerticalLayoutGroup _containerVGL;
    private RectTransform _containerRT;

    private float _sidePaddingDivider = 20f;

    protected override void OnAwake() {
        base.OnAwake();

        _containerVGL = container.GetRequiredComponent<VerticalLayoutGroup>();
        _containerRT = container.GetRequiredComponent<RectTransform>();

        RespawnButtons();
    }

    protected override void OnStart() {

    }

    protected override void OnUpdate() {
    }

    protected override void OnActivate() {
    }

    protected override void OnDeactivate() {
    }


    public void RespawnButtons() {
        container.ClearAllChildren();

        var width = _containerRT.rect.width;
        var bOffset = (int)(width / _sidePaddingDivider);

        _containerVGL.padding.left = bOffset;
        _containerVGL.padding.right = bOffset;

        var rows = (int)(width / widthBarier);
        if (rows < minimumExercicesCols) {
            rows = minimumExercicesCols;
        }

        var currentRow = SpawnNewLine();
        Debug.Log(width + " " + widthBarier);

        Debug.Log(rows);
        for (var i = 0; i < exercises.Length; i++) {
            SpawnNewButton(currentRow, exercises[i]);

            if ((i + 1) % rows == 0) {
                currentRow = SpawnNewLine();
            }
        }
    }

    private HorizontalLayoutGroup SpawnNewLine() {
        var go = Instantiate(linePrefab);
        go.transform.parent = container.transform;
        return go.GetComponent<HorizontalLayoutGroup>();
    }

    private void SpawnNewButton(HorizontalLayoutGroup line, string text) {
        var go = Instantiate(QManager_Prefab.Instance.prefab_Button_ExerciseItem);
        go.transform.parent = line.transform;
        go.GetComponentInChildren<Text>().text = text;
    }
}
