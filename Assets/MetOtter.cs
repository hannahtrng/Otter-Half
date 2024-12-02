using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetOtter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something encountered Otter Half");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player found Otter Half!");

            SceneManager.LoadScene("Winning");
        }
    }

}

