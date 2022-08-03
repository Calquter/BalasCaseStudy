using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance;

    //Cache
    public StackSystem stackSystem;
    public PlayerMovement playerMovement;

    //Player Stats
    public int currentGold = 0;
    private int energyUpgradeCount = 1;
    private int speedUpgradeCount = 1;
    private int stackUpgradeCount = 1;

    //UI-Canvas
    public Slider energySlider;
    public TMPro.TMP_Text goldText;


    private void Awake()
    {
        instance = this;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private bool ControlGold(int spendAmount)
    {
        if (spendAmount > currentGold)
            return false;

        currentGold -= spendAmount;
        goldText.text = $"{currentGold}$";
        return true;
    }

    public void EnergyUpgrade()
    {
        if (ControlGold(energyUpgradeCount * 25))
        {
            playerMovement.maxStamina += 15;
            playerMovement.currentStamina += 15;
            energySlider.maxValue = playerMovement.maxStamina;
            playerMovement.ChangeStamina();
            energyUpgradeCount++;
            ResumeGame();
        }
    }

    public void SpeedUpgrade()
    {
        if (ControlGold(speedUpgradeCount * 50))
        {
            playerMovement.moveSpeed++;
            speedUpgradeCount++;
            ResumeGame();
        }
    }

    public void StackUpgrade()
    {
        if (ControlGold(stackUpgradeCount * 50))
        {
            stackSystem.maxStackCount++;
            stackUpgradeCount++;
            ResumeGame();
        }
    }

}
