using UnityEngine;
using System.Collections;

public class MeshGenerator : MonoBehaviour {

    public GameObject[] points;
    public int xSize;
    public int zSize;

	// Use this for initialization
	void Start () {
        Mesh mesh = new Mesh();
        if (GetComponent<MeshFilter>() == null)
            this.gameObject.AddComponent<MeshFilter>();
        



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
