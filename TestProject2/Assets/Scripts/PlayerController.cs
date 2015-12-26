using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    private CameraSwitchScript cameraSwitchScript;
    private ConnonRotateScript cannonRotateScript;
    private PlayerMovementScript playerMovementScript;
    private FireScript[] fireScripts;
    private bool shootableCamera;

    // Use this for initialization
    void Start () {
        cameraSwitchScript =  this.gameObject.GetComponent<CameraSwitchScript>();
        playerMovementScript = this.gameObject.GetComponent<PlayerMovementScript>();
        cannonRotateScript = this.gameObject.GetComponentInChildren<ConnonRotateScript>();
        fireScripts = this.gameObject.GetComponentsInChildren<FireScript>();
        
	}
	
	// Update is called once per frame
	void Update () {
        shootableCamera = cameraSwitchScript.activeCameraIndex != 0;
        float h;
        float v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (shootableCamera)
        {
            cannonRotateScript.CannonRotate(h, v);
            if (Input.GetButton("Fire1"))
            {
                foreach (FireScript fs in fireScripts)
                    if (fs.Fire())
                        break;                    
            }
        }
        else
        {
            playerMovementScript.PlayerStearing(h);

        }
        if (Input.GetButton("Fire2"))
        {
            cameraSwitchScript.CameraSwitch();
            Debug.Log("ChangeCamera");
        }

	
	}
}
