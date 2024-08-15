using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraChangePos : MonoBehaviour
{
    // Script for button , camera script at MovementAtScene
    [SerializeField] private TMP_Text text;
    [SerializeField] private Transform cameraPos;//мб лишнє
    public Transform cameraTransferPosition;
    [SerializeField] private int myNumbInUI;
    
    public void ChangePosCamera()
    {
        // move object(Camera attached to) to this position
       MovementAtScene.Instance.MoveCameraTO(cameraTransferPosition.position);
    }

    public void DeleteTwoObjects()
    {
        for (int i = 0; i < RedirectPointSpawnerButt.Instance.redirectButtons.Count; i++)
        {
            if (RedirectPointSpawnerButt.Instance.redirectButtons[i] == this)
            {
                //робе
                RedirectPointSpawnerButt.Instance.redirectButtons[i].Destroy();
                RedirectPointSpawnerButt.Instance.redirectPoints[i].Destroy();
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        /*
        for (int i = 0; i < RedirectPointSpawnerButt.Instance.redirectButtons.Count; i++)
        {
            if (RedirectPointSpawnerButt.Instance.redirectButtons[i] == this)
            {
                text.text = "" + (i + 1);
            }
        }
        */

        for (int i = 0; i < RedirectPointSpawnerButt.Instance.redirectButtNumb.Count; i++)
        {
            if (RedirectPointSpawnerButt.Instance.redirectButtNumb[i] == false)
            {
                myNumbInUI = i + 1;
                RedirectPointSpawnerButt.Instance.redirectButtNumb[i] = true;
                text.text = "" + myNumbInUI;
                break;
            }
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < RedirectPointSpawnerButt.Instance.redirectButtons.Count; i++)
        {
            if (RedirectPointSpawnerButt.Instance.redirectButtons[i] == this)
            {
                RedirectPointSpawnerButt.Instance.redirectButtons.RemoveAt(i);
            }
        }
        // free number for UIbutton
        RedirectPointSpawnerButt.Instance.redirectButtNumb[myNumbInUI-1] = false;
    }
}
