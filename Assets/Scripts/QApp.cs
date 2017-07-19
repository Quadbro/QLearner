using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QApp : QSingleton<QApp> {

    public Canvas canvas;
    public Image background;

    public UserData User {
        get { return _user; }
    }

    private UserData _user;

    private void Awake() {

        OnAwake();
    }

    private void Start () {
        OnStart();
    }

    private void Update () {
        OnUpdate();

        
    }

    public void SaveAppData() {
        if (_user == null) {
            _user = new UserData("test", "1234");
            Debug.Log("User was NULL, Saved default [test] data.");
        }

        SaveJsonData(_user, "Data/Users", _user.username);
    }

    public void LoadAppData() {
        _user = LoadJsonData<UserData>("Data/Users", "test");
    }

    public void ApplyLoadedData() {
        if (_user != null) {
            QManager_Localization.Instance.Language = _user.settings.interfaceLanguage;
        }
    }

    protected override void OnAwake() {
        DontDestroyOnLoad(gameObject);

        background.color = QManager_Theme.Instance.CurrentScheme.background;

        LoadAppData();

        QManager_Localization.Instance.AwakeCycle();
        QManager_Window.Instance.AwakeCycle();
    }

    protected override void OnStart() {
        QManager_Window.Instance.StartCycle();

        ApplyLoadedData();
    }

    protected override void OnUpdate() {
        QManager_Window.Instance.UpdateCycle();

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            QManager_Localization.Instance.Language = QManager_Localization.Instance.Language == Language.en ? Language.ru : Language.en;

            if (_user != null) {
                _user.settings.interfaceLanguage = QManager_Localization.Instance.Language;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SaveAppData();
        }
    }


    public T LoadJsonData<T>(string path, string fileName) {
        var filePath = Application.streamingAssetsPath + "/" + path + "/" + fileName + ".json";
        if(File.Exists(filePath)) {
            var dataAsJson = File.ReadAllText(filePath);
            var loadedData = JsonUtility.FromJson<T>(dataAsJson);

            Debug.Log(loadedData != null
                ? string.Format("[{0}] Loaded", typeof(T))
                : string.Format("Data for [{0}] is NULL. =(", typeof(T)));

            return loadedData;

        }

        Debug.LogError("Cannot find file! " + filePath);

        return default(T);
    }

    public void SaveJsonData<T>(T obj, string path, string fileName, bool prettify = true) {
        var directoryPath = Application.streamingAssetsPath + "/" + path;
        var filePath = directoryPath + "/" + fileName + ".json";

        Directory.CreateDirectory(directoryPath);

        var jsonData = JsonUtility.ToJson(obj, prettify);

        File.WriteAllText(filePath, jsonData);

        Debug.Log(string.Format("[{0}] Saved.", typeof(T)));
    }
}
