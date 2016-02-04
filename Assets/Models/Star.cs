using UnityEngine;
using System.Collections;

public class Star : SpaceObject
{
  /// <summary>
  /// Class of the star
  /// </summary>
  public StarClass Class { get; set; }

  /// <summary>
  /// Temperature in K 
  /// </summary>
  public int Temperature { get; set; }

  /// <summary>
  /// Absolute magnitude 
  /// </summary>
  public float Magnitude { get; set; }
}
