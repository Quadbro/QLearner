using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QApp : QSingleton<QApp> {

    public Canvas canvas;

    private void Awake() {
        OnAwake();
    }

    private void Start () {
        OnStart();
    }

    private void Update () {
        OnUpdate();
    }

    protected override void OnAwake() {
        QManager_Window.Instance.AwakeCycle();
        QManager_Prefab.Instance.AwakeCycle();
    }

    protected override void OnStart() {
        QManager_Window.Instance.StartCycle();
        QManager_Prefab.Instance.StartCycle();
    }

    protected override void OnUpdate() {
        QManager_Window.Instance.UpdateCycle();
    }
}
