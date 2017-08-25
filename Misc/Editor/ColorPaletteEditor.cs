using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(ColorPalette))]
public class ColorPaletteEditor : Editor {
    private SerializedObject _serializedPalette;

    public void OnEnable() {
        _serializedPalette = new SerializedObject(target);
    }

    public override void OnInspectorGUI() {
        ColorPalette colorPalette = (ColorPalette)target;

        for(int i = 0; i < colorPalette.colorList.Count; i++) {
            if(colorPalette.colorList[i] == null) {
                colorPalette.colorList[i] = new ColorProfile();
            }

            EditorGUILayout.BeginHorizontal();
            colorPalette.colorList[i].color = EditorGUILayout.ColorField(colorPalette.colorList[i].color);
            colorPalette.colorList[i].channel = (ColorProfile.Chroma)EditorGUILayout.EnumPopup(colorPalette.colorList[i].channel);         
            colorPalette.colorList[i].value = EditorGUILayout.IntField(colorPalette.colorList[i].value);

            if(GUILayout.Button("x")) {
                colorPalette.colorList.RemoveAt(i);
                break;
            }
            EditorGUILayout.EndHorizontal();
        }

        if(GUILayout.Button("Add Color Profile")) {
            colorPalette.colorList.Add(new ColorProfile());
        }

        if(GUI.changed) {
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            EditorUtility.SetDirty(target);
            EditorUtility.SetDirty(colorPalette);
        }
        _serializedPalette.ApplyModifiedProperties();
    }
}
