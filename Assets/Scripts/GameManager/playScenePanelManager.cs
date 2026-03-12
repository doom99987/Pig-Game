using UnityEngine;

public class playScenePanelManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject victoryPanel;
    public void openShopPanel()
    {
        shopPanel.SetActive(true);
    }
    public void openDeathPanel()
    {
        deathPanel.SetActive(true);
    }
    public void openVictoryPanel()
    {
        deathPanel.SetActive(true);
    }
    public void closeAllPanel()
    {
        shopPanel.SetActive(false);
        deathPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }
    public void closeShopPanel()
    {
        shopPanel.SetActive(false);
    }
    public void closeDeathPanel()
    {
        deathPanel.SetActive(false);
    }
    public void closeVictoryPanel()
    {
        victoryPanel.SetActive(false);
    }
}
