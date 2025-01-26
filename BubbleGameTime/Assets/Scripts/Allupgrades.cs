using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Allupgrades : MonoBehaviour
{
    private StockManager stockManager;
    private bool[] isOnCooldown = new bool[8]; // One for each upgrade method

    private void Start()
    {
        stockManager = FindFirstObjectByType<StockManager>();
    }

    private IEnumerator CooldownTimer(int index)
    {
        isOnCooldown[index] = true;
        yield return new WaitForSeconds(1f); // Wait for 1 second
        isOnCooldown[index] = false;
    }

    private void Upgrade(int index, Button button = null, bool method = true)
    {
        if (!isOnCooldown[index])
        {
            if(method)
            {
                stockManager.stocks[index].profitMultiplier += 0.2f;
            } else
            {
                stockManager.stocks[index].protection += 0.1f;
                if(stockManager.stocks[index].protection >= 0.5f)
                {
                    button.interactable = false;
                }
            }
            StartCoroutine(CooldownTimer(index));
        }
    }

    public void AutoUpgrade(bool method = true)
    {
        Upgrade(0, GetComponent<Button>(), method);
    }

    public void TechUpgrade(bool method = true)
    {
        Upgrade(1, GetComponent<Button>(), method);
    }

    public void EnergyUpgrade(bool method = true)
    {
        Upgrade(2, GetComponent<Button>(), method);
    }

    public void HealthcareUpgrade(bool method = true)
    {
        Upgrade(3, GetComponent<Button>(), method);
    }

    public void RealEstateUpgrade(bool method = true)
    {
        Upgrade(4, GetComponent<Button>(), method);
    }

    public void EntertainmentUpgrade(bool method = true)
    {
        Upgrade(5, GetComponent<Button>(), method);
    }

    public void AerospaceUpgrade(bool method = true)
    {
        Upgrade(6, GetComponent<Button>(), method);
    }

    public void FashionUpgrade(bool method = true)
    {
        Upgrade(7, GetComponent<Button>(), method);
    }
}