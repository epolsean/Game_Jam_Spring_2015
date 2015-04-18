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
            if (i < 310)
            {
                m_Particles[i].color = new Color(255 * spectrum[i], 0, 0);
                //m_Particles[i].size = spectrum[i]*400;
            }
            else if (i < 625)
            {
                m_Particles[i].color = new Color(0, 255 * spectrum[i], 0);
            }
            else
            {
                m_Particles[i].color = new Color(0, 0, 255 * spectrum[i]);
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
