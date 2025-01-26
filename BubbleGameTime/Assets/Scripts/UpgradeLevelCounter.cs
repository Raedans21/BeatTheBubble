using UnityEngine;
using TMPro;

public class UpgradeLevelCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upgradeLevel;
    [SerializeField] TextMeshProUGUI currentCost;
    public float money;
    private int level = 0;
    [SerializeField] private float upgradeCost = 10;
    [SerializeField] private float protectionCost = 100;
    private StockManager stockManager;

    private void Start()
    {
        stockManager = FindFirstObjectByType<StockManager>();
        currentCost.text = "$ " + upgradeCost.ToString();
    }

    public void OnClickLevelUp()
    {
        if (stockManager.money >= upgradeCost && stockManager.stocks != null && stockManager.stocks.Count > 0)
        {
            stockManager.money -= upgradeCost;
            upgradeCost *= 2;
            currentCost.text = "$ " + upgradeCost.ToString();
            level++;
            upgradeLevel.text = "Lvl. " + level.ToString();
        }
    }

    public void OnClickProtection()
    {
        if (stockManager.money >= protectionCost)
        {
            stockManager.money -= protectionCost;
            protectionCost *= 4;
            currentCost.text = "$ " + protectionCost.ToString();
            level++;
            upgradeLevel.text = "Lvl. " + level.ToString();
        }
    }
}