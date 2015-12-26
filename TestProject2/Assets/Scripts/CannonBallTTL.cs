using UnityEngine;
using System.Collections;

public class CannonBallTTL : MonoBehaviour {

    public int timeToLive = 10;
    private float startTime;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime > timeToLive)
            Destroy(this.gameObject);
	}
}
