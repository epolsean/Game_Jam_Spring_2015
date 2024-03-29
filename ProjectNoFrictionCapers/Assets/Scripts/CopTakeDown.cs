﻿using UnityEngine;
using System.Collections;

public class CopTakeDown : MonoBehaviour 
{
    Vector3 lastLooking;
    // Use this for initialization
    void Start()
    {
        lastLooking = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) >= 0.1f || Mathf.Abs(GetComponent<Rigidbody>().velocity.z) >= 0.1f)
        {
            transform.forward = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
            lastLooking = transform.forward;
        }
        else
        {
            transform.forward = lastLooking;
        }
    }

	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "ThiefDude") 
        {
            GameAndUIController.hitCop = true;
			Application.LoadLevel(Application.loadedLevel); 
		}
	}
}
