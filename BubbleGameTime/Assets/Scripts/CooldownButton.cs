using UnityEngine;

public class ButtonCooldownSlider : MonoBehaviour
{
    public StockModel stock; // The associated stock
    [SerializeField] private RectTransform progressBar; // The progress bar
    [SerializeField] private RectTransform backgroundBar; // The full background bar for size reference

    private float barWidth; // The full width of the background bar

    public void Initialize(StockModel stock)
    {
        this.stock = stock;

        if (progressBar == null || backgroundBar == null)
        {
            return;
        }

        // Get the width of the full background bar
        barWidth = backgroundBar.sizeDelta.x;

        // Initialize the progress bar to empty
        UpdateProgress(1);
    }

    public void UpdateProgress(float progress)
    {
        // Clamp progress to ensure it stays within 0 and 1
        progress = Mathf.Clamp01(1 - progress);  // Invert the progress

        // Adjust the width of the progress bar
        progressBar.sizeDelta = new Vector2(barWidth * progress, progressBar.sizeDelta.y);
    }

    public void Reset()
    {
        UpdateProgress(1);
    }
}
