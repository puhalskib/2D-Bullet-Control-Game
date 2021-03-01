using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winZoneScript : MonoBehaviour
{
    public GameManagerScript gameManager;

    void OnTriggerEnter2D()
    {
        gameManager.CompleteLevel();
    }
}
