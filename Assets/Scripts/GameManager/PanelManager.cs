using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    public bool panelOpen = false;

    public void openPanel()
    {
        panelOpen = true;
        panel.SetActive(true);
    }

    public void closePanel()
    {
        panelOpen = false;
        panel.SetActive(false);
    }
}
