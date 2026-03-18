using UnityEngine;

[CreateAssetMenu(fileName = "bullets", menuName = "Scriptable Objects/bullets")]
public class bullets : ScriptableObject
{
    [SerializeField] SpriteRenderer[] bulletSprites;
    [SerializeField] protected int bulletDmg = 1;
    [SerializeField] protected float bulletSpeed = 5f;
    [SerializeField] protected int bulletPierce = 0;
}
