using UnityEngine;
using System.Collections;

public class WallPressurePlateScript : MonoBehaviour
{

    public GameObject plateObj;
    public GameObject DoorsObj;
    public GameObject DoorLeft;
    public GameObject DoorLeft_Open;
    public GameObject DoorLeft_Closed;
    public GameObject DoorRight;
    public GameObject DoorRight_Open;
    public GameObject DoorRight_Closed;

    public bool DoorsOpen = false;
    public bool isTriggered = false;

    public float smooth = 3.0F;
    public bool isLerpin = false;
    public float LerpTimer = 0.0f;
    public float LerpsUpTime = 0.25f;

    public bool OneTimePress = false;

    // Use this for initialization
    void Start()
    {
        //D01_startPoint = Door01.transform; 
        //D02_startPoint = Door02.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isLerpin)
        {
            if (DoorsOpen == false)
            {
                OpenDoors();
            }
            else
            {
                CloseDoors();
            }
            LerpTimer += Time.deltaTime;
            if (LerpTimer >= LerpsUpTime)
            {
                endLerp();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isTriggered == false && DoorsObj.GetComponent<DoorStatusScript>().canTrigger)
        {
            isTriggered = true;
            DoorsOpen = false;
            //other.transform.position = new Vector3(this.transform.position.x, other.transform.position.y, this.transform.position.z);
            //other.transform.rotation = this.transform.rotation; 
            //other.GetComponent<Rigidbody>().isKinematic = true;
            plateObj.transform.position -= 0.1f * plateObj.transform.up;
            isLerpin = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isTriggered && DoorsObj.GetComponent<DoorStatusScript>().canTrigger && !OneTimePress)
        {
            isTriggered = false;
            DoorsOpen = true;
            print("Wall: Close The Doors!");
            other.GetComponent<Rigidbody>().isKinematic = false;
            plateObj.transform.position += 0.1f * plateObj.transform.up;
            isLerpin = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!isTriggered && DoorsObj.GetComponent<DoorStatusScript>().canTrigger)
        {
            isTriggered = true;
            DoorsOpen = false;
            plateObj.transform.position -= 0.1f * plateObj.transform.up;
            isLerpin = true;
        }
    }

    public void endLerp()
    {
        isLerpin = false;
        if (DoorsOpen)
        {
            DoorsOpen = false;
            DoorRight.transform.position = DoorRight_Closed.transform.position;
            DoorLeft.transform.position = DoorLeft_Closed.transform.position;
            DoorsObj.GetComponent<DoorStatusScript>().isOpen = false;
        }
        else
        {
            DoorsOpen = true;
            DoorRight.transform.position = DoorRight_Open.transform.position;
            DoorLeft.transform.position = DoorLeft_Open.transform.position;
            DoorsObj.GetComponent<DoorStatusScript>().isOpen = true;
        }
        LerpTimer = 0;
    }

    public void OpenDoors()
    {
        LerpDoor(DoorLeft, DoorLeft_Open);
        LerpDoor(DoorRight, DoorRight_Open);
    }

    public void CloseDoors()
    {
        LerpDoor(DoorLeft, DoorLeft_Closed);
        LerpDoor(DoorRight, DoorRight_Closed);
    }

    public void LerpDoor(GameObject Door, GameObject NewTarget)
    {
        Door.transform.position = Vector3.Lerp(Door.transform.position, NewTarget.transform.position, smooth * Time.deltaTime);
    }
}
