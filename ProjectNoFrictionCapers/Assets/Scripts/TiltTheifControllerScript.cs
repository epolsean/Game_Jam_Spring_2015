using UnityEngine;
using System.Collections;

public class TiltTheifControllerScript : MonoBehaviour {

    public bool isJumping = false;

    public int jumpForce; 
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce); 
        }
	}

    void OnCollisionEnter(Collision other)
    {
        isJumping = false; 
    }
}
