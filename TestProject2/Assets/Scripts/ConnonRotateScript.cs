using UnityEngine;
using System.Collections;

public class ConnonRotateScript : MonoBehaviour {

    public GameObject gun;
    private Vector3 gunAngle; // kąt podniesienia lufy 0 - poziomo, 90 - pionowo
    private int maxAngle = 90;
    private int minAngle = -10;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = -Input.GetAxis("Vertical");
        if (Input.GetButton("Jump"))
            Debug.Log(transform.position);
        transform.Rotate(new Vector3(0, h, 0), Space.Self);
        Vector3 rotateAnchor;
        rotateAnchor.x = transform.position.x;
        rotateAnchor.z = transform.position.z;
        rotateAnchor.y = transform.position.y + transform.up.normalized.y * 0.1f;
        gun.transform.RotateAround(rotateAnchor, transform.forward, v);
    }
}
