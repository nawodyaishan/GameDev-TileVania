using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePesist : MonoBehaviour
{
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<ScenePesist>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}