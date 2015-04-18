using UnityEngine;
using System.Collections;

public class Tilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(0, 0, -0.2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-0.2f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0, 0, 0.2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.2f, 0, 0);
        }
        if (!Input.anyKey)
        {
            float rate = (transform.rotation.x + transform.rotation.y + transform.rotation.z)/3;
            print(rate);
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, 0, 0, 1), Time.time * rate);
        }
	}
}
