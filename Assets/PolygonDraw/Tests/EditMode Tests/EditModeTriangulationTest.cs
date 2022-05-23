using System.Collections;
using System.Collections.Generic;
using AlonDorn.Geometry;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditModeTriangulationTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void EditModeTriangulationSimplePasses()
    {
        // Use the Assert class to test conditions
        Vector3[] points = new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(0, 1, 0) };
        int[] triangles = Triangulator.GetTriangles(points);
        Debug.Log($"Triangulation test finished - {triangles.Length}");
    }

    
}
