using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class IngameButtons : MonoBehaviour
{
    // вектор який задає напрям у редайректТочці
    [SerializeField] private Vector3 forceVector;
    // позиція обєкту або камери
    [SerializeField] private Transform positionOfObject;
    // в цей ліст повинні підписуватись інстанси при створенні точок і потім міняти кнопку в інтерфейсі
    public List<GameObject> myGameObjects;
    public GameObject currentGameObject;

    // list of buttons
    public List<Button> buttonsForAddRP;
    public List<Button> buttonsForTarget;
    // subscribe here to manage
    [SerializeField] private Camera _camera;
    //camera methods
    public void Rotate(float value)
    {
        var rotation = _camera.transform.rotation;
        rotation.y += value;
        _camera.transform.rotation = rotation;
    }
    
    public void SelectGO()
    {
        
    }
    // ХЗ ЩО ЦЕ ЗА ФАЙЛ ВИДАЛИТИ ПОТІМ
    
    
    public void AxisX(int addValue)
    {
        // rider запропонував це
        var vector3 = currentGameObject.transform.position;
        vector3.x += addValue;
        currentGameObject.transform.position = vector3;
    }
}
