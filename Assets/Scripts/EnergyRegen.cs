using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRegen : MonoBehaviour, IInteractable
{

    private void Update()
    {
        ControlEnergy();
    }
    private void ControlEnergy()
    {
        if (GameManager.instance.playerMovement.currentStamina < 0)
        {
            GameManager.instance.playerMovement.gameObject.transform.position = transform.position;
            GameManager.instance.playerMovement.currentStamina = GameManager.instance.playerMovement.maxStamina;
        }
        
    }

    public void Interact()
    {
        GameManager.instance.playerMovement.currentStamina = GameManager.instance.playerMovement.maxStamina;
    }
}
