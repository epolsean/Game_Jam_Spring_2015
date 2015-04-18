using UnityEngine;
using System.Collections;

public class IcyFloorTrigger : MonoBehaviour {

    public int slideForce; 
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        print("GetOutOfHere");
        other.GetComponent<TheifCharacterController>().isSliding = true; 
        other.GetComponent<Rigidbody>().AddForce(Vector3.forward * slideForce); 
    }
}
