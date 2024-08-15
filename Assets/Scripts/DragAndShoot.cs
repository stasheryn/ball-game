using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 pressDownPos;
    private Vector3 onReleasePos;
    [SerializeField] private Transform pos;
    [SerializeField] private float forceMultiplier = 4f;
    [SerializeField] private Rigidbody rb;
    private bool isShooted;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnMouseDown()
    {
        // івенти, як воно розуміє який конкретно обєкт адд форс якщо їх декілька
        OnTouchDown();
    }

    private void OnMouseDrag()
    {
        // Траєкторія
        OnTouchDrag();
    }

    private void OnMouseUp()
    {
        OnTouchUp();
    }

    private void OnTouchDown()
    {
        pressDownPos = Input.mousePosition;
    }

    private void OnTouchDrag()
    {
        onReleasePos = Input.mousePosition;

        // мб якось скоротити
        Vector3 force = new Vector3((pressDownPos.x - onReleasePos.x) * forceMultiplier,
            (pressDownPos.y - onReleasePos.y) * forceMultiplier, (pressDownPos.y - onReleasePos.y) * forceMultiplier);
        // виключати траєкторію при польоті
        TrajectoryRenderer.Instance.DrawNewTrajectory(pos.position, force, rb);
    }

    private void OnTouchUp()
    {
        onReleasePos = Input.mousePosition;
        Shoot(pressDownPos - onReleasePos);
        TrajectoryRenderer.Instance.HideTrajectory();
    }

    private void Shoot(Vector3 force)
    {
        // метод який фактично стріляє мячем
        if (isShooted)
            return;
        // це блін так не очевидно що замість z треба ще раз заюзати y
        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        isShooted = true;
    }

    public void AddNewForce(Vector3 force)
    {
        rb.AddForce(force);
    }
}