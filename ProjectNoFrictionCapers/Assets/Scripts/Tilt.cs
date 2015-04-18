using UnityEngine;
using System.Collections;

public class Tilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) && transform.rotation.z > -0.083333333333333f)
        {
            transform.Rotate(0, 0, -0.2f);
        }
        if (Input.GetKey(KeyCode.A) && transform.rotation.x > -0.083333333333333f)
        {
            transform.Rotate(-0.2f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && transform.rotation.z < 0.083333333333333f)
        {
            transform.Rotate(0, 0, 0.2f);
        }
        if (Input.GetKey(KeyCode.D) && transform.rotation.x < 0.083333333333333f)
        {
            transform.Rotate(0.2f, 0, 0);
        }
	}
}
