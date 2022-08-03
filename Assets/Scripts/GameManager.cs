using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public StackSystem stackSystem;


    public int currentGold = 0;

    private void Awake()
    {
        instance = this;
    }

}
