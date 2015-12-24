using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    
    public GameObject ballPrefab;
    public float speed;
    private float lastShotTime;
    
	// Use this for initialization
	void Start () {
        lastShotTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastShotTime > 0.5f)
            {
                lastShotTime = Time.time;
                Vector3 newPosition;
                float angle;
                Debug.Log("Fire1");

                Debug.Log(transform.up + "  " + transform.forward);
                newPosition.x = transform.position.x + transform.up.x * 0.5f;
                newPosition.y = transform.position.y + transform.up.y * 0.5f;
                newPosition.z = transform.position.z + transform.up.z * 0.5f;

                GameObject newBall = (GameObject)Instantiate(ballPrefab, newPosition, new Quaternion());
                newBall.GetComponent<Rigidbody>().velocity = transform.up.normalized * speed;
                //Debug.Log("gun.TOAngleAxis: " + angle + "  " + newPosition.ToString());
                //
            }

        }

    }
}
