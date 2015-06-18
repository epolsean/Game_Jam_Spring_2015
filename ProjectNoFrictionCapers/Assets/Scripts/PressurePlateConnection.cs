using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PressurePlateConnection : MonoBehaviour
{

    public GameObject plate;
    public GameObject door;
    public ParticleSystem m_currentParticleEffect;

    Vector3 doorStartPos;
    Vector3 plateStartPos;
    public enum  AvailableColors { blue, cyan, green, yellow, white, red, magenta };
    public AvailableColors chosenColor;

    Color particleColor;

    // Use this for initialization
    void Start()
    {
        doorStartPos = door.transform.position;
        plateStartPos = plate.transform.position;
        m_currentParticleEffect.gameObject.transform.position = plateStartPos;
        Vector3 tempVec = (doorStartPos - plateStartPos);
        m_currentParticleEffect.startLifetime = (Mathf.Abs(tempVec.x) + Mathf.Abs(tempVec.z))/3f;
        switch (chosenColor)
        {
            case AvailableColors.blue:
                {
                    m_currentParticleEffect.startColor = Color.blue;
                    return;
                }
            case AvailableColors.cyan:
                {
                    m_currentParticleEffect.startColor = Color.cyan;
                    return;
                }
            case AvailableColors.green:
                {
                    m_currentParticleEffect.startColor = Color.green;
                    return;
                }
            case AvailableColors.yellow:
                {
                    m_currentParticleEffect.startColor = Color.yellow;
                    return;
                }
            case AvailableColors.white:
                {
                    m_currentParticleEffect.startColor = Color.white;
                    return;
                }
            case AvailableColors.red:
                {
                    m_currentParticleEffect.startColor = Color.red;
                    return;
                }
            case AvailableColors.magenta:
                {
                    m_currentParticleEffect.startColor = Color.magenta;
                    return;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.Particle[] ParticleList = new ParticleSystem.Particle[m_currentParticleEffect.particleCount];
        m_currentParticleEffect.GetParticles(ParticleList);
        for (int i = 0; i < ParticleList.Length; ++i)
        {
            ParticleList[i].rotation = 0;
            Vector3 tempVec = (doorStartPos - plateStartPos);
            Debug.Log(tempVec);
            if (Mathf.Abs(ParticleList[i].position.x - tempVec.x) >= 0.25f)
            {
                ParticleList[i].velocity = new Vector3(3 * Mathf.Sign(tempVec.x), 0, 0);
                //ParticleList[i].position = Vector3.Lerp(ParticleList[i].position, new Vector3(tempVec.x, 0, ParticleList[i].position.z), Time.deltaTime);
            }
            else if (Mathf.Abs(ParticleList[i].position.z - tempVec.z) >= 0.25f)
            {
                ParticleList[i].velocity = new Vector3(0, 0, 3 * Mathf.Sign(tempVec.z));
                //ParticleList[i].position = Vector3.Lerp(ParticleList[i].position, new Vector3(ParticleList[i].position.x, 0, tempVec.z), Time.deltaTime);
            }
            else
            {
                ParticleList[i].lifetime = 0;
            }
            //ParticleList[i].velocity = new Vector3(tempVec.x,0,tempVec.z);
        }

        m_currentParticleEffect.SetParticles(ParticleList, m_currentParticleEffect.particleCount);

    }
}
