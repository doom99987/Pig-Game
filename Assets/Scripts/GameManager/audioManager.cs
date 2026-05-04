/****************************************************************************
* Name: audioManager.cs
* Author: David Konvisser
* DigiPen Email: david.konvisser@digipen.edu
* Course: Wanic Game Project
*
* Description: This script has all the audio manager functions.
*
****************************************************************************/
using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{
    [SerializeField] private AudioSource gameMusic;
    [SerializeField] private AudioSource deathSound;

    // Update is called once per frame
    void Update()
    {
        //checks if shop is open, if player is dead and decideds whether to pause, stop or unpause the music.
        if (gameObject.GetComponent<playScenePanelManager>().getIsShopOpen() || gameObject.GetComponent<gameManager>().getGameState())
        {
            gameMusic.Stop();
            gameObject.GetComponent<roundManager>().setMusicbool();
        }else if(gameObject.GetComponent<playScenePanelManager>().getIsPauseOpen())
        {
            gameMusic.Pause();
        }
        else if (gameObject.GetComponent<hpManager>().getIsDead() == true)
        {
            gameMusic.Stop();
            gameObject.GetComponent<roundManager>().setMusicbool();
        }else
        {
            gameMusic.UnPause();
        }
    }


    /// <summary>
    /// plays the enemy death sound effect.
    /// </summary>
    public void playEnemyDeathSound()
    {
               deathSound.Play();
    }
}
