using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;


public class StockManager : MonoBehaviour
{
    public List<StockModel> stocks; // List of all stocks
    public List<ButtonCooldownSlider> sliders; // List of sliders for cooldowns
    public float money = 100;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyText2;
    public TextMeshProUGUI netWorthText;

    public List<Sprite> avatars;
    //internal readonly object someStock;
    public AnimationController animationController;

    private void Start()
    {
        if (stocks == null || stocks.Count == 0)
        {
            stocks = new List<StockModel>
            {
                new StockModel { stockName = "Auto", sharePrice = 10, sharesOwned = 0, baseProfitPerShare = 5 },
                new StockModel { stockName = "Tech", sharePrice = 10, sharesOwned = 0, baseProfitPerShare = 5 },
                new StockModel { stockName = "Energy", sharePrice = 10, sharesOwned = 0, baseProfitPerShare = 5 },
                new StockModel { stockName = "Healthcare", sharePrice = 10, sharesOwned = 0, baseProfitPerShare = 5 },
                new StockModel { stockName = "Real Estate", sharePrice = 10, sharesOwned = 0, baseProfitPerShare = 5 },
                new StockModel { stockName = "Entertainment", sharePrice = 10, sharesOwned = 0, baseProfitPerShare = 5 },
                new StockModel { stockName = "Aerospace", sharePrice = 10, sharesOwned = 0, baseProfitPerShare = 5 },
                new StockModel { stockName = "Fashion", sharePrice = 10, sharesOwned = 0, baseProfitPerShare = 5 },
            };
        }

        //Ensure sliders are assigned and linked to stocks
        if (sliders.Count != stocks.Count)
        {
            return;
        }

        for (int i = 0; i < stocks.Count; i++)
        {
            stocks[i].Initialize();
            sliders[i].Initialize(stocks[i]);
        }

        UpdateUI();
    }

    public void BubbleBurst(int level)
    {
        int toReset = UnityEngine.Random.Range(3, 5);
        List<int> indexes = new List<int>(Enumerable.Range(0, stocks.Count));
        for (int i = 0; i < toReset; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, indexes.Count);
            int stockIndex = indexes[randomIndex];
            StartCoroutine(PlayAnimationForOneSecond(stockIndex));
            stocks[stockIndex].Reset();
            sliders[stockIndex].Reset();
            indexes.RemoveAt(randomIndex);
        }
        FixedUpdate();
    }

    private IEnumerator PlayAnimationForOneSecond(int index)
    {
        animationController.animations[index].SetActive(true);
        yield return new WaitForSeconds(1.7f);
        animationController.animations[index].SetActive(false);
    }

    private void FixedUpdate()
    {
        float totalProfit = 0f;

        // Update each stock's profit and sliders
        for (int i = 0; i < stocks.Count; i++)
        {
            var stock = stocks[i];
            var slider = sliders[i];

            if (stock.sharesOwned > 0)
            {
                // Update stock profit and add to total
                float profit = stock.UpdateProfit(Time.fixedDeltaTime);
                totalProfit += profit;

                // Update slider progress
                slider.UpdateProgress(stock.ProfitTimer / stock.profitInterval);
            }
        }

        // Add total profit to money
        money += totalProfit;

        // Update the UI
        UpdateUI();
    }

    public float CalculateNetWorth()
    {
        return stocks.Sum(stock => stock.TotalSpent) + money;
    }


    private void UpdateUI()
    {
        if (moneyText != null)
            moneyText.text = $"${money:F2}";
            moneyText2.text = $"${money:F2}";

        if (netWorthText != null)
            netWorthText.text = $"${CalculateNetWorth():F2}";
    }

    public void BuyStock(int stockIndex)
    {
        StockModel stock = stocks[stockIndex];

        if (money >= stock.sharePrice)
        {
            money -= stock.sharePrice;
            stock.BuyShare();

        }
        else
        {
        }
    }
}
