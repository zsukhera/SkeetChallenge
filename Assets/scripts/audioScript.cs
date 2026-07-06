using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{

    public AudioSource audiosource;
    public AudioClip reload;
    public AudioClip shellSound;
    public AudioClip fireSound;
    public AudioClip birds;
    public AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playFireSound()
    {
        audiosource.PlayOneShot(fireSound);
    }
}
