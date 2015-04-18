using UnityEngine;
using System.Collections;

public class MovObjController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Stationary")
        {
            print("Stopping");
            //this.GetComponent<BoxCollider>().material = null;
            this.GetComponent<Rigidbody>().isKinematic = true; 
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
