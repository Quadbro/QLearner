using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QWindow_Exercises : QWindow {


    public List<QButton> Buttons {
        get { return _buttons; }
    }
    /*
    public QExercise_WordCards ExerciseWordCards {
        get { return _exerciseWordCards; }
    }

    public QExercise_WordTranslation ExerciseWordTranslation {
        get { return _exerciseWordTranslation; }
    }

    public QExercise_TranslationWord ExerciseTranslationWord {
        get { return _exerciseTranslationWord; }
    }

    public QExercise_Brainstorm ExerciseBrainstorm {
        get { return _exerciseBrainstorm; }
    }

    public QExercise_Crossword ExerciseCrossword {
        get { return _exerciseCrossword; }
    }

    public QExercise_Constructor ExerciseConstructor {
        get { return _exerciseConstructor; }
    }

    public QExercise_Sprint ExerciseSprint {
        get { return _exerciseSprint; }
    }*/

    public float widthBarier = 200f;
    public int minimumExercicesCols = 2;
    private float _sidePaddingDivider = 20f;


    public GameObject exercisesContainer;

    public GameObject linePrefab;

    private VerticalLayoutGroup _containerVGL;
    private RectTransform _containerRT;

    /*
    private QExercise_Listening _exerciseListening;
    private QExercise_Sprint _exerciseSprint;
    private QExercise_Constructor _exerciseConstructor;
    private QExercise_Crossword _exerciseCrossword;
    private QExercise_Brainstorm _exerciseBrainstorm;
    private QExercise_TranslationWord _exerciseTranslationWord;
    private QExercise_WordTranslation _exerciseWordTranslation;
    private QExercise_WordCards _exerciseWordCards;
    */

    private List<QButton> _buttons;

    //private List<QWindow> _exercises;

    private QWindowGroup _windowGroupExercises;

    protected override void OnAwake() {
        base.OnAwake();
        _buttons = new List<QButton>();
        //_exercises = new List<QWindow>();
        _windowGroupExercises = new QWindowGroup();
        
        _containerVGL = container.GetRequiredComponent<VerticalLayoutGroup>();
        _containerRT = container.GetRequiredComponent<RectTransform>();

        foreach (var prefab in QManager_Prefab.Instance.prefab_Exercises) {
            var ex = Create<QWindow>(prefab, exercisesContainer.transform);
            _windowGroupExercises.Link(ex);
        }

        foreach (var exercise in _windowGroupExercises.windows) {
            exercise.AwakeCycle();
        }

        RespawnButtons();
    }

    protected override void OnStart() {
        foreach (var exercise in _windowGroupExercises.windows) {
            exercise.StartCycle();
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

        for (var i = 0; i < _windowGroupExercises.windows.Count; i++) {
            AddButton(new QButtonData(_windowGroupExercises.windows[i].data.languageHeaderKey, _windowGroupExercises.windows[i].Activate), currentRow.transform);

            if ((i + 1) % rows == 0) {
                currentRow = SpawnNewLine();
            }
        }
    }

    private HorizontalLayoutGroup SpawnNewLine() {
        var go = Instantiate(linePrefab);
        go.transform.SetParent(container.transform);
        return go.GetComponent<HorizontalLayoutGroup>();
    }


    private void AddButton(QButtonData b, Transform parent) {
        var btn = Create<QButton>(QManager_Prefab.Instance.prefab_Button_ExerciseItem, parent);
        btn.Initialize(b);
        _buttons.Add(btn);
    }
}
