using UnityEngine;
using System.Collections;

public class CannonBallHitScript : MonoBehaviour {

    // Use this for initialization
    public int startDurability;
    public int curDurability;
	void Start () {
        curDurability = startDurability;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "CannonBall")
        {
            Debug.Log("Collision of " + this.name);
            curDurability -= 10;
            if (curDurability <= 0)
                Destroy(this);
        }
    }
}
