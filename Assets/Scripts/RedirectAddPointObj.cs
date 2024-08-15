using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RedirectAddPointObj : MonoBehaviour
{
    [SerializeField] private TMP_Text _text; //testing 
    [SerializeField] private Transform parentButton;
    [SerializeField] private CameraChangePos btObject; //button

    [SerializeField] private GameObject whereToSpawnInHierchy;

    [SerializeField] private Transform currentCameraPos; //pos where redirect spawns
    [SerializeField] private RedirectPoint ballGMObject; //redirect ball

    public void CreateButtonAndObject()
    {
        if (RedirectPointSpawnerButt.Instance.redirectButtons.Count <
            RedirectPointSpawnerButt.Instance.redirectButtNumb.Count)
        {
            // instantiate button in canvas parent tree
            var butt = Instantiate(btObject, parentButton);
            var ball = Instantiate(ballGMObject, currentCameraPos);
            // get id?

            butt.cameraTransferPosition = currentCameraPos;
            RedirectPointSpawnerButt.Instance.redirectButtons.Add(butt);
            RedirectPointSpawnerButt.Instance.redirectPoints.Add(ball);
            // в лісті видаляти обєкт+нулл
            //RedirectPointSpawnerButt.Instance.redirectButtons.

            // посилання на себе і файл у скрипті префаба


            // add func when maxButton-1 to hide this button and show when maxButton but deleting 1RedirectPointButton
        }
    }
}