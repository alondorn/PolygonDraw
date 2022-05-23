using System.Collections.Generic;
using UnityEngine;


namespace AlonDorn.Geometry
{
    public class Triangulator
    {

        public static int[] GetTriangles(Vector3[] points)
        {
            List<int> triangles = new List<int>();
            List<int> indexes = new List<int>();
            for (int i = 0; i < points.Length; i++)
            {
                indexes.Add(i);
            }
            bool isPointIn;

            int counter = indexes.Count;

            while (indexes.Count > 3)
            {
                for (int i = 0; i < indexes.Count - 2; i++)
                {
                    isPointIn = false;
                    for (int j = 0; j < indexes.Count; j++)
                    {
                        if (j == i || j == i + 1 || j == i + 2)
                            continue;

                        if (GeometryUtils.IsPointInTriangle(points[indexes[i]], points[indexes[i + 1]], points[indexes[i + 2]], points[indexes[j]]))
                        {
                            isPointIn = true;
                            break;
                        }
                    }
                    if (!isPointIn)
                    {
                        triangles.AddRange(new int[3] { indexes[i], indexes[i + 1], indexes[i + 2] });
                        indexes.RemoveAt(i + 1);
                        break;
                    }
                }

                counter--;
                if (counter <= 0)
                {
                    Debug.LogWarning($"Triangulator ended by counter vertexIndexes.Count = { indexes.Count}");
                }
            }

            if (indexes.Count >= 3)
            {
                triangles.AddRange(new int[3] { indexes[0], indexes[1], indexes[2] });
            }
            if (indexes.Count != 3)
            {
                Debug.LogWarning($"vertexIndexes.Count == { indexes.Count} !!!");
            }

            return triangles.ToArray();
        }



    }
}

