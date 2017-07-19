using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class QManager_Window : QManager<QManager_Window> {

    // Getters
    public QWindow MainWindow {
        get { return _mainWindow; }
    }
    public QWindow UserWindow {
        get { return _userWindow; }
    }

    // Actions for main buttons (overidable by any window controller)
    public Action HomeButtonAction;
    public Action UserButtonAction;

    // Links for header and main buttons
    public QLocalizedText appHeader;
    public Button homeButton;
    public Button userButton;

    // Prefabs for starting window and account window
    public GameObject mainWindowPrefab;
    public GameObject userWindowPrefab;

    // Links for starting window and account window
    private QWindow _mainWindow;
    private QWindow _userWindow;


    protected override void OnAwake() {

        transform.ClearAllChildren();

        _mainWindow = Create<QWindow>(mainWindowPrefab, transform);

        _mainWindow.AwakeCycle();

        _userWindow = _mainWindow.SpawnWindow(userWindowPrefab);

        _userWindow.AwakeCycle();

        //_userWindow.AwakeCycle();

        homeButton.onClick.AddListener(() => {
            if (HomeButtonAction != null) {
                HomeButtonAction();
            }
        });

        userButton.onClick.AddListener(() => {
            if (UserButtonAction != null) {
                UserButtonAction();
            }
        });
    }

    protected override void OnStart() {
        _mainWindow.StartCycle();
        //_userWindow.StartCycle();

        _mainWindow.Activate();
    }

    protected override void OnUpdate() {
    }

}
