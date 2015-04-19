using UnityEngine;
using System.Collections;

public class WallPressurePlateScript : MonoBehaviour {

	public GameObject plateObj;
	
	public GameObject Door01; 
	public GameObject D01_LerpPoint; 
	public GameObject D01_startPoint; 
	public GameObject Door02; 
	public GameObject D02_LerpPoint;
	public GameObject D02_startPoint; 

	public bool DoorsOpen = false; 
	
	public float smooth = 3.0F;
	public bool isLerpin = false;
	public float LerpTimer = 0.0f;
	public float LerpsUpTime = 1.5f; 
	public float speed = 3.0F;
	private float startTime;
	private float journeyLength;
	
	// Use this for initialization
	void Start () {
		//D01_startPoint = Door01.transform; 
		//D02_startPoint = Door02.transform; 
	}
	
	// Update is called once per frame
	void Update () {
		if(isLerpin)
		{
			if(DoorsOpen == false)
			{
				OpenDoors();
			}
			else{
				CloseDoors(); 
			}
			LerpTimer += Time.deltaTime; 
			if(LerpTimer >= LerpsUpTime)
			{
				endLerp();
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "plateTrigger")
		{
			other.transform.position = new Vector3(this.transform.position.x, other.transform.position.y, this.transform.position.z);
			other.transform.rotation = this.transform.rotation; 
			//other.GetComponent<Rigidbody>().isKinematic = true;
			plateObj.transform.position -= new Vector3(0, 0, -0.1f);  
			isLerpin = true; 
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "plateTrigger") {
			print ("Close The Doors!"); 
			other.GetComponent<Rigidbody>().isKinematic = false; 
			plateObj.transform.position += new Vector3(0,0,-0.1f);
			isLerpin = true;

		}
	}
	
	public void endLerp()
	{
		isLerpin = false; 
		if (DoorsOpen) {
			DoorsOpen = false; 
		} else {
			DoorsOpen = true; 
		}
		LerpTimer = 0; 
	}
	
	public void OpenDoors()
	{
		OpenDoor (Door01, D01_LerpPoint); 
		OpenDoor (Door02, D02_LerpPoint); 
	}

	public void CloseDoors()
	{
		CloseDoor (Door01, D01_startPoint); 
		CloseDoor (Door02, D02_startPoint); 
	}
	
	public void OpenDoor(GameObject Door, GameObject NewTarget)
	{
		Door.transform.position = Vector3.Lerp(Door.transform.position, NewTarget.transform.position, smooth*Time.deltaTime);
	}

	public void CloseDoor(GameObject Door, GameObject NewTarget)
	{
		print ("closing"); 
		Door.transform.position = Vector3.Lerp(Door.transform.position, NewTarget.transform.position, smooth*Time.deltaTime);
	}


}
