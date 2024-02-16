using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject doorObject; // Variable pública para asignar el objeto de la puerta desde Unity

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == doorObject)
        {
            VillainScript villain = doorObject.GetComponent<VillainScript>();
            if (villain != null)
            {
                villain.TriggerDeathAnimation();
            }
        }
    }
}
