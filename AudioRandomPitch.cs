using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioRandomPitch : MonoBehaviour
{
    private AudioSource _audioSource;
    
    //Pitch
    [Range(0, 3)] [SerializeField] private float minPitch = .9f;
    [Range(0, 3)] [SerializeField] private float maxPitch = 1.1f;
    
    [Range(0, 1)] [SerializeField] private float minVolume = .9f;
    [Range(0, 1)] [SerializeField] private float maxVolume = 1f;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    

    void RandomPitch()
    {
        _audioSource.pitch = Random.Range(minPitch, maxPitch);
    }
    
    void RandomVolume()
    {
        _audioSource.volume = Random.Range(minVolume, maxVolume);
    }
}
