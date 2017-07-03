using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(AgentMaster))]
public class customButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AgentMaster myScript = (AgentMaster)target;
        if (GUILayout.Button("Spawn Agent"))
        {
            myScript.SpawnTestAgent();
        }
    }

}
