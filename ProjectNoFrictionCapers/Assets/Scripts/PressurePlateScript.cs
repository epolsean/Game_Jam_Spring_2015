using UnityEngine;
using System.Collections;

public class PressurePlateScript : MonoBehaviour {

    public GameObject plateObj;

	public GameObject Door01; 
	public GameObject D01_LerpPoint; 
	public GameObject Door02; 
	public GameObject D02_LerpPoint;

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
			OpenDoors();
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
            other.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            other.transform.rotation = this.transform.rotation; 
            other.GetComponent<Rigidbody>().isKinematic = true;
            plateObj.transform.position -= new Vector3(0, 0.1f, 0);  
			isLerpin = true; 
        }
    }

	public void endLerp()
	{
		isLerpin = false; 
	}

	public void OpenDoors()
	{
		OpenDoor (Door01, D01_LerpPoint); 
		OpenDoor (Door02, D02_LerpPoint); 
	}

	public void OpenDoor(GameObject Door, GameObject NewTarget)
	{
		Door.transform.position = Vector3.Lerp(Door.transform.position, NewTarget.transform.position, smooth*Time.deltaTime);
	}
}
