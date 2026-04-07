using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] private AudioSource gameMusic;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<playScenePanelManager>().getIsShopOpen())
        {
            gameMusic.Pause();
        }
        else if (gameObject.GetComponent<hpManager>().getIsDead() == true)
        {
            gameMusic.Stop();
        }
        else
        {
            gameMusic.UnPause();
        }
    }
}
