using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, IInteractable
{
    private bool _isPickedUp;
    private int _stackIndex;

    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

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

    public void Exchange()
    {
        transform.position = _startPos;

        _isPickedUp = false;
        _stackIndex = 0;
    }
}
