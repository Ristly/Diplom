using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeTrigger : MonoBehaviour
{

    private float shapeSlotRotation = 0;
    private float shapeTriangleSlotRotation = 0;
    private AudioSource fail;
    private void Start()
    {
        fail = FindObjectOfType<FiguresSpawner>().QuestFailureTrackLine;
        for (int i = 0; i < Random.Range(1, 5); i++) ShapeSlotRotation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Equals(collision.tag, this.tag))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if (FindObjectsOfType<Drag_shape>().Length == 1)
            {
                FiguresSpawner restart = FindObjectOfType<FiguresSpawner>();
                restart.Init();
            }
        }
        else
        {
            fail.Play();
        }
    }

    private void ShapeSlotRotation()
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

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, shapeSlotRotation += 45));
                if (shapeSlotRotation % 90 != 0 && shapeSlotRotation != 0)
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
