using UnityEngine;
using System.Collections;

public class DestroyText : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Destroy(this.gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
