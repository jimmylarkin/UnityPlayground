using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PlanetSystemController))]
public class PlanetSystemControllerEditor : Editor
{
  public override void OnInspectorGUI()
  {
    PlanetSystemController myTarget = target as PlanetSystemController;
    EditorGUILayout.Space();
    myTarget.EarthSizeToWorldUnits = EditorGUILayout.FloatField("Earth size", myTarget.EarthSizeToWorldUnits);
    myTarget.SunSizeToWorldUnits = EditorGUILayout.FloatField("Sun size", myTarget.SunSizeToWorldUnits);
    myTarget.AUToWorldUnits = EditorGUILayout.FloatField("1 AU", myTarget.AUToWorldUnits);
    myTarget.EarthYearInSeconds = EditorGUILayout.IntField("Seconds for Earth year", myTarget.EarthYearInSeconds);
    myTarget.StartTime = EditorGUILayout.FloatField("Start time", myTarget.StartTime);
}
}
