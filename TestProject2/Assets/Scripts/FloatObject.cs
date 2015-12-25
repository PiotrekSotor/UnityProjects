using UnityEngine;
using System.Collections;

public class FloatObject : MonoBehaviour {

    public float waterLevel = 4f;
    public float floatHeight = 2f;
    public float bounceDump = 0.05f;
    public Vector3 buoyancyCentreOffset;

    private float forceFactor;
    private Vector3 actionPoint;
    private Vector3 uplift;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
        actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
        forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

        if (forceFactor > 0f)
        {
            uplift = -Physics.gravity * (forceFactor - rb.velocity.y * bounceDump);
            rb.AddForceAtPosition(uplift, actionPoint);
        }
	
	}
}
