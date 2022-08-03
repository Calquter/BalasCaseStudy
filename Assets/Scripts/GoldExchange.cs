using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldExchange : MonoBehaviour, IInteractable
{
    [SerializeField] private int goldValue;

    public void Interact()
    {
        if (GameManager.instance.stackSystem.golds.Count < 1)
            return;

        foreach (var item in GameManager.instance.stackSystem.golds)
        {
            item.Exchange();
            GameManager.instance.currentGold += goldValue;
        }

        GameManager.instance.stackSystem.golds.Clear();
        GameManager.instance.stackSystem.currentStackCount = 0;
    }
}
