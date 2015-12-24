using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WindScript : MonoBehaviour {
    public List<GameObject> windZones;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
        //foreach (GameObject wind in windZones)
        //    rb.AddForce(wind.GetComponent<Transform>().forward.normalized*wind.GetComponent<WindZone>().windMain);
    }
}
