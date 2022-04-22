using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    void OnTriggerEnter2d(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            SceneManager.LoadScene("LevelTwo");
          
        }
    }
}

  
