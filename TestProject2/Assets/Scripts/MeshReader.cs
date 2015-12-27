using UnityEngine;
using System.Collections;

public class MeshReader : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] myVertices = mesh.vertices;
        Vector2[] myUV = mesh.uv;
        int[] myTriangles = mesh.triangles;

        foreach (Vector3 v in myVertices)
            Debug.Log(v);
        foreach (Vector2 v in myUV)
            Debug.Log(v);
        foreach (int v in myTriangles)
            Debug.Log(v);

    }
	
	// Update is called once per frame
	void Update () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int i = 0;
        while (i < vertices.Length)
        {
            vertices[i] += normals[i] * Mathf.Sin(Time.time);
            i++;
        }
        mesh.vertices = vertices;
    }
}
