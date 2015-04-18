using UnityEngine;
using System.Collections;

public class IcyFloorTrigger : MonoBehaviour {

    public int slideForce; 
    public enum Direction { forward, backward, left, right};
    public Direction force_direction; 
    
    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TheifCharacterController>().isSliding == false)
        {
            print("GetOutOfHere");
            other.GetComponent<TheifCharacterController>().isSliding = true;
            //other.GetComponent<Rigidbody>().AddForce(new Vector3(this.transform.rotation.y, 0, -this.transform.rotation.y).normalized * slideForce); 
            //other.GetComponent<Rigidbody>().AddForce(Vector3.forward * slideForce);
            //other.GetComponent<Rigidbody>().AddForce(Vector3.right * slideForce);
            //other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * slideForce);
            if (force_direction == Direction.forward)
            {
                other.GetComponent<Rigidbody>().AddForce(Vector3.forward * slideForce);
            }
            else if (force_direction == Direction.backward)
            {
                other.GetComponent<Rigidbody>().AddForce(-Vector3.forward * slideForce);
            }
            else if (force_direction == Direction.left)
            {
                other.GetComponent<Rigidbody>().AddForce(Vector3.left * slideForce);
            }
            else if (force_direction == Direction.right)
            {
                other.GetComponent<Rigidbody>().AddForce(Vector3.right * slideForce);
        }
        }
    }
}
