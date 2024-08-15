using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RedirectPointSpawnerButt : MonoBehaviour
{
    public Transform cameraWatcherPos;

    [SerializeField] private int maxButtons;
    [SerializeField] private int currentButtons;

    // this own position to modify in DOTWEEN
    [SerializeField] private Vector3 posOnSet;
    [SerializeField] private Vector3 posOffSet;
    [SerializeField] private Transform myRedirectTabsPos;
    [SerializeField] private Transform myAddTargetTabs;
    private bool isOffSetRedirectTabs;
    private bool isOffSetAddTargetTabs;

    // ВАЖЛИВЕ ПХД
    public List<CameraChangePos> redirectButtons;

    // мб добавити ще ліст файлів редайректПоінт
    public List<RedirectPoint> redirectPoints;
    // мб ліст bool
    public List<bool> redirectButtNumb;
   
    
    // SINGLETON
    public static RedirectPointSpawnerButt Instance { get; private set; }

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


    public void OffRedirectTab()
    {
        
        // проблема з координатами, пхд треба .локалКоорд, чи змінити коорд в канвасі
        if (isOffSetRedirectTabs)
        {
            // ROBE!
            
            myRedirectTabsPos.localPosition = myRedirectTabsPos.TransformDirection(posOnSet);
            isOffSetRedirectTabs = !isOffSetRedirectTabs;
        }
        else
        {
            
            myRedirectTabsPos.localPosition = myRedirectTabsPos.TransformDirection(posOffSet);
            isOffSetRedirectTabs = !isOffSetRedirectTabs;
        }
        
        // шоб не накладались два інтерфейса відвести в сторону offset AddTarget tab
        if (isOffSetAddTargetTabs)
        {
            myAddTargetTabs.localPosition = myAddTargetTabs.TransformDirection(posOnSet);
            isOffSetAddTargetTabs = !isOffSetAddTargetTabs;
        }
    }
    
    public void OffAddTargetTab()
    {
        
        // проблема з координатами, пхд треба .локалКоорд, чи змінити коорд в канвасі
        if (isOffSetAddTargetTabs)
        {
            // ROBE!
            
            myAddTargetTabs.localPosition = myAddTargetTabs.TransformDirection(posOnSet);
            isOffSetAddTargetTabs = !isOffSetAddTargetTabs;
        }
        else
        {
            
            myAddTargetTabs.localPosition = myAddTargetTabs.TransformDirection(posOffSet);
            isOffSetAddTargetTabs = !isOffSetAddTargetTabs;
        }
        
        // offset redirect tab
        if (isOffSetRedirectTabs)
        {
            myRedirectTabsPos.localPosition = myRedirectTabsPos.TransformDirection(posOnSet);
            isOffSetRedirectTabs = !isOffSetRedirectTabs;
        }
    }

    public void PlayWithoutTabs()
    {
        // offset both
        if (isOffSetRedirectTabs)
        {
            myRedirectTabsPos.localPosition = myRedirectTabsPos.TransformDirection(posOnSet);
            isOffSetRedirectTabs = !isOffSetRedirectTabs;
        }
        if (isOffSetAddTargetTabs)
        {
            myAddTargetTabs.localPosition = myAddTargetTabs.TransformDirection(posOnSet);
            isOffSetAddTargetTabs = !isOffSetAddTargetTabs;
        }
        // camera on ball + can shoot ball ...
    }

    private void Start()
    {
        // list bool
        for (int i = 0; i < 8; i++)
        {
            redirectButtNumb.Add(false);
        }
    }
}