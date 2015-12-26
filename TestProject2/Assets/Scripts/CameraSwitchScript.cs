using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraSwitchScript : MonoBehaviour {

    public List<Camera> cameras;
    public int activeCameraIndex = 0;
    private float lastSwitchTime;
    private float minTimeBetweanSwitches = 0.5f;

	// Use this for initialization
	void Start () {
        lastSwitchTime = Time.time;
        if (activeCameraIndex >= cameras.Count)
            activeCameraIndex = cameras.Count - 1;
        if (activeCameraIndex < 0)
            activeCameraIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void CameraSwitch()
    {
        if (Time.time - lastSwitchTime < minTimeBetweanSwitches)
            return;
        ++activeCameraIndex;
        if (activeCameraIndex >= cameras.Count)
            activeCameraIndex = 0;
        foreach (Camera c in cameras)
            c.enabled = false;
        cameras[activeCameraIndex].enabled = true;
        lastSwitchTime = Time.time;
    }
}
