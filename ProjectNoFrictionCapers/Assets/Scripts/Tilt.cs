using UnityEngine;
using System.Collections;

public class Tilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.rotation.z < 0.1f)
            {
                transform.Rotate(0, 0, 0.2f);
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.rotation.x > -0.1f)
            {
                transform.Rotate(-0.2f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.rotation.z > -0.1f)
            {
                transform.Rotate(0, 0, -0.2f);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.rotation.x < 0.1f)
            {
                transform.Rotate(0.2f, 0, 0);
            }
        }
        //transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
	}
}
