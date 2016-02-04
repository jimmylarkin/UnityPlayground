using UnityEngine;
using System.Collections;

public class SphericalCoordinates
{
  private float polar;
  private float elevation;
  private const float minPolar = 0, maxPolar = Mathf.PI * 2f, minElevation = 0, maxElevation = Mathf.PI * 2f;

  public float Radius { get; set; }

  public float Polar
  {
    get
    {
      return polar;
    }
    set
    {
      polar = Mathf.Repeat(value, maxPolar - minPolar);
    }
  }

  public float PolarDeg
  {
    get { return Polar * Mathf.Rad2Deg; }
    set
    {
      Polar = value * Mathf.Deg2Rad;
    }
  }
  
  public float Elevation
  {
    get
    {
      return elevation;
    }
    set
    {
      elevation = Mathf.Repeat(value, maxElevation - minElevation); ;
    }
  }

  public float ElevationDeg
  {
    get { return Elevation * Mathf.Rad2Deg; }
    set
    {
      Elevation = value * Mathf.Deg2Rad;
    }
  }

  public SphericalCoordinates()
  {
  }

  public SphericalCoordinates(float radius, float polar, float elevation)
  {
    Radius = radius;
    Polar = polar;
    Elevation = elevation;
  }

  public Vector3 ToCartesian()
  {
    var result = new Vector3();
    float a = Radius * Mathf.Cos(Elevation);
    result.x = a * Mathf.Cos(Polar);
    result.y = Radius * Mathf.Sin(Elevation);
    result.z = a * Mathf.Sin(Polar);
    return result;
  }
}
