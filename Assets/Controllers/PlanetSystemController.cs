using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
public class PlanetSystemController : MonoBehaviour
{
  public const int SecondsInYear = 31557600;
  public const int SecondsInDay = 86400;
  //scales

  public float EarthSizeToWorldUnits = 0.3f;
  public float SunSizeToWorldUnits = 3;
  public float AUToWorldUnits = 10;
  public int EarthYearInSeconds = 100;
  public float StartTime = 0;
  public float currentTime = 0;

  private PlanetarySystem system;

  // Use this for initialization
  void Start()
  {
    system = new PlanetarySystem();
    OrbitMechanics.SetPositionAtTime(currentTime, system.Star);

    //create GameObjects for the star
    GameObject starGameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    starGameObject.name = system.Star.Name;
    system.Star.UnityObject = starGameObject;
    var sizeScale = system.Star.Size * SunSizeToWorldUnits;
    starGameObject.transform.localScale = new Vector3(sizeScale, sizeScale, sizeScale);
    starGameObject.transform.position = system.Star.CurrentPosition.ToCartesian() * AUToWorldUnits;
    //create GameObjects for each object in the system
    foreach (SpaceObject orbitingObject in system.Star.OrbitingObjects)
    {
      BuildSystemGameOjects(orbitingObject, starGameObject);
      DrawOrbit(orbitingObject);
    }
  }

  private void BuildSystemGameOjects(SpaceObject spaceObject, GameObject parentGameObject)
  {
    GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    var planetMesh = gameObject.GetComponent<MeshRenderer>();
    planetMesh.material.shader = Shader.Find("Particles/Additive");
    planetMesh.material.SetColor("_TintColor", Color.blue);
    gameObject.name = spaceObject.Name;
    spaceObject.UnityObject = gameObject;
    var sizeScale = spaceObject.Size * EarthSizeToWorldUnits;
    gameObject.transform.SetParent(parentGameObject.transform);
    gameObject.transform.localScale = new Vector3(sizeScale, sizeScale, sizeScale);
    gameObject.transform.localPosition = spaceObject.CurrentPosition.ToCartesian() * AUToWorldUnits;
    foreach (SpaceObject orbitingObject in spaceObject.OrbitingObjects)
    {
      BuildSystemGameOjects(orbitingObject, gameObject);
    }
  }

  // Update is called once per frame
  void Update()
  {
    currentTime = currentTime + Time.deltaTime;
    OrbitMechanics.SetPositionAtTime(currentTime / EarthYearInSeconds, system.Star);
    TransformPlanetsPosition(system.Star);
  }

  private void TransformPlanetsPosition(SpaceObject spaceObject)
  {
    var newPosition = spaceObject.CurrentPosition.ToCartesian() * AUToWorldUnits;
    Vector3 shift = new Vector3(0, 0, 0);
    if (spaceObject.Orbit != null)
    {
      shift = spaceObject.Orbit.OrbitCentre.UnityObject.transform.position;
    }
    spaceObject.UnityObject.transform.Translate(newPosition - spaceObject.UnityObject.transform.position + shift);
    foreach (SpaceObject orbitingObject in spaceObject.OrbitingObjects)
    {
      TransformPlanetsPosition(orbitingObject);
    }
  }

  public void DrawOrbit(SpaceObject spaceObject)
  {
    GameObject orbit = new GameObject(spaceObject.Name + "_OrbitPath");
    orbit.transform.SetParent(spaceObject.Orbit.OrbitCentre.UnityObject.transform);
    var orbitPath = orbit.AddComponent<LineRenderer>();
    orbitPath.SetWidth(0.5f, 0.5f);
    orbitPath.material.shader = Shader.Find("Standard");
    orbitPath.receiveShadows = false;
    orbitPath.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    orbitPath.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f));
    orbitPath.useWorldSpace = false;
    int segmentCount = Mathf.CeilToInt(spaceObject.Orbit.Period) * EarthYearInSeconds;
    if (segmentCount < 50)
    {
      segmentCount = 50;
    }
    if (segmentCount > 200)
    {
      segmentCount = 200;
    }
    orbitPath.SetVertexCount(segmentCount + 1);

    var step = spaceObject.Orbit.Period / segmentCount;
    for (int i = 0; i < (segmentCount + 1); i++)
    {
      var newPositionRadial = OrbitMechanics.CalculatePosition(step * i, spaceObject.Orbit);
      orbitPath.SetPosition(i, newPositionRadial.ToCartesian() * AUToWorldUnits + spaceObject.Orbit.OrbitCentre.UnityObject.transform.position);
    }
    foreach (SpaceObject orbitingObject in spaceObject.OrbitingObjects)
    {
      DrawOrbit(orbitingObject);
    }
  }
}
