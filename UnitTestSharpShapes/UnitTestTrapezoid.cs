﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;

namespace UnitTestSharpShapes
{
    [TestClass]
    public class UnitTestTrapezoids
    {
        [TestMethod]
        public void TestTrapezoidConstructorSetsProperties()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            Assert.AreEqual(8, trapezoid.LongBase);
            Assert.AreEqual(2, trapezoid.ShortBase);
            Assert.AreEqual(4, trapezoid.Height);
        }

        [TestMethod]
        public void TestTrapezoidConstructorSetsProperties2()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual(20, trapezoid.LongBase);
            Assert.AreEqual(15, trapezoid.ShortBase);
            Assert.AreEqual(2, trapezoid.Height);
        }

        [TestMethod]
        public void TestTrapezoidConstructorCalculatesAngles1()
        {
            Trapezoid trapezoid = new Trapezoid(8, 4, 2);
            Assert.AreEqual(45, trapezoid.AcuteAngle);
            Assert.AreEqual(135, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        public void TestTrapezoidConstructorCalculatesAngles2()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual((decimal)38.66, trapezoid.AcuteAngle);
            Assert.AreEqual((decimal)141.34, trapezoid.ObtuseAngle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidConstructorSanityChecksBaseLengths()
        {
            new Trapezoid(15, 20, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidConstructorSanityChecksLongBaseLength()
        {
            new Trapezoid(0, 20, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidTrapezoidCantBeRectangle()
        {
            new Trapezoid(20, 20, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidConstructorSanityChecksShortBaseLength()
        {
            new Trapezoid(15, 0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrapezoidConstructorSanityChecksHeight()
        {
            new Trapezoid(15, 20, 0);
        }

        [TestMethod]
        public void TestTrapezoidSidesCount()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual(4, trapezoid.SidesCount);
        }

        [TestMethod]
        public void TestDefaultTrapezoidColors()
        {
            Trapezoid shape = new Trapezoid(20, 15, 2);
            Assert.AreEqual(System.Drawing.Color.Bisque, shape.FillColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, shape.BorderColor);
        }
    }
}
