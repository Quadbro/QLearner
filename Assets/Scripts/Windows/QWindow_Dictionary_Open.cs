using UnityEngine;
using System.Collections;

public class QWindow_Dictionary_Open : QWindow {

    protected override void OnAwake() {
        base.OnAwake();
    }

    protected override void OnStart() {
        base.OnStart();
    }

    protected override void OnUpdate() {
    }

    protected override void OnActivate() {
    }

    protected override void OnDeactivate() {
        if (_parentWindow) {
            if (_parentWindow.WindowGroup != null) {
                _parentWindow.WindowGroup.Unlink(this);
            }
        }

        Destroy(gameObject);
    }
}
