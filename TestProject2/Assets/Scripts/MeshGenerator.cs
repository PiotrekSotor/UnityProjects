using UnityEngine;
using System.Collections.Generic;
[RequireComponent(typeof(SplineController))]

public class MeshGenerator : MonoBehaviour
{
    public int numOfCoastPoints;
    public int maxRadius;

    private SplineController splineController;

    public void Start()
    {
        splineController = this.gameObject.GetComponent<SplineController>();

        int[] angles = getAngles();
        Vector3[] positions = getPositions(angles);

        splineController.Positions = positions;
        splineController.Transforms = null;
        splineController.SplineRoot = null;
        Vector3[] curvePoints = splineController.GetPoints(50*numOfCoastPoints);


        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[curvePoints.Length + 1];
        mesh.uv = new Vector2[curvePoints.Length + 1];
        mesh.triangles = new int[3 * curvePoints.Length];
        mesh.normals = new Vector3[curvePoints.Length + 1];
        Vector3[] myVertices = new Vector3[curvePoints.Length + 1];
        int[] myTriangles = new int[3 * curvePoints.Length];
        Vector2[] myUV = new Vector2[curvePoints.Length + 1];
        Vector3[] myNormals = new Vector3[curvePoints.Length + 1];

        myVertices[0] = new Vector3(0f, 0f, 0f);
        myUV[0] = new Vector2(0f, 0f);
        myNormals[0] = -Vector3.forward;
        System.Array.Copy(curvePoints, 0, myVertices, 1, curvePoints.Length);
        for (int i = 1; i < mesh.vertices.Length; ++i)
        {
            //mesh.vertices[i] = new Vector3 (curvePoints[i - 1].x, curvePoints[i - 1].y, curvePoints[i - 1].z);
            myUV[i] = new Vector2(myVertices[i].x, myVertices[i].z);
            myNormals[i] = -Vector3.forward;
        }
        for (int i = 0; i < 3 * curvePoints.Length; ++i)
        {
            if (i % 3 == 0)
                myTriangles[i] = 0;
            else if (i % 3 == 1)
                myTriangles[i] = (i / 3 + 2);
            else if (i % 3 == 2)
                myTriangles[i] = i / 3 + 1;
            if (myTriangles[i] == curvePoints.Length + 1)
                myTriangles[i] -= curvePoints.Length;
        }
        List<Vector3> verticesList = new List<Vector3>();
        for (int i = 0; i < myVertices.Length; ++i)
            verticesList.Add(myVertices[i]);
        mesh.SetVertices(verticesList);

        List<Vector2> uvList = new List<Vector2>();
        for (int i = 0; i < myUV.Length; ++i)
            uvList.Add(myUV[i]);
        mesh.SetUVs(0,uvList);

        List<int> trianglesList = new List<int>();
        for (int i = 0; i < myTriangles.Length; ++i)
            trianglesList.Add(myTriangles[i]);
        mesh.SetTriangles(trianglesList,0);

        List<Vector3> normalsList = new List<Vector3>();
        for (int i = 0; i < myNormals.Length; ++i)
            normalsList.Add(myNormals[i]);
        mesh.SetNormals(normalsList);

        GetComponent<MeshFilter>().mesh = mesh;
    }

    int[] getAngles()
    {
        int[] result = null;
        if (numOfCoastPoints < 3)
            return result;
        List<int> angles = new List<int>();
        angles.Add(0);
        angles.Add(360);
        Random rand = new Random();

        for (int i = 2; i < numOfCoastPoints+1; ++i)
        {
            int lowerIndex = 0;
            int maxDiffrence = 0;
            for (int j = 1; j < i; ++j)
            {
                if (angles[j] - angles[j - 1] > maxDiffrence)
                {
                    lowerIndex = j - 1;
                    maxDiffrence = angles[j] - angles[j - 1];
                }
            }

            int newAngle = angles[lowerIndex] + (int)(Random.Range(0f, 1f) * maxDiffrence);
            angles.Add(newAngle);
            angles.Sort();
        }
        angles.Remove(360);
        result = angles.ToArray();
        return result;
    }

    Vector3[] getPositions(int[] angles)
    {
        Vector3[] positions = new Vector3[angles.Length];
        for (int i = 0; i < angles.Length; ++i)
        {
            float r = maxRadius * Random.Range(0.7f, 1f);
            float newX = r * Mathf.Cos((float)angles[i] * Mathf.PI / 180f);
            float newZ = r * Mathf.Sin((float)angles[i] * Mathf.PI / 180f);
            positions[i] = new Vector3(newX, 0, newZ);
        }
        return positions;
    }
}