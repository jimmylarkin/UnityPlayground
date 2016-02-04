using UnityEngine;
using System.Collections;

public static class OrbitMechanics
{
  /// <summary>
  /// Precision needed to calculate anomaly
  /// </summary>
  private static float anomalyPrecision = 5;

  /// <summary>
  /// Calculates position of the orbiting body for given time. It also updates <see cref="CurrentPosition"/> property.
  /// </summary>
  /// <param name="time">time from the creation of the start system (time 0)</param>
  /// <returns>Position as spherical coordinates</returns>
  public static SphericalCoordinates CalculatePosition(float time, Orbit orbitData)
  {
    time = Mathf.Repeat(time, orbitData.Period);
    //mean anomaly
    float n = 2f * Mathf.PI / orbitData.Period;
    float M = n * time;

    //eccentric anomaly
    float deltaMax = Mathf.Pow(10, anomalyPrecision * -1);
    float E = M;
    float error = E - orbitData.Eccentricity * Mathf.Sin(E) - M;
    int i = 0;
    while (Mathf.Abs(error) > deltaMax && i < 5)
    {
      E = E - error / (1f - orbitData.Eccentricity * Mathf.Cos(E));
      error = E - orbitData.Eccentricity * Mathf.Sin(E) - M;
      i++;
    }

    //true anomaly
    var S = Mathf.Sin(E);
    var C = Mathf.Cos(E);
    var fak = Mathf.Sqrt(1f - orbitData.Eccentricity * orbitData.Eccentricity);
    float phi = Mathf.Atan2(fak * S, C - orbitData.Eccentricity);

    //distance
    // float r = MeanDistance * (1 - Eccentricity * Eccentricity) / (1 + Eccentricity * Mathf.Cos(phi));
    float r = orbitData.MeanDistance * (1 - orbitData.Eccentricity * Mathf.Cos(E));
    phi = phi + orbitData.PeriapsisArgumentRadians;
    float elevation = orbitData.InclinationRadians * Mathf.Cos(phi);
    return new SphericalCoordinates(r, phi, elevation);
  }

  public static void SetPositionAtTime(float time, SpaceObject spaceObject)
  {
    if (spaceObject.Orbit != null)
    {
      spaceObject.CurrentPosition = CalculatePosition(time, spaceObject.Orbit);
    }
    else
    {
      spaceObject.CurrentPosition = new SphericalCoordinates(0, 0, 0);
    }
    foreach (SpaceObject orbitingObject in spaceObject.OrbitingObjects)
    {
      SetPositionAtTime(time, orbitingObject);
    }
  }
}
