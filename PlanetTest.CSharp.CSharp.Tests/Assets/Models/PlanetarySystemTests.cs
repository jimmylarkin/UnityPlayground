using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
  [TestClass()]
  public class PlanetarySystemTests
  {
    [TestMethod()]
    public void SetPositionAtTimeSetsInitialPositionsForZeroTime()
    {
      PlanetarySystem system = new PlanetarySystem();
      OrbitMechanics.SetPositionAtTime(0, system.Star);

      var earth = system.Star.OrbitingObjects.FirstOrDefault(o => o.Name == "Terra");
      Assert.AreEqual(0, earth.CurrentPosition.Polar);
      Assert.AreEqual(0, earth.CurrentPosition.Elevation);
      Assert.AreEqual(earth.Orbit.MeanDistance, earth.CurrentPosition.Radius);
      var moon = earth.OrbitingObjects.FirstOrDefault(o => o.Name == "Luna");
      Assert.AreEqual(0, moon.CurrentPosition.Polar);
      Assert.AreEqual(0, moon.CurrentPosition.Elevation);
      Assert.AreEqual(moon.Orbit.MeanDistance, moon.CurrentPosition.Radius);
    }
  }
}