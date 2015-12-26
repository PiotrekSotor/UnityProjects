using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private GameObject CameraSwitchScript;
    private GameObject CannonRotateScript;
    private GameObject PlayerMovementScript;
    private GameObject FireScript;


    // Use this for initialization
    void Start () {
        CameraSwitchScript = (GameObject) this.gameObject.GetComponent<CameraSwitchScript>();
        //GetComponentInChildren<>
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
