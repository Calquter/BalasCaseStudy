using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, IInteractable
{
    private bool _isPickedUp;
    private int _stackIndex;

    private void Update()
    {
        MoveToTarget();
    }


    private void MoveToTarget()
    {
        if (!_isPickedUp)
            return;

        transform.position = GameManager.instance.stackSystem.SelectTargetPosition(_stackIndex);
    }

    public void Interact()
    {
        if (!GameManager.instance.stackSystem.CheckStackCount() || _isPickedUp)
            return;

        _isPickedUp = true;

        _stackIndex = GameManager.instance.stackSystem.currentStackCount;
        GameManager.instance.stackSystem.currentStackCount++;
        GameManager.instance.stackSystem.golds.Add(this);

    }
}
