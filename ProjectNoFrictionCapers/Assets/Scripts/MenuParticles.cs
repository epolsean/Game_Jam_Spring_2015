using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuParticles : MonoBehaviour
{
    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;
    public AudioSource aSource;

    void Start()
    {
        aSource = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void LateUpdate()
    {
        InitializeIfNeeded();

        // GetParticles is allocation free because we reuse the m_Particles buffer between updates
        int numParticlesAlive = m_System.GetParticles(m_Particles);
        float[] spectrum = new float[1024];
        aSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            if (i < 204)
            {
                m_Particles[i].color = new Color(255 * spectrum[Random.Range(100,104)], 0, 0);
                //m_Particles[i].position = Camera.main.ScreenToWorldPoint(new Vector3(i, i%Screen.height, 51));
            }
            else if (i < 408)
            {
                m_Particles[i].color = new Color(0, 255 * spectrum[Random.Range(345, 350)], 0);
                //m_Particles[i].position = Camera.main.ScreenToWorldPoint(new Vector3(i, i%Screen.height, 51));
            }
            else if (i < 612)
            {
                m_Particles[i].color = new Color(0, 255 * spectrum[Random.Range(599, 600)], 255 * spectrum[i]);
                //m_Particles[i].position = Camera.main.ScreenToWorldPoint(new Vector3(i, i%Screen.height, 51));
            }
            else if (i < 816)
            {
                m_Particles[i].color = new Color(255 * spectrum[Random.Range(760, 763)], 255 * spectrum[i], 0);
                //m_Particles[i].position = Camera.main.ScreenToWorldPoint(new Vector3(i, i%Screen.height, 51));
            }
            else
            {
                m_Particles[i].color = new Color(0, 0, 255 * spectrum[Random.Range(998,1000)]);
                //m_Particles[i].position = Camera.main.ScreenToWorldPoint(new Vector3(i, i%Screen.height, 51));
            }
            if (m_Particles[i].color.r <= 100 && m_Particles[i].color.g <= 100 && m_Particles[i].color.b <= 100)
            {
                m_Particles[i].color = new Color(0, 0, 255,spectrum[i]);
                //m_Particles[i].position = Camera.main.ScreenToWorldPoint(new Vector3(i, i%Screen.height, 51));
            }
        }

        // Apply the particle changes to the particle system
        m_System.SetParticles(m_Particles, numParticlesAlive);
    }

    void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.maxParticles];
    }
}
