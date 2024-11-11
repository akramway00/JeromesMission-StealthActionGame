using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonbattery : MonoBehaviour
{
    public GameObject jerome;
    public float proximitéson = 5.0f;
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(jerome.transform.position, transform.position);

        if (distance <= proximitéson && !isPlaying)
        {
            audioSource.Play();
            isPlaying = true;
        }
        else if (distance > proximitéson && isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
        }
    }
}
