using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class ExercisePlacer : MonoBehaviour {
    public GameObject exerciseButtonPrefab;
    public string[] exercises;


    public float widthBarier = 200f;


    public GameObject container;
    public GameObject linePrefab;

    // Use this for initialization
    void Start() {

        var mainRectTransform = container.GetComponent<RectTransform>();
        var width = mainRectTransform.rect.width;
        var rows = (int) (width / widthBarier);
        if (rows == 0) {
            rows = 1;
        }

        var currentRow = SpawnNewLine();
        Debug.Log(width + " " + widthBarier + " " + 0/8);

        Debug.Log(rows);
        for (var i = 0; i < exercises.Length; i++) {
            SpawnNewButton(currentRow, exercises[i]);

            if ((i + 1) % rows == 0) {
                currentRow = SpawnNewLine();
            }
        }
    }

    private HorizontalLayoutGroup SpawnNewLine() {
        var go = Instantiate(linePrefab);
        go.transform.parent = container.transform;
        return go.GetComponent<HorizontalLayoutGroup>();
    }

    private void SpawnNewButton(HorizontalLayoutGroup line, string text) {
        var go = Instantiate(exerciseButtonPrefab);
        go.transform.parent = line.transform;
        go.GetComponentInChildren<Text>().text = text;
    }

    // Update is called once per frame
    void Update() { }
}
