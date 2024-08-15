using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragForcePower : MonoBehaviour
{
    // UI Slider changer of power
    [SerializeField] private Slider slider;
    public float forcePowerAmplifier = 1f;
    public static DragForcePower Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    /*
    private void OnMouseDrag()
    {
        forcePowerAmplifier = slider.value;
        Debug.Log(""+forcePowerAmplifier);
    }

    private void OnMouseUp()
    {
        forcePowerAmplifier = slider.value;
        Debug.Log(""+forcePowerAmplifier);
    }

    */
    public void ChangeForce()
    {
        // оптимізувати потім 
        forcePowerAmplifier = slider.value;
        Debug.Log(""+forcePowerAmplifier);
    }
}
