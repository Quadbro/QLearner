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
        QManagerWindow.Instance.AwakeCycle();
        QManagerPrefab.Instance.AwakeCycle();
    }

    protected override void OnStart() {
        QManagerWindow.Instance.StartCycle();
        QManagerPrefab.Instance.StartCycle();
    }

    protected override void OnUpdate() {
        QManagerWindow.Instance.UpdateCycle();
    }
}
