using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class QManager_Window : QManager<QManager_Window> {

    public Text appHeader;
    public Button homeButton;
    public Button userButton;

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


    protected override void OnAwake() {

        gameObject.ClearAllChildren();

        _windowHome = Create<QWindow_Home>(QManager_Prefab.Instance.prefab_Window_Home, transform);
        _windowExercises = Create<QWindow_Exercises>(QManager_Prefab.Instance.prefab_Window_Exercises, transform);
        _windowDictionary = Create<QWindow_Dictionary>(QManager_Prefab.Instance.prefab_Window_Dictionary, transform);
        _windowTranslator = Create<QWindow_Translator>(QManager_Prefab.Instance.prefab_Window_Translator, transform);
        _windowSettings = Create<QWindow_Settings>(QManager_Prefab.Instance.prefab_Window_Settings, transform);
        _windowWeb = Create<QWindow_Web>(QManager_Prefab.Instance.prefab_Window_Web, transform);
        _windowUser = Create<QWindow_User>(QManager_Prefab.Instance.prefab_Window_User, transform);

        _windowHome.AwakeCycle();
        _windowHome.SetButtons(new List<QButtonData> {
            new QButtonData("Translator", () => {
                _windowTranslator.Activate();
            }),
            new QButtonData("Exercises", () => {
                _windowExercises.Activate();
            }),
            new QButtonData("Dictionary", () => {
                _windowDictionary.Activate();
            }),
            new QButtonData("Web", () => {
                _windowWeb.Activate();
            }),
            new QButtonData("Settings", () => {
                _windowSettings.Activate();
            }),
            new QButtonData("Exit", Application.Quit),
        });

        _windowExercises.AwakeCycle();
        _windowDictionary.AwakeCycle();
        _windowTranslator.AwakeCycle();
        _windowSettings.AwakeCycle();


        homeButton.onClick.AddListener(() => {
            _windowHome.Activate();
        });

        userButton.onClick.AddListener(() => {
            _windowUser.Activate();
        });
    }

    protected override void OnStart() {
        _windowHome.StartCycle();
        _windowExercises.StartCycle();
        _windowDictionary.StartCycle();
        _windowTranslator.StartCycle();
        _windowSettings.StartCycle();




        _windowHome.Activate();
    }

    protected override void OnUpdate() {
    }

}
