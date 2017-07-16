using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QManager_Prefab : QManager<QManager_Prefab> {

    [Header("Windows")]
    public List<GameObject> prefab_Windows_Main;

    [Header("Ecercises")]
    public List<GameObject> prefab_Exercises;

    [Header("Buttons")]
    public GameObject prefab_Button_HomeItem;
    public GameObject prefab_Button_ExerciseItem;

    protected override void OnAwake() {
    }

    protected override void OnStart() {
    }

    protected override void OnUpdate() {
    }
}
