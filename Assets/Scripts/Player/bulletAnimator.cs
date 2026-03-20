using UnityEngine;

public class bulletAnimator : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] protected Animator animator;
    [Header("gameManager")]
    [SerializeField] protected GameObject gameManager;
    int state = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = gameManager.GetComponent<shopManager>().getBulletUpgradeCount();

        animator.SetInteger("coinState", state);
    }
}
