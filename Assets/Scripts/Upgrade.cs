using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _upgradePanel;
    public void Interact()
    {
        _upgradePanel.SetActive(true);
        Time.timeScale = 0;
    }

}
