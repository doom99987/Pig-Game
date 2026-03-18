using UnityEngine;
public class playerShoot : MonoBehaviour
{
    protected float elapsedTime;

    [SerializeField] GameObject bullet;

    [SerializeField] protected float delay = 1f;
    [SerializeField] protected int bulletDmg = 1;
    [SerializeField] protected float bulletSpeed = 5f;
    [SerializeField] protected int bulletPierce = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && elapsedTime <= 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 dir = (mousePos - gameObject.transform.position);
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90;

            Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0, 0, angle));
            elapsedTime = delay;
        }
        if (elapsedTime >= 0)
        {
            elapsedTime -= Time.deltaTime;
        }
    }

}
