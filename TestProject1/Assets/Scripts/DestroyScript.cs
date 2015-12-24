using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Ball"))
            Destroy(col.gameObject);
    }
}
