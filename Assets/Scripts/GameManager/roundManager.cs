using UnityEngine;
using TMPro;

public class roundManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    protected float elapsedTime = 0f;


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //int minutes = Mathf.FloorToInt
        timerText.text = elapsedTime.ToString();
    }
    private void FixedUpdate()
    {
        
    }
}
