using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public StackSystem stackSystem;

    private void Awake()
    {
        instance = this;
    }

}
