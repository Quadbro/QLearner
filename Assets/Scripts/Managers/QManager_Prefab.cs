using UnityEngine;
using System.Collections;

public class QManager_Prefab : QManager<QManager_Prefab> {

    public GameObject prefab_Window_Home;
    public GameObject prefab_Window_Exercises;
    public GameObject prefab_Window_Dictionary;
    public GameObject prefab_Window_Translator;
    public GameObject prefab_Window_Settings;
    public GameObject prefab_Window_Web;
    public GameObject prefab_Window_User;

    public GameObject prefab_Button_HomeItem;
    public GameObject prefab_Button_ExerciseItem;

    protected override void OnAwake() {
    }

    protected override void OnStart() {
    }

    protected override void OnUpdate() {
    }
}
