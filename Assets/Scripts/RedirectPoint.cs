using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectPoint : MonoBehaviour
{
    [SerializeField] private Transform pos;
    [SerializeField] private LineRenderer lineRenderer;
    private Vector3 startPos;
    private Vector3 ForceRedirect;
    [SerializeField] private Vector3 sumVector;
    [SerializeField] private float forceAmpl = 1.4f;
    [SerializeField] private DragAndShoot ball;

    private void DrawTrajectoryToRedirect()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, pos.position);
        //lineRenderer.SetPosition(1, pos.position - (startPos - ForceRedirect).normalized * 4f);
        lineRenderer.SetPosition(1, pos.position - (sumVector).normalized * 4f);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.rigidbody.AddForce(ForceRedirect - startPos);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ball.AddNewForce(ForceRedirect - startPos);
            // ne robe :(
            //ball.AddNewForce((lineRenderer.GetPosition(1)-lineRenderer.GetPosition(0))*8f);
        }
    }

    private void OnMouseDown()
    {
        startPos = Input.mousePosition;
        //startPos.y = Input.mousePosition.y;
        //startPos.z = Input.mousePosition.y;
    }

    private void OnMouseDrag()
    {
        ForceRedirect = Input.mousePosition;
        ForceRedirect.y = Input.mousePosition.y;
        ForceRedirect.z = Input.mousePosition.y;
        /*
        ForceRedirect.x = Mathf.Clamp(Input.mousePosition.x,-400,400);
        ForceRedirect.y = Mathf.Clamp(Input.mousePosition.y,-400,400);
        ForceRedirect.z = Mathf.Clamp(Input.mousePosition.y,-400,400);
        */
        // sum for cap
        sumVector.x = Mathf.Clamp(startPos.x - ForceRedirect.x, -400, 400);
        sumVector.y = Mathf.Clamp(startPos.y - ForceRedirect.y, -400, 400);
        sumVector.z = Mathf.Clamp(startPos.z - ForceRedirect.z, -400, 400);
        DrawTrajectoryToRedirect();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < RedirectPointSpawnerButt.Instance.redirectPoints.Count; i++)
        {
            if (RedirectPointSpawnerButt.Instance.redirectPoints[i] == this)
            {
                RedirectPointSpawnerButt.Instance.redirectPoints.RemoveAt(i);
            }
        }
    }
}