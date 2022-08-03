using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSystem : MonoBehaviour
{
    public int maxStackCount = 3;
    public int currentStackCount = 0;
    public float stackHeightOffset = 1f;

    public List<Gold> golds;

    public bool CheckStackCount()
    {
        if (currentStackCount < maxStackCount)
            return true;

        return false;
    }

    public Vector3 SelectTargetPosition(int stackIndex)
    {
        Vector3 nextPos = transform.position + transform.up * stackHeightOffset;

        nextPos.y += stackIndex * 0.5f;

        return nextPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteractable>().Interact();
    }
}
