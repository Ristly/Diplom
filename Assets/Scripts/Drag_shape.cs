using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drag_shape : MonoBehaviour
{

    float xDIFF;
    float yDIFF;

    private DoubleClickClass forClick;
  
    private float shapeRotation = 0;
    private float shapeTriangleSlotRotation = 0;

    private void Start()
    {
        for(int i = 0; i < Random.Range(1,5); i++) ShapeRotation();
        forClick = new DoubleClickClass();
    }

    private void OnMouseDown()
    {
        if (tag != "Player")
        {
            if (forClick.DoubleClick())
            {
                ShapeRotation();
            }
        }

        xDIFF = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        yDIFF = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        float xPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float yPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        transform.position = new Vector2(xPos - xDIFF, yPos - yDIFF);
    }

    private void ShapeRotation()
    {
        if (!Equals(tag, "circle"))
        {

            if (Equals(tag, "triangle") || Equals(tag, "triangleR"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, shapeTriangleSlotRotation += 60));
                if (shapeTriangleSlotRotation % 120 != 0 && shapeTriangleSlotRotation != 0)
                {
                    tag += "R";

                }
                else
                {
                    string temp = tag;
                    temp = temp.Substring(0, temp.Length - 1);
                    Debug.Log(temp);
                    tag = temp;
                }
            }
            else
            {

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, shapeRotation += 45));
                if (shapeRotation % 90 != 0 && shapeRotation != 0)
                {
                    tag += "R";

                }
                else
                {
                    string temp = tag;
                    temp = temp.Substring(0, temp.Length - 1);
                    Debug.Log(temp);
                    tag = temp;
                }
            }
        }
    }

}


