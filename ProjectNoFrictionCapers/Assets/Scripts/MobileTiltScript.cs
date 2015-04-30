using UnityEngine;
using System.Collections;

public class MobileTiltScript : MonoBehaviour
{

    public int turnSpeed;
    public int turnBuffer; 
	public GameObject ChildGroup; 

	public float Q_y; 
    
    // Use this for initialization
	void Start () {
		//ChildGroup.transform.Rotate(new Vector3(0,1,0), 90); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
		{
			if (transform.rotation.z < 0.1f)
			{
				transform.Rotate(0, 0, 0.2f);
			}
		}
		else if (Input.GetKey(KeyCode.A))
		{
			if (transform.rotation.x > -0.1f)
			{
				transform.Rotate(-0.2f, 0, 0);
			}
		}
		else if (Input.GetKey(KeyCode.S))
		{
			if (transform.rotation.z > -0.1f)
			{
				transform.Rotate(0, 0, -0.2f);
			}
		}
		else if (Input.GetKey (KeyCode.D)) {
			if (transform.rotation.x < 0.1f) {
				transform.Rotate (0.2f, 0, 0);
			}
		}
		//transform.rotation = new Quaternion(transform.rotation.x, .7071067985f, transform.rotation.z, transform.rotation.w);
		else /*if(Input.acceleration != null Application.platform == RuntimePlatform.Android)*/
		{
			transform.rotation = new Quaternion(Input.acceleration.x, 0, Input.acceleration.y, turnBuffer);
			//print(transform.rotation); 
			//print(Input.acceleration); 
		}
		


        /*if(Input.acceleration.y  > 0)
        {
            transform.Rotate(new Vector3(0,0,1), Input.acceleration.y);  
        }

        if (Input.acceleration.y < 0)
        {
            transform.Rotate(new Vector3(0, 0, 1), Input.acceleration.y);
        }

        if (Input.acceleration.x > 0)
        {
            transform.Rotate(new Vector3(1, 0, 0), Input.acceleration.x);
        }

        if (Input.acceleration.x < 0)
        {
            transform.Rotate(new Vector3(1, 0, 0), Input.acceleration.x);
        }*/

        

        /*if (!Input.anyKey)
        {
            float rate = (transform.rotation.x + transform.rotation.y + transform.rotation.z)/3;
            print(rate);
            transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, 0, 0, 1), Time.time * rate);
        }*/
	}
}
