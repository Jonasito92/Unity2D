using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCosos : MonoBehaviour
{
    public GameObject objetoDesencadenador; // Referencia al objeto que desencadenará la acción
    public GameObject imagenCorazon; // Referencia al objeto de la imagen del corazón en el canvas
    public GameObject contador; // Referencia al objeto del contador en el canvas

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == objetoDesencadenador)
        {
            if (imagenCorazon != null)
            {
                imagenCorazon.SetActive(false);
            }

            if (contador != null)
            {
                contador.SetActive(false);
            }
        }
    }
}
