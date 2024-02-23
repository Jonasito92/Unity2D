using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMoneda : MonoBehaviour
{
    public AudioClip sonidoMoneda; // Variable para almacenar el sonido que deseas reproducir
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sonidoMoneda;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Moneda")
        {
            audioSource.Play();
        }
    }
}
