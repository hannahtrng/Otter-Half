using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class entryIntoCave1 : MonoBehaviour
{

    private Collider2D entranceColider;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");  // Log to check if the trigger is being entered

        // Check if the object tagged as "Player" entered the trigger
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered cave!");
            ChangeScene();
        }

    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Testing Scene for Shark Detection");
    }
}
