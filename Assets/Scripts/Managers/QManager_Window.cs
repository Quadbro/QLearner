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

    public QWindow CurrentWindowLink {
        get { return _currentWindowLink; }
        set { _currentWindowLink = value; }
    }

    // Actions for main buttons (overidable by any window controller)
    public Action HomeButtonAction;
    public Action UserButtonAction;

    // Links for header and main buttons
    public QLocalizedText appHeader;
    public QButtonImage homeButton;
    public QButtonImage userButton;

    // Prefabs for starting window and account window
    public GameObject mainWindowPrefab;
    public GameObject userWindowPrefab;

    // Links for starting window and account window
    private QWindow _mainWindow;
    private QWindow _userWindow;

    private QWindow _currentWindowLink;


    protected override void OnAwake() {
        transform.ClearAllChildren();


        appHeader.color = QManager_Theme.Instance.CurrentScheme.highlight;
        appHeader.isUpperCased = true;

        _mainWindow = Create<QWindow>(mainWindowPrefab, transform);

        _mainWindow.AwakeCycle();

        _userWindow = _mainWindow.SpawnWindow<QWindow>(userWindowPrefab);

        _userWindow.AwakeCycle();

        //_userWindow.AwakeCycle();

        homeButton.Initialize(new QButtonData(null, () => {
            if (HomeButtonAction != null) {
                HomeButtonAction();
            }
        }));

        userButton.Initialize(new QButtonData(null, () => {
            if (UserButtonAction != null) {
                UserButtonAction();
            }
        }));

    }

    protected override void OnStart() {
        _mainWindow.StartCycle();

        //_userWindow.StartCycle();

        _mainWindow.Activate();
    }

    protected override void OnUpdate() {
    }

    public void SetHeaderLocalizedText(string key) {
        appHeader.Key = key;
    }

    public void SetHeaderText(string text) {
        appHeader.Key = null;
        appHeader.text = text;
    }

}
