
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FFT_DataManager))]
public class FFT_DataManagerInspector : Editor {
    public override void OnInspectorGUI() {
        EditorGUILayout.LabelField("testttt");
        base.OnInspectorGUI();
    }
}