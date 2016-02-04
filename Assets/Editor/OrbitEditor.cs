using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(OrbitMotion))]
public class OrbitEditor : Editor
{
  public override void OnInspectorGUI()
  {
    OrbitMotion myTarget = (OrbitMotion)target;
    EditorGUILayout.Space();
    GUILayout.Label("Orbit Data", EditorStyles.boldLabel);
    myTarget.period = EditorGUILayout.FloatField("Period", myTarget.period);
    myTarget.eccentricity = EditorGUILayout.FloatField("Eccentricity", myTarget.eccentricity);
    myTarget.inclination = EditorGUILayout.FloatField("Inclination", myTarget.inclination);
    myTarget.periapsisShift = EditorGUILayout.FloatField("Periapsis shift", myTarget.periapsisShift);
    myTarget.orbitCenter = (GameObject)EditorGUILayout.ObjectField("Orbit centre", myTarget.orbitCenter, typeof(GameObject), true);
    GUILayout.Label("Animation", EditorStyles.boldLabel);
    myTarget.initialOrbitTime = EditorGUILayout.FloatField("Start orbit time", myTarget.initialOrbitTime);
    GUILayout.Label("Orbit Path", EditorStyles.boldLabel);
    myTarget.orbitPathSegments = EditorGUILayout.IntField("Display segments", myTarget.orbitPathSegments);

    //myTarget.Init();
    //myTarget.DrawOrbit(true);
  }
}
