using UnityEngine;
using System.Collections;

public class PressurePlateScript : MonoBehaviour {

    public GameObject plateObj;

	public GameObject DoorsObj; 

	public GameObject Door01; 
	public GameObject D01_LerpPoint;
	public GameObject D01_start; 
	public GameObject Door02; 
	public GameObject D02_LerpPoint;
	public GameObject D02_start; 

	public bool DoorsOpen = false; 
	public bool isTriggered = false;  

	public float smooth = 3.0F;
	public bool isLerpin = false;
	public float LerpTimer = 0.0f;
	public float LerpsUpTime = 1.5f; 
	public float speed = 3.0F;
	private float startTime;
	private float journeyLength;
    
    // Use this for initialization
	void Start () {
	
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
		if (DoorsObj.GetComponent<DoorStatusScript>().canTrigger) {
			if (isTriggered == false)
			{
				isTriggered = true; 
				DoorsOpen = false; 
				//other.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
				//other.transform.rotation = this.transform.rotation; 
				//other.GetComponent<Rigidbody>().isKinematic = true;
                plateObj.transform.position -= 0.1f * plateObj.transform.up;
				isLerpin = true; 
			}
		}
    }

	void OnTriggerExit(Collider other)
	{
		if (DoorsObj.GetComponent<DoorStatusScript>().canTrigger) {
			if (isTriggered) {
				DoorsOpen = true; 
				print("Floor: Close Doors"); 
				isTriggered = false;
                plateObj.transform.position += 0.1f * plateObj.transform.up;
				isLerpin = true; 
			}
		}
	}

	public void endLerp()
	{
		isLerpin = false; 
		if (DoorsOpen) {
			DoorsOpen = false; 
			DoorsObj.GetComponent<DoorStatusScript>().isOpen = false; 
		} else {
			DoorsOpen = true; 
			DoorsObj.GetComponent<DoorStatusScript>().isOpen = true; 
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
		OpenDoor (Door01, D01_start); 
		OpenDoor (Door02, D02_start); 
	}

	public void OpenDoor(GameObject Door, GameObject NewTarget)
	{
		Door.transform.position = Vector3.Lerp(Door.transform.position, NewTarget.transform.position, smooth*Time.deltaTime);
	}
	
}
