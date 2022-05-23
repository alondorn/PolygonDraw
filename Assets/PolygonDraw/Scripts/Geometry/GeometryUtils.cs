using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlonDorn.Geometry
{
    public class GeometryUtils
    {

        public static bool IsPointInTriangle(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
        {
            // Move the triangle so that the point becomes the 
            // triangles origin
            a -= p;
            b -= p;
            c -= p;

            // Compute the normal vectors for triangles:
            Vector3 u = Vector3.Cross(b, c);
            Vector3 v = Vector3.Cross(c, a);
            Vector3 w = Vector3.Cross(a, b);

            // Test to see if the normals are facing 
            // the same direction, return false if not
            if (Vector3.Dot(u, v) < 0f)
            {
                return false;
            }
            if (Vector3.Dot(u, w) < 0.0f)
            {
                return false;
            }

            // All normals facing the same way, return true
            return true;
        }
    }
}

