using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class QManager_Window : QManager<QManager_Window> {

    public QLocalizedText appHeader;
    public Button homeButton;
    public Button userButton;

    private QWindowGroup _mainWindowGroup;

    protected override void OnAwake() {

        gameObject.ClearAllChildren();

        _mainWindowGroup = new QWindowGroup();

        foreach (var prefab in QManager_Prefab.Instance.prefab_Windows_Main) {
            var ex = Create<QWindow>(prefab, transform);
            _mainWindowGroup.Link(ex);
        }

        foreach (var window in _mainWindowGroup.windows) {
            window.AwakeCycle();
        }

        homeButton.onClick.AddListener(() => {
            var w = FindWindow(typeof(QWindow_Home));
            if (w) {
                w.Activate();
            }
        });

        userButton.onClick.AddListener(() => {
            var w = FindWindow(typeof(QWindow_User));
            if (w) {
                w.Activate();
            }
        });
    }

    private QWindow FindWindow(Type t) {
        foreach (var window in _mainWindowGroup.windows) {
            if (window.GetType() == t) { 
                return window;
            }
        }
        return null;
    }

    protected override void OnStart() {
        foreach (var window in _mainWindowGroup.windows) {
            window.StartCycle();
        }
    }

    protected override void OnUpdate() {
    }

}
