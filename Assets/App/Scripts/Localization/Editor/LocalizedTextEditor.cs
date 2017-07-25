using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizedTextEditor : EditorWindow {
    public LocalizationData localizationData;

    [MenuItem("Window/Localized Text Editor")]
    static void Init() {
        GetWindow(typeof(LocalizedTextEditor)).Show();
    }

    private void OnGUI() {
        if (localizationData != null) {
            var serializedObject = new SerializedObject(this);
            var serializedProperty = serializedObject.FindProperty("localizationData");
            EditorGUILayout.PropertyField(serializedProperty, true);
            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save data")) {
                SaveGameData();
            }
        }

        if (GUILayout.Button("Load data")) {
            LoadGameData();
        }

        if (GUILayout.Button("Create new data")) {
            CreateNewData();
        }
    }

    private void LoadGameData() {
        var filePath = EditorUtility.OpenFilePanel("Select localization data file", Application.streamingAssetsPath + "/Localization", "json");

        if (!string.IsNullOrEmpty(filePath)) {
            var dataAsJson = File.ReadAllText(filePath);

            localizationData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
        }
    }

    private void SaveGameData() {
        var filePath = EditorUtility.SaveFilePanel("Save localization data file", Application.streamingAssetsPath + "/Localization", "", "json");

        if (!string.IsNullOrEmpty(filePath)) {
            var dataAsJson = JsonUtility.ToJson(localizationData, true);
            File.WriteAllText(filePath, dataAsJson);
        }
    }

    private void CreateNewData() {
        localizationData = new LocalizationData();
    }

}