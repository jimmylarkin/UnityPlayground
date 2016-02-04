using UnityEngine;
using System.Collections;

public class OrbitMotion : MonoBehaviour
{
  public float period = 10f;  //rotation period in seconds
  public GameObject orbitCenter;
  public float eccentricity = 0.5f;
  public int orbitPathSegments = 100;
  public float initialOrbitTime = 0;
  public float inclination = 0;
  public float periapsisShift = 0;

  //consts
  float anomalyPrecision = 5;

  //variables
  float p, rMax, rMin, a, b, currentOrbitalTime;

  //called when the script instance is being loaded
  private void Awake()
  {
    if (orbitCenter != null)
    {
      Init();
      DrawOrbit();
    }
  }

  // Use this for initialization
  private void Start()
  {
  }

  // Update is called once per frame
  private void Update()
  {
    float deltaTime = Time.deltaTime;
    currentOrbitalTime = currentOrbitalTime + deltaTime;
    if (currentOrbitalTime > period)
    {
      currentOrbitalTime = deltaTime;
    }
    var newPositionRadial = Calculate(currentOrbitalTime);
    var newPosition = SphericalToCartesian(newPositionRadial.x, newPositionRadial.y, newPositionRadial.z);
    transform.Translate(newPosition - transform.position + orbitCenter.transform.position);
  }

  public void Init()
  {
    Vector3 offsetFromOrbitCenter = transform.position - orbitCenter.transform.position;
    //calculate rMin from the distance from the orbit center
    rMin = Mathf.Sqrt((offsetFromOrbitCenter.x * offsetFromOrbitCenter.x) + (offsetFromOrbitCenter.y * offsetFromOrbitCenter.y) + (offsetFromOrbitCenter.z * offsetFromOrbitCenter.z));
    Debug.Log(string.Format("rMin={0}", rMin));
    p = rMin * (1 + eccentricity);
    rMax = p / (1 - eccentricity);
    a = p / (1 - Mathf.Pow(eccentricity, 2));
    b = p / (Mathf.Sqrt(1 - Mathf.Pow(eccentricity, 2)));
    currentOrbitalTime = 0;
  }
  public Vector3 Calculate(float time)
  {
    //mean anomaly
    float n = 2f * Mathf.PI / period;
    float M = n * time;

    //eccentric anomaly
    float deltaMax = Mathf.Pow(10, anomalyPrecision * -1);
    float E = M;
    float error = E - eccentricity * Mathf.Sin(E) - M;
    int i = 0;
    while (Mathf.Abs(error) > deltaMax && i < 5)
    {
      E = E - error / (1f - eccentricity * Mathf.Cos(E));
      error = E - eccentricity * Mathf.Sin(E) - M;
      i++;
    }

    //true anomaly
    var S = Mathf.Sin(E);
    var C = Mathf.Cos(E);
    var fak = Mathf.Sqrt(1f - eccentricity * eccentricity);
    float phi = Mathf.Atan2(fak * S, C - eccentricity);

    //distance
    float r = a * (1 - eccentricity * eccentricity) / (1 + eccentricity * Mathf.Cos(phi));
    phi = phi + periapsisShift;
    float elevation = inclination * Mathf.Cos(phi);
    return new Vector3(r, phi, elevation);
  }
  public Vector3 SphericalToCartesian(float radius, float polar, float elevation)
  {
    var outCart = new Vector3();
    float a = radius * Mathf.Cos(elevation);
    outCart.x = a * Mathf.Cos(polar);
    outCart.y = radius * Mathf.Sin(elevation);
    outCart.z = a * Mathf.Sin(polar);
    return outCart;
  }

  public void DrawOrbit(bool inEditor = false)
  {
    var existingOrbit = transform.FindChild(transform.name + "_Path");
    if (existingOrbit != null)
    {
      DestroyImmediate(existingOrbit.gameObject);
      return;
    }
    GameObject orbit = new GameObject(transform.name + "_Path");
    orbit.transform.parent = orbitCenter.transform;
    var orbitPath = orbit.AddComponent<LineRenderer>();
    orbitPath.SetWidth(0.05f, 0.05f);

    if (!inEditor)
    {
      orbitPath.material.shader = Shader.Find("Particles/Additive");
      orbitPath.material.SetColor("_TintColor", Color.white);
    }
    orbitPath.useWorldSpace = false;
    orbitPath.SetVertexCount(orbitPathSegments + 1);

    var step = period / orbitPathSegments;
    for (int i = 0; i < (orbitPathSegments + 1); i++)
    {
      var newPositionRadial = Calculate(step * i);
      orbitPath.SetPosition(i, SphericalToCartesian(newPositionRadial.x, newPositionRadial.y, newPositionRadial.z) + orbitCenter.transform.position);
    }
  }
}
