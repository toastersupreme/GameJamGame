using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPause : MonoBehaviour
{
    
    void Start()
    {
        DoNotDestroyMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    
    void Update()
    {
        
    }
}
