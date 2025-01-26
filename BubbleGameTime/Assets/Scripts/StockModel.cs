using TMPro;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class StockModel
{
    public string stockName;         // Name of the stock (e.g., "Tech", "Energy")
    public int sharesOwned;          // Number of shares owned
    public float sharePrice;         // Current price of a single share
    public float baseProfitPerShare; // Base profit generated per share per second
    public float priceIncreaseRate = 1.1f; // Multiplier for price increase after each purchase
    public float profitMultiplier = 1.0f;  // Multiplier for profit scaling
    public float profitInterval = 3.0f;    // Interval (in seconds) before adding profits

    public float protection = 0.0f;

    public float TotalSpent { get; private set; } // Total money spent on this stock

    private float profitTimer; // Timer to track the interval for profit generation
    private Coroutine updateCoroutine;

    // Add this property to expose the timer
    public float ProfitTimer => profitTimer;

    // TextMeshProUGUI fields for displaying information
    public TextMeshProUGUI sharesOwnedText;
    public TextMeshProUGUI sharePriceText;
    public TextMeshProUGUI profitPerSecondText;

    // Initialize stock with default values
    public void Initialize()
    {
        profitTimer = profitInterval;
        UpdateUI();
        StartUpdateCoroutine();
    }

    public void Reset()
    {
        sharesOwned = Mathf.FloorToInt(sharesOwned * protection);
        sharePrice = Mathf.Max(5, sharePrice * protection);
        baseProfitPerShare = Mathf.Max(5, baseProfitPerShare * protection);
        profitInterval = 3.0f;
        TotalSpent = 0;
        profitTimer = profitInterval;
        UpdateUI();

        // Reset and restart the coroutine
        StopUpdateCoroutine();
        StartUpdateCoroutine();
    }

    // Start the coroutine for updating profitPerSecondText
    private void StartUpdateCoroutine()
    {
        if (updateCoroutine == null)
        {
            updateCoroutine = MonoBehaviour.FindFirstObjectByType<MonoBehaviour>().StartCoroutine(UpdateProfitPerSecond());
        }
    }

    // Stop the coroutine if it's running
    private void StopUpdateCoroutine()
    {
        if (updateCoroutine != null)
        {
            MonoBehaviour.FindFirstObjectByType<MonoBehaviour>().StopCoroutine(updateCoroutine);
            updateCoroutine = null;
        }
    }

    // Coroutine to update profitPerSecondText every second
    private IEnumerator UpdateProfitPerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            UpdateUI(); // This will update profitPerSecondText
        }
    }

    // Update method to handle profit generation based on the interval
    public float UpdateProfit(float deltaTime)
    {
        if (sharesOwned == 0) return 0f; // No profit if no shares are owned

        profitTimer -= deltaTime;

        if (profitTimer <= 0f)
        {
            profitTimer = profitInterval; // Reset the timer
            return sharesOwned * baseProfitPerShare * profitMultiplier;
        }

        return 0f; // No profit added yet
    }

    public void BuyShare()
    {
        sharesOwned++;
        TotalSpent += sharePrice;
        sharePrice *= priceIncreaseRate;
        UpdateUI();
    }

    public float GetProfitPerInterval()
    {
        return sharesOwned * baseProfitPerShare * profitMultiplier;
    }

    private void UpdateUI()
    {
        if (sharesOwnedText != null)
        {
            sharesOwnedText.text = $"Shares: {sharesOwned}";
        }

        if (sharePriceText != null)
        {
            sharePriceText.text = $"Price: ${sharePrice:F2}";
        }

        if (profitPerSecondText != null && sharesOwned > 0)
        {
            profitPerSecondText.text = $"${GetProfitPerInterval():F2}/" + (profitInterval > 1 ? profitInterval.ToString() : "1") + " sec";
        }
    }
}