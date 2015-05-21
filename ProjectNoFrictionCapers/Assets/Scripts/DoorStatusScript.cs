using UnityEngine;
using System.Collections;

public class DoorStatusScript : MonoBehaviour {

	public bool isOpen = false; 

	public bool canTrigger = true; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(isOpen)
        {

            foreach (BoxCollider boxC in GetComponentsInChildren<BoxCollider>())
            {
                boxC.enabled = false;
            }
        }
        else
        {

            foreach (BoxCollider boxC in GetComponentsInChildren<BoxCollider>())
            {
                boxC.enabled = true;
            }
        }
	}
}
