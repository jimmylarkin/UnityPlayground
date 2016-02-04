using UnityEngine;
using System.Collections;

public class Orbit {
  /// <summary>
  /// Mean distance in AU from the body this object os orbiting around (parameter a in Kepler equations)
  /// </summary>
  public float MeanDistance { get; set; }

  /// <summary>
  /// Object that thsi object orbits
  /// </summary>
  public SpaceObject OrbitCentre { get; set; }

  /// <summary>
  /// Eccenctricity of the orbit - see Kepler laws
  /// </summary>
  public float Eccentricity { get; set; }

  /// <summary>
  /// Inclination of the orbit in degrees - see Kepler laws (tilt along Z axis)
  /// </summary>
  public float Inclination { get; set; }

  /// <summary>
  /// Argument of periapsis in degrees - see Kepler laws (rotation around Y axis)
  /// </summary>
  public float PeriapsisArgument { get; set; }

  public float InclinationRadians
  {
    get { return Inclination * Mathf.Deg2Rad; }
  }

  public float PeriapsisArgumentRadians
  {
    get { return PeriapsisArgument * Mathf.Deg2Rad; }
  }
  /// <summary>
  /// Period of the orbit in Earth years
  /// </summary>
  public float Period { get; set; }
}
