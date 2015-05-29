using UnityEngine;
using System.Collections;

public class CubeBlink : MonoBehaviour 
{
    GameObject[] cubes;
    public AudioSource aSource;
    //float timer = 1.0f;
    public bool Randomize = false;

    void Start()
    {
        cubes = GameObject.FindGameObjectsWithTag("Stationary");
        //aSource = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        float[] spectrum = new float[1024];
        aSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        // Change only the particles that are alive
        for (int i = 0; i < cubes.Length; i++)
        {
            if (Randomize)
            {
                int random = Random.Range(0, 5);
                switch (random)
                {
                    case 0:
                        {
                            cubes[i].GetComponent<Renderer>().material.color = new Color(255 * spectrum[Random.Range(100, 104)], 0, 0);
                            break;
                        }
                    case 1:
                        {
                            cubes[i].GetComponent<Renderer>().material.color = new Color(0, 255 * spectrum[Random.Range(200, 204)], 0);
                            break;
                        }
                    case 2:
                        {
                            cubes[i].GetComponent<Renderer>().material.color = new Color(0, 0, 255 * spectrum[Random.Range(300, 304)]);
                            break;
                        }
                    case 3:
                        {
                            cubes[i].GetComponent<Renderer>().material.color = new Color(255 * spectrum[Random.Range(400, 404)], 255 * spectrum[i], 0);
                            break;
                        }
                    case 4:
                        {
                            cubes[i].GetComponent<Renderer>().material.color = new Color(255 * spectrum[Random.Range(500, 505)], 255 * spectrum[Random.Range(500, 504)], 0);
                            break;
                        }
                }
            }
            else
            {
                if (i < cubes.Length / 5f)
                {
                    cubes[i].GetComponent<Renderer>().material.color = new Color(255 * spectrum[Random.Range(100, 104)], 0, 0);
                }
                else if (i < cubes.Length * 2f / 5f)
                {
                    cubes[i].GetComponent<Renderer>().material.color = new Color(0, 255 * spectrum[Random.Range(200, 204)], 0);
                }
                else if (i < cubes.Length * 3f / 5f)
                {
                    cubes[i].GetComponent<Renderer>().material.color = new Color(0, 0, 255 * spectrum[Random.Range(300, 304)]);
                }
                else if (i < cubes.Length * 4f / 5f)
                {
                    cubes[i].GetComponent<Renderer>().material.color = new Color(255 * spectrum[Random.Range(400, 404)], 255 * spectrum[i], 0);
                }
                else
                {
                    cubes[i].GetComponent<Renderer>().material.color = new Color(255 * spectrum[Random.Range(500, 505)], 255 * spectrum[Random.Range(500, 504)], 0);
                }
            }
        }
    }
}
