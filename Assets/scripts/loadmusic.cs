using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadmusic : MonoBehaviour
{
    private void Awake()
    {
        int music=FindObjectsOfType<loadmusic>().Length;
        if(music>1)
        {
            Destroy(gameObject);
        }
        else
        DontDestroyOnLoad(gameObject);
    }
 
}
