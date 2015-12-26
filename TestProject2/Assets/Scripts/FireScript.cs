using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    
    public GameObject ballPrefab;
    public float speed = 15;
    private float lastShotTime;
    
	// Use this for initialization
	void Start () {
        lastShotTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {}

    public bool Fire()
    {
        if (Time.time - lastShotTime > 0.5f)
        {
            lastShotTime = Time.time;
            Vector3 newPosition;

            newPosition.x = transform.position.x + transform.up.x * 0.1f;
            newPosition.y = transform.position.y + transform.up.y * 0.1f;
            newPosition.z = transform.position.z + transform.up.z * 0.1f;
            GameObject newBall = (GameObject)Instantiate(ballPrefab, newPosition, new Quaternion());
            newBall.GetComponent<Rigidbody>().velocity = transform.up.normalized * speed;
            return true;
        }
        else
            return false;
    }
}
