using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    public float speed = 1f;
    public float agility = 5f;

    private Transform tr;
	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 movementVector = new  Vector3(1f,0f,0f);        
        tr.Translate(movementVector*speed*Time.deltaTime);
	}
    public void PlayerStearing(float h)
    {
        tr.Rotate(new Vector3(0, h * agility * Time.deltaTime, 0), Space.World);
    }
}
