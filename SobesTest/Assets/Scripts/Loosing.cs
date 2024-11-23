using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loosing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneController.Restart();
        }
    }
}
