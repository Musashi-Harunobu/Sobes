using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIContorller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lapCountTXT;

    private void Update()
    {
        _lapCountTXT.text = $"Lap  number: {GameManager.LapCount}";
    }
}
