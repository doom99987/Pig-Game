using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class bombManager : MonoBehaviour
{
    [SerializeField] protected GameObject bombPrefab;
    [SerializeField] protected TextMeshProUGUI bombCdText;
    [SerializeField] protected GameObject player;
    [Header("Bomb Stats")]
    [SerializeField] protected int bombDmg = 10;
    [SerializeField] protected int coolDown = 10;
    [SerializeField] protected bool bombBought = false;
    [SerializeField] protected float cdTimer = 0;
    [SerializeField] protected float imgRotation = 90;
    protected bool bombUsed;

    public void Start()
    {
        if(bombBought)
        {
            bombCdText.gameObject.SetActive(true);
        }
         else
        {
            bombCdText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 dir = (mousePos - player.transform.position);
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + imgRotation;

        cdTimer = Time.deltaTime + coolDown;
        

        if (!gameObject.GetComponent<gameManager>().getGameState())
        {
            if(cdTimer <= 0)
            {
                bombUsed = false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(bombPrefab, player.transform.position, Quaternion.Euler(0, 0, angle));
                bombUsed = true;
            }
            if (coolDown >= 0)
            {
                cdTimer -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if (bombBought)
        {
            bombCdText.text = Mathf.Ceil(cdTimer).ToString();
        }
        if (bombBought)
        {
            bombCdText.gameObject.SetActive(true);
        }
        else
        {
            bombCdText.gameObject.SetActive(false);
        }
    }

    public void bombIsBought()
    {
        bombBought = true;
        bombCdText.gameObject.SetActive(true);
    }
}

