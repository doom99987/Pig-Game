using UnityEngine;

public class bombManager : MonoBehaviour
{
    [SerializeField] protected GameObject bombPrefab;
    [Header("Bomb Stats")]
    [SerializeField] protected int bombDmg = 10;
    [SerializeField] protected int coolDown = 10;
    [SerializeField] protected bool bombBought = false;

    // Update is called once per frame
    void Update()
    {
        
    }
}
