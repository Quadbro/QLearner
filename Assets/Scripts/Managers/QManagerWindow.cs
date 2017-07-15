using UnityEngine;
using System.Collections;

public class QManagerWindow : QManager<QManagerWindow> {

    private QWindow_Home windowHome;
    private QWindow_Exercises windowExercises;
    private QWindow_Dictionary windowDictionary;
    private QWindow_Translator windowTranslator;
    private QWindow_Settings windowSettings;



    protected override void OnAwake() {

        this.ClearAllChildren();

        windowHome = Create<QWindow_Home>(QManagerPrefab.Instance.prefab_Window_Home);
        windowExercises = Create<QWindow_Exercises>(QManagerPrefab.Instance.prefab_Window_Exercises);
        windowDictionary = Create<QWindow_Dictionary>(QManagerPrefab.Instance.prefab_Window_Dictionary);
        windowTranslator = Create<QWindow_Translator>(QManagerPrefab.Instance.prefab_Window_Translator);
        windowSettings = Create<QWindow_Settings>(QManagerPrefab.Instance.prefab_Window_Settings);

        windowHome.AwakeCycle();
        windowExercises.AwakeCycle();
        windowDictionary.AwakeCycle();
        windowTranslator.AwakeCycle();
        windowSettings.AwakeCycle();
    }

    protected override void OnStart() {
        windowHome.StartCycle();
        windowExercises.StartCycle();
        windowDictionary.StartCycle();
        windowTranslator.StartCycle();
        windowSettings.StartCycle();
    }

    protected override void OnUpdate() {
    }

}
