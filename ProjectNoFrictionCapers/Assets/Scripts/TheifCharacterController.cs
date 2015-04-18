using UnityEngine;
using System.Collections;

public class TheifCharacterController : MonoBehaviour {

    public int rotSpeed;
    public int moveSpeed;
    public int jumpForce;
    public bool isJumping = false;
    public bool isSliding = false; 
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	    if(Input.GetKey(KeyCode.A))
        {
            //this.GetComponent<Rigidbody>().isKinematic = false; 
            this.transform.Rotate(Vector3.up, -rotSpeed*Time.deltaTime); 
        }

        if (Input.GetKey(KeyCode.D))
        {
            //this.GetComponent<Rigidbody>().isKinematic = false; 
            this.transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) && isSliding == false)
        {
            this.GetComponent<Rigidbody>().isKinematic = false; 
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift) && isJumping == false)
            {
                moveSpeed += moveSpeed;
            }

        }

        if (Input.GetKey(KeyCode.S) && isSliding == false)
        {
            this.GetComponent<Rigidbody>().isKinematic = false; 
            this.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift) && isJumping == false)
            {
                moveSpeed += moveSpeed; 
            }
        }

        if (Input.GetKey(KeyCode.Q) && isSliding == false)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift) && isJumping == false)
            {
                moveSpeed += moveSpeed;
            }

        }

        if (Input.GetKey(KeyCode.E) && isSliding == false)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift) && isJumping == false)
            {
                moveSpeed += moveSpeed;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().isKinematic = false; 
            if(isJumping == false)
            {
                isJumping = true; 
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce); 
            }
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 10; 
        }

	}

    void OnCollisionEnter(Collision other)
    {
        print("Collision"); 
        isJumping = false;

        if (other.gameObject.tag == "Stationary")
        {
            print("Stopping");
            //this.GetComponent<BoxCollider>().material = null;
            if(this.isSliding)
            {
                isSliding = false;
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}


