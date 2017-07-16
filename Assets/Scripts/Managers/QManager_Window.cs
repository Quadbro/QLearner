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

    /*

    public QWindow_Home WindowHome {
        get { return _windowHome; }
    }

    public QWindow_Exercises WindowExercises {
        get { return _windowExercises; }
    }

    public QWindow_Dictionary WindowDictionary {
        get { return _windowDictionary; }
    }

    public QWindow_Translator WindowTranslator {
        get { return _windowTranslator; }
    }

    public QWindow_Settings WindowSettings {
        get { return _windowSettings; }
    }

    public QWindow_Web WindowWeb {
        get { return _windowWeb; }
    }

    public QWindow_User WindowUser {
        get { return _windowUser; }
    }


    private QWindow_Home _windowHome;
    private QWindow_Exercises _windowExercises;
    private QWindow_Dictionary _windowDictionary;
    private QWindow_Translator _windowTranslator;
    private QWindow_Settings _windowSettings;
    private QWindow_Web _windowWeb;
    private QWindow_User _windowUser;
    */

    //private List<QWindow> _windows;
    private QWindowGroup _mainWindowGroup;

    //public List<QWindow> Windows {
    //    get { return _windows; }
    //}


    protected override void OnAwake() {

        gameObject.ClearAllChildren();

       // _windows = new List<QWindow>();
        _mainWindowGroup = new QWindowGroup();

        foreach (var prefab in QManager_Prefab.Instance.prefab_Windows_Main) {
            var ex = Create<QWindow>(prefab, transform);
            _mainWindowGroup.Link(ex);
           // _windows.Add(ex);
        }

        foreach (var window in _mainWindowGroup.windows) {
            window.AwakeCycle();
        }

        
        /*
        _windowHome = Create<QWindow_Home>(QManager_Prefab.Instance.prefab_Window_Home, transform);
        _windowExercises = Create<QWindow_Exercises>(QManager_Prefab.Instance.prefab_Window_Exercises, transform);
        _windowDictionary = Create<QWindow_Dictionary>(QManager_Prefab.Instance.prefab_Window_Dictionary, transform);
        _windowTranslator = Create<QWindow_Translator>(QManager_Prefab.Instance.prefab_Window_Translator, transform);
        _windowSettings = Create<QWindow_Settings>(QManager_Prefab.Instance.prefab_Window_Settings, transform);
        _windowWeb = Create<QWindow_Web>(QManager_Prefab.Instance.prefab_Window_Web, transform);
        _windowUser = Create<QWindow_User>(QManager_Prefab.Instance.prefab_Window_User, transform);

        _windowHome.Initialize(new QWindowData("home_name_home"));
        _windowExercises.Initialize(new QWindowData("home_name_exercises"));
        _windowDictionary.Initialize(new QWindowData("home_name_dictionary"));
        _windowTranslator.Initialize(new QWindowData("home_name_translator"));
        _windowSettings.Initialize(new QWindowData("home_name_settings"));
        _windowWeb.Initialize(new QWindowData("home_name_web"));
        _windowUser.Initialize(new QWindowData("home_name_user"));

        _windowHome.AwakeCycle();
        _windowExercises.AwakeCycle();
        _windowDictionary.AwakeCycle();
        _windowTranslator.AwakeCycle();
        _windowSettings.AwakeCycle();
        */

        /*
        _windowHome.SetButtons(new List<QButtonData> {
            new QButtonData(_windowTranslator),
            new QButtonData(_windowExercises),
            new QButtonData(_windowDictionary),
            new QButtonData(_windowWeb),
            new QButtonData(_windowSettings),

            new QButtonData("home_name_exit", Application.Quit),
        });
        */
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
        /*
        _windowHome.StartCycle();
        _windowExercises.StartCycle();
        _windowDictionary.StartCycle();
        _windowTranslator.StartCycle();
        _windowSettings.StartCycle();
        */
        //_windowHome.Activate();
    }

    protected override void OnUpdate() {
    }

}
