using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
  [TestClass()]
  public class OrbitTests
  {
    [TestMethod()]
    public void CircularOrbitAtZeroHasZeroAnglesAndMeanDistance()
    {
      Orbit orbit = new Orbit { Period = 1, MeanDistance = 1, Eccentricity = 0, Inclination = 0, PeriapsisArgument = 0 };
      var position = OrbitMechanics.CalculatePosition(0, orbit);
      Assert.AreEqual(0, position.Polar);
      Assert.AreEqual(0, position.Elevation);
      Assert.AreEqual(1, position.Radius);
    }

    [TestMethod()]
    public void CircularOrbitAtHalfYearHas180PolarAngleAndMeanDistance()
    {
      Orbit orbit = new Orbit { Period = 1, MeanDistance = 1, Eccentricity = 0, Inclination = 0, PeriapsisArgument = 0 };
      var position = OrbitMechanics.CalculatePosition(0.5f, orbit);
      Assert.AreEqual(Math.PI, position.Polar, 0.00001);
      Assert.AreEqual(0, position.Elevation);
      Assert.AreEqual(1, position.Radius);
    }

    [TestMethod()]
    public void CircularOrbitAtOneQyarterYearHas90PolarAngleAndMeanDistance()
    {
      Orbit orbit = new Orbit { Period = 1, MeanDistance = 1, Eccentricity = 0, Inclination = 0, PeriapsisArgument = 0 };
      var position = OrbitMechanics.CalculatePosition(0.25f, orbit);
      Assert.AreEqual(Math.PI/2, position.Polar, 0.00001);
      Assert.AreEqual(0, position.Elevation);
      Assert.AreEqual(1, position.Radius);
    }

    [TestMethod()]
    public void CircularOrbitAtThreeQyartersYearHas270PolarAngleAndMeanDistance()
    {
      Orbit orbit = new Orbit { Period = 1, MeanDistance = 1, Eccentricity = 0, Inclination = 0, PeriapsisArgument = 0 };
      var position = OrbitMechanics.CalculatePosition(0.75f, orbit);
      Assert.AreEqual(Math.PI + Math.PI / 2, position.Polar, 0.00001);
      Assert.AreEqual(0, position.Elevation);
      Assert.AreEqual(1, position.Radius);
    }
  }
}