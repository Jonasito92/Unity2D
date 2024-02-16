using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonedaPersonaje : MonoBehaviour
{
    private int coinCount = 34;
    public Text coinCountText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject); // Destruye la moneda al ser recogida
            UpdateCoinCountUI();
        }
    }

    void UpdateCoinCountUI()
    {
        // Actualiza el texto del contador en la UI
        coinCountText.text = "Monedas: " + coinCount.ToString();
    }
}
