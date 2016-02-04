using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetarySystem {
  public string Name { get; set; }

  public SpaceObject Star { get; set; }

  public PlanetarySystem()
  {
    GenerateTestSystem();
  }

  private void GenerateTestSystem()
  {
    Star = new Star() { Mass = 1, Size = 1, Rotation = 30, System = this, Name = "Sol" };
    var earth = new Planet() { Mass = 1, Size = 1, Rotation = 24, Name = "Earth", Orbit = new Orbit() { MeanDistance = 1, Period = 1, Eccentricity = 0.0167086f, Inclination = 7.155f, PeriapsisArgument= 114.207f, OrbitCentre = Star } };
    var moon = new Moon() { Mass = 0.0123f, Size = 0.273f, Rotation = 27, Name = "Moon", Orbit = new Orbit() { MeanDistance = 0.00257f * 40, Period = 0.0739f, Eccentricity = 0.0549f, Inclination = 5.145f, OrbitCentre = earth } };
    earth.OrbitingObjects.Add(moon);
    Star.OrbitingObjects.Add(earth);

    var jupiter = new Planet() { Mass = 317.8f, Size = 11.209f, Rotation = 9.925f, Name = "Jupiter", Orbit = new Orbit() { MeanDistance = 5.20260f, Period = 11.8618f, Eccentricity = 0.048498f, Inclination = 6.09f, PeriapsisArgument = 273.867f, OrbitCentre = Star } };
    var ganymede = new Planet() { Mass = 0.025f, Size = 0.413f, Rotation = 9.925f, Name = "Ganymede", Orbit = new Orbit() { MeanDistance = 0.00715f * 120, Period = 0.0195f, Eccentricity = 0.0013f, Inclination = 2.214f, OrbitCentre = jupiter } };
    var calisto = new Planet() { Mass = 0.018f, Size = 0.378f, Rotation = 9.925f, Name = "Calisto", Orbit = new Orbit() { MeanDistance = 0.0125f * 80, Period = 0.04569f, Eccentricity = 0.0074f, Inclination = 2.017f, OrbitCentre = jupiter } };
    var io = new Planet() { Mass = 0.015f, Size = 0.286f, Rotation = 9.925f, Name = "Io", Orbit = new Orbit() { MeanDistance = 0.002819f * 250, Period = 0.00484f, Eccentricity = 0.0041f, Inclination = 2.213f, OrbitCentre = jupiter } };
    Star.OrbitingObjects.Add(jupiter);
    jupiter.OrbitingObjects.Add(ganymede);
    jupiter.OrbitingObjects.Add(calisto);
    jupiter.OrbitingObjects.Add(io);

    var saturn = new Planet() { Mass = 95.159f, Size = 9.4492f, Rotation = 10.55f, Name = "Saturn", Orbit = new Orbit() { MeanDistance = 9.554909f, Period = 29.4571f, Eccentricity = 0.05555f, Inclination = 5.51f, PeriapsisArgument = 339.392f, OrbitCentre = Star } };
    var titan = new Planet() { Mass = 0.0225f, Size = 0.404f, Rotation = 10.55f, Name = "Titan", Orbit = new Orbit() { MeanDistance = 0.00816f * 80, Period = 0.043f, Eccentricity = 0.0288f, Inclination = 8.348f, OrbitCentre = saturn } };
    Star.OrbitingObjects.Add(saturn);
    saturn.OrbitingObjects.Add(titan);

    var uranus = new Planet() { Mass = 14.536f, Size = 4.007f, Rotation = 17.1f, Name = "Uranus", Orbit = new Orbit() { MeanDistance = 19.2184f, Period = 84.0205f, Eccentricity = 0.046381f, Inclination = 6.48f, PeriapsisArgument = 96.998f, OrbitCentre = Star } };
    Star.OrbitingObjects.Add(uranus);

    var neptune = new Planet() { Mass = 17.147f, Size = 3.883f, Rotation = 16.02f, Name = "Neptune", Orbit = new Orbit() { MeanDistance = 30.110387f, Period = 164.8f, Eccentricity = 0.009456f, Inclination = 6.43f, PeriapsisArgument = 276.336f, OrbitCentre = Star } };
    Star.OrbitingObjects.Add(neptune);

    var venus = new Planet() { Mass = 0.815f, Size = 0.9499f, Rotation = -5832.6f, Name = "Venus", Orbit = new Orbit() { MeanDistance = 0.723f, Period = 0.615f, Eccentricity = 0.006772f, Inclination = 3.86f, PeriapsisArgument = 54.884f, OrbitCentre = Star } };
    Star.OrbitingObjects.Add(venus);

    var mars = new Planet() { Mass = 0.107f, Size = 0.533f, Rotation = 24.2f, Name = "Mars", Orbit = new Orbit() { MeanDistance = 1.523f, Period = 1.88f, Eccentricity = 0.0934f, Inclination = 5.65f, PeriapsisArgument = 286.502f, OrbitCentre = Star } };
    Star.OrbitingObjects.Add(mars);

    var mercury = new Planet() { Mass = 0.055f, Size = 0.3829f, Rotation = 1407.5f, Name = "Mercury", Orbit = new Orbit() { MeanDistance = 0.387f, Period = 0.240f, Eccentricity = 0.205f, Inclination = 3.38f, PeriapsisArgument = 29.124f, OrbitCentre = Star } };
    Star.OrbitingObjects.Add(mercury);


    //var mercury = new Planet() { Mass = f, Size = f, Rotation = f, Name = "Mercury", Orbit = new Orbit() { MeanDistance = f * 40, Period = f, Eccentricity = f, Inclination = f, PeriapsisArgument = f, OrbitCentre = Star } };
    // var mercury = new Planet() { Mass = f, Size = f, Rotation = f, Name = "Mercury", Orbit = new Orbit() { MeanDistance = f  * 40, Period = f, Eccentricity = f, Inclination = f, PeriapsisArgument = f, OrbitCentre = Star } };
    // var mercury = new Planet() { Mass = f, Size = f, Rotation = f, Name = "Mercury", Orbit = new Orbit() { MeanDistance = f  * 40, Period = f, Eccentricity = f, Inclination = f, PeriapsisArgument = f, OrbitCentre = Star } };
    // var mercury = new Planet() { Mass = f, Size = f, Rotation = f, Name = "Mercury", Orbit = new Orbit() { MeanDistance = f  * 40, Period = f, Eccentricity = f, Inclination = f, PeriapsisArgument = f, OrbitCentre = Star } };
    // var mercury = new Planet() { Mass = f, Size = f, Rotation = f, Name = "Mercury", Orbit = new Orbit() { MeanDistance = f  * 40, Period = f, Eccentricity = f, Inclination = f, PeriapsisArgument = f, OrbitCentre = Star } };
  }
}
