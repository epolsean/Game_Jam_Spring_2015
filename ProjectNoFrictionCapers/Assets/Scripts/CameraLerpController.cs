using UnityEngine;
using System.Collections;

public class CameraLerpController : MonoBehaviour {

	public GameObject MainCamera; 
	public GameObject CamLerp01; 
	public GameObject CamLerp02; 

	public GameObject PressurePlate;

	public GameObject DoorsObj; 

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
			Move2Room(MainCamera, CamLerp02);
			LerpTimer += Time.deltaTime; 
			if(LerpTimer >= LerpsUpTime)
			{
				endLerp();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "ThiefDude") {
  
			isLerpin = true;
            if(PressurePlate)
            {
                PressurePlate.GetComponent<PressurePlateScript>().DoorsOpen = true; //make sure doors are open before you can close them
			    PressurePlate.GetComponent<PressurePlateScript>().isLerpin = true; //trigger doors to close
                if (PressurePlate.transform.parent.GetComponent<PressurePlateConnection>())
                {
                    ParticleSystem m_currentParticleEffect = PressurePlate.transform.parent.GetComponent<PressurePlateConnection>().m_currentParticleEffect;
                    ParticleSystem.Particle[] ParticleList = new ParticleSystem.Particle[m_currentParticleEffect.particleCount];
                    m_currentParticleEffect.GetParticles(ParticleList);
                    for (int i = 0; i < ParticleList.Length; ++i)
                    {
                        ParticleList[i].lifetime = 0;
                    }
                    m_currentParticleEffect.SetParticles(ParticleList, m_currentParticleEffect.particleCount);
                    PressurePlate.transform.parent.GetComponent<PressurePlateConnection>().enabled = false;
                    m_currentParticleEffect.Stop();
                }
            }
            else
            {
                Debug.LogError("Tag of pressure plate not set");
            }
            if(DoorsObj)
			    DoorsObj.GetComponent<DoorStatusScript>().canTrigger = false; 
		}
	}

	public void endLerp()
	{
		isLerpin = false; 
	}

	public void Move2Room(GameObject MainCam, GameObject NewTarget)
	{
		MainCam.transform.position = Vector3.Lerp(MainCam.transform.position, NewTarget.transform.position, smooth*Time.deltaTime);
		MainCam.transform.rotation = Quaternion.Lerp(MainCam.transform.rotation, NewTarget.transform.rotation, Time.deltaTime * speed);
	}
}
