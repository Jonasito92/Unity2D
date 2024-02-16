using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMuerte : MonoBehaviour
{
    public GameObject objectToCollideWith; // Objeto que al colisionar activará la reproducción de audio
    public AudioClip soundEffect; // Sonido que se reproducirá al colisionar con el objeto
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundEffect;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == objectToCollideWith)
        {
            PlaySoundEffect();
        }
    }

    void PlaySoundEffect()
    {
        if (soundEffect != null && audioSource != null)
        {
            audioSource.Play();
        }
    }
}
