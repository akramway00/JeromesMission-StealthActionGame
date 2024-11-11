using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonbattery : MonoBehaviour
{
    public GameObject jerome;
    public float proximit�son = 5.0f;
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(jerome.transform.position, transform.position);

        if (distance <= proximit�son && !isPlaying)
        {
            audioSource.Play();
            isPlaying = true;
        }
        else if (distance > proximit�son && isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
        }
    }
}
