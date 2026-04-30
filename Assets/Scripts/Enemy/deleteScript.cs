/****************************************************************************
* Name: deleteScript.cs
* Author: Caleb Bohm
* DigiPen Email: caleb.bohm@digipen.edu
* Course: Wanic Game Project
*
* Description: deletes an object after a specified amount of time
*
****************************************************************************/

using System.Collections;
using UnityEngine;


public class deleteScript : MonoBehaviour
{
    [SerializeField] private int deleteDelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(delete(deleteDelay));
    }

    private IEnumerator delete(int delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
