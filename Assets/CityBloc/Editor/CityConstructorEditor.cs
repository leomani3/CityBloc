using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ConstructCity))]
public class CityConstructorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Build city"))
        {
            ((ConstructCity)target).BuildCity();
        }
    }
}
