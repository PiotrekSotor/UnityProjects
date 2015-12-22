using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public GameObject gun;
    private int gunAngle = 0; // kąt podniesienia lufy 0 - poziomo, 90 - pionowo
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0, h, 0),Space.World);
        gunAngle += (int)v;
        if (gunAngle > 90)
            gunAngle = 90;
        if (gunAngle < 0)
            gunAngle = 0;

        gun.transform.RotateAround(new Vector3(0f, 0.2f, 0f), transform.forward, v);

        Debug.Log("horizontal: " + h.ToString() + "  vertical: " + v.ToString() + " gunAngle: " + gunAngle);

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire kurwa!");
        }
	
	}
}
