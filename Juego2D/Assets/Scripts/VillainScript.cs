using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Death"); // Aseg�rate de que el nombre del trigger coincida con tu animaci�n de muerte
        }
    }
}
