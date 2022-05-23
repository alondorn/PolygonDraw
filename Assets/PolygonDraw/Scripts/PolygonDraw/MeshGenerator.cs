using AlonDorn.Geometry;
using UnityEngine;

namespace AlonDorn.PolygonDraw
{
    public class MeshGenerator
    {
        public static Mesh GetMesh(Vector3[] points, Mesh mesh = null)
        {
            if (points == null || points.Length < 3) return null;
            int[] triangles = Triangulator.GetTriangles(points);
            if(triangles == null)
            {
                Debug.LogWarning("GetMesh() triangles == null");
                return null;
            }
            if (triangles.Length < 3)
            {
                Debug.LogWarning($"not enought triangle points. {triangles.Length}");
                return null;
            }

            if (triangles.Length % 3 != 0)
            {
                Debug.LogWarning($"triangl pointsnot divided by three . {triangles.Length}");
                return null;
            }
            if (mesh == null)
                mesh = new Mesh();
            else
                mesh.Clear();
            mesh.vertices = points;
            mesh.triangles = triangles;
            mesh.uv = new Vector2[points.Length];
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}

