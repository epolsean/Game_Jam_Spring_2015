using UnityEngine;
using System.Collections;

public class Shove : MonoBehaviour {

    public bool push;
    public Rigidbody rb;
    public float startTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(push == true && (Time.time - startTime) >= 1 && startTime != 0)
        {
            startTime = 0;
            push = false;
        }
        if (push == true && startTime == 0)
        {
            rb.AddForce(Vector3.forward * 100);
            startTime = Time.time;
        }
	}
}
