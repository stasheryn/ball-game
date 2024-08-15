using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAtScene : MonoBehaviour
{
    [SerializeField] private Transform positionCamera;

    // buffer щось як змінна з посилання на конкретний обєкт над яким будуть працювати кнопки
    [SerializeField] private Transform buffer;
    private Transform redirectPointBuffer; // міняти мб в іншому скриптах 

    // mb buffer


    public static MovementAtScene Instance { get; private set; }

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

    private void Start()
    {
        buffer.position = positionCamera.position;
    }

    void Update()
    {
    }

    public void MoveCameraTO(Vector3 newPos)
    {
        positionCamera.position = newPos;
    }

    // сюди посилання на поінт який треба рухати і тд
    public void TakeRePointToBuffer(Transform newTransRedirectPoint)
    {
        redirectPointBuffer = newTransRedirectPoint;
    }
    // якщо робити рух через джойстік мб юзати await newTimeInSeconds

    public void ChangePosX(float addValue)
    {
        var vector3 = buffer.position;
        vector3.x += addValue;
        buffer.position = vector3;
    }

    public void ChangePosY(float addValue)
    {
        var vector3 = buffer.position;
        vector3.y += addValue;
        buffer.position = vector3;
    }

    public void ChangePosZ(float addValue)
    {
        var vector3 = buffer.position;
        vector3.z += addValue;
        buffer.position = vector3;
    }

    public void ChangeRotationY(float addValue)
    {
        //float yOsRot 
        positionCamera.localEulerAngles = new Vector3(0, positionCamera.localEulerAngles.y + addValue, 0);
    }
}