using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraSwitchScript : MonoBehaviour {

    public List<Camera> cameras;
    public int activeCameraIndex = 0;

	// Use this for initialization
	void Start () {
        if (activeCameraIndex >= cameras.Count)
            activeCameraIndex = cameras.Count - 1;
        if (activeCameraIndex < 0)
            activeCameraIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire2"))
        {
            ++activeCameraIndex;
            if (activeCameraIndex >= cameras.Count)
                activeCameraIndex = 0;
            Camera temp;
            foreach (Camera c in cameras)
                c.enabled = false;
            cameras[activeCameraIndex].enabled = true;
        }
	}
}
