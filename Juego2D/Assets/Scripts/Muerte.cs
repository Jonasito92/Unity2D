using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    public GameObject objetoADestruir;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == objetoADestruir)
        {
            Destroy(objetoADestruir);
        }
    }
}
