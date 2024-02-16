using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private score puntaje;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        puntaje.SumarPuntos(cantidadPuntos);
        Destroy(this.gameObject);
    }
}
