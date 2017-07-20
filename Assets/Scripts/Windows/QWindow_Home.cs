using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QWindow_Home : QWindow {

    public GameObject prefab_Button_HomeItem;

    protected override void OnAwake() {
        base.OnAwake();

        // Create all windows and link to home page
        foreach (var prefab in subWindows) {
            SpawnWindow<QWindow>(prefab);
        }

        SpawnButtons();

        // Launch Awake cycle on child contollers
        foreach (var w in _windowGroup.windows) {
            w.AwakeCycle();
        }
    }

    protected override void OnStart() {
        base.OnStart();

        foreach (var w in _windowGroup.windows) {
            w.StartCycle();
        }

        Activate();
    }

    protected override void OnUpdate() {
    }

    protected override void OnActivate() {
    }

    protected override void OnDeactivate() {
    }


    // -------------------------------------------- Private stuff
    private void SpawnButtons() {
        foreach (var w in _windowGroup.windows) {
            SpawnButton(new QButtonData(w));
        }

        SpawnButton(new QButtonData("home_name_exit", () => {
            QApp.Instance.SaveAppData();
            Application.Quit();
        }));
    }

    private  QButtonText SpawnButton(QButtonData b) {
        var btn = Create<QButtonText>(prefab_Button_HomeItem, containerContent.transform);
        btn.Initialize(b);
        return btn;
    }
}
