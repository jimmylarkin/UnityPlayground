using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpaceObject
{
  /// <summary>
  /// Name of the object
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// Mass as multiplication of Earth mass for planet or Sun mass for stars
  /// </summary>
  public float Mass { get; set; }

  /// <summary>
  /// Number of hours to full rotation
  /// </summary>
  public float Rotation { get; set; }

  /// <summary>
  /// Size as multiplication of Earth size for planets or Sun size for stars
  /// </summary>
  public float Size { get; set; }

  /// <summary>
  /// List of objects that are orbiting this object
  /// </summary>
  public List<SpaceObject> OrbitingObjects { get; private set; }

  /// <summary>
  /// System the object is located in
  /// </summary>
  public PlanetarySystem System { get; set; }

  /// <summary>
  /// Orbit data
  /// </summary>
  public Orbit Orbit { get; set; }

  /// <summary>
  /// Position in spherical coordinates relative to the orbit centre
  /// </summary>
  public SphericalCoordinates CurrentPosition { get; set; }

  public GameObject UnityObject { get; set; }

  public SpaceObject()
  {
    OrbitingObjects = new List<SpaceObject>();
  }
}
