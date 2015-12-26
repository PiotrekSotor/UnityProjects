using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ConnonRotateScript : MonoBehaviour {

    public List<GameObject> cannonBatteries;
    private Vector3 gunAngle; // kąt podniesienia lufy 0 - poziomo, 90 - pionowo

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {        
    }

    public void CannonRotate(float h, float v)
    {
        foreach (GameObject cb in cannonBatteries)
        {
            Transform transform = cb.GetComponent<Transform>();
            transform.Rotate(new Vector3(0, h, 0), Space.Self);
            Vector3 rotateAnchor;
            rotateAnchor.x = transform.position.x;
            rotateAnchor.z = transform.position.z;
            //rotateAnchor.y = transform.position.y + transform.up.normalized.y * 0.1f;

            Transform[] barrels = cb.gameObject.GetComponentsInChildren<Transform>();
            foreach (Transform t in barrels)
            {
                if (t.parent.tag.Equals("BarrelsSet"))
                {
                    rotateAnchor.y = transform.position.y + transform.up.normalized.y * 0.1f;
                    //Debug.Log(rotateAnchor);
                    t.RotateAround(rotateAnchor, transform.forward, v);
                }

            }
            //cb.transform.RotateAround(rotateAnchor, transform.forward, v);
        }
            
    }
}
