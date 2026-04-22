using UnityEngine;

public class moneyShopUpgradeLevel : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animator;

    private GameObject gameManager;

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("gameManager");
        animator.SetInteger("coinState", gameManager.GetComponent<shopManager>().getBulletUpgradeCount());
    }
}
