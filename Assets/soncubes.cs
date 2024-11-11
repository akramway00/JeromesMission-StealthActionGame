using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soncubes : MonoBehaviour

{

    public AudioClip soundToPlay;
    private AudioSource audioSource;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jerome"))
        {
            audioSource.clip = soundToPlay;
            audioSource.Play();
        }






    }
}
