using System.Collections.Generic;
using UnityEngine;

public class LevelCurvesCreator : MonoBehaviour
{
    public GameObject planeObject;
    public LineRenderer linePrefab;
    public void GenerateLevelCurve(List<Vector3> verts, int xSegments, int ySegments)
    {
        List<Vector3> intersectionPoints = new List<Vector3>();
        Vector3 planePoint = planeObject.transform.position;
        Vector3 planeNormal = planeObject.transform.up.normalized;

        for (int y = 0; y < ySegments; y++)
        {
            for (int x = 0; x < xSegments; x++)
            {
                int i0 = y * (xSegments + 1) + x;
                int i1 = i0 + 1;
                int i2 = i0 + (xSegments + 1);
                int i3 = i2 + 1;

                Vector3 c0 = verts[i0];
                Vector3 c1 = verts[i1];
                Vector3 c2 = verts[i2];
                Vector3 c3 = verts[i3];

                AddIntersectionIfCrosses(c0, c1, planePoint, planeNormal, intersectionPoints);
                AddIntersectionIfCrosses(c1, c2, planePoint, planeNormal, intersectionPoints);
                AddIntersectionIfCrosses(c2, c3, planePoint, planeNormal, intersectionPoints);
                AddIntersectionIfCrosses(c3, c0, planePoint, planeNormal, intersectionPoints);

            }
        }

        DrawContour(intersectionPoints);
    }

    void AddIntersectionIfCrosses(Vector3 a, Vector3 b, Vector3 planePoint, Vector3 planeNormal, List<Vector3> points)
    {
        float da = Vector3.Dot(planeNormal, a - planePoint);
        float db = Vector3.Dot(planeNormal, b - planePoint);

        if (da * db < 0f)
        {
            float t = da / (da - db);
            Vector3 intersection = a + t * (b - a);
            points.Add(intersection);
        }
    }

    void DrawContour(List<Vector3> points)
    {
        LineRenderer lr = Instantiate(linePrefab);
        lr.positionCount = points.Count;
        lr.SetPositions(points.ToArray());
    }
}
