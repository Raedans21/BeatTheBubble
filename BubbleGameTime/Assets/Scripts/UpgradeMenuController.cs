using UnityEngine;

public class UpgradeMenuController : MonoBehaviour
{
    [SerializeField] GameObject UpgradeMenu;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        UpgradeMenu.SetActive(true);

    }

    public void OnExitClick()
    {
        UpgradeMenu.SetActive(false);
    }

}
