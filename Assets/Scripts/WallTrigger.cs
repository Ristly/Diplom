using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private AudioSource Fail;
    private void Start()
    {
        Fail = FindObjectOfType<MazeSpawner>().FailLine;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = new Vector3(-6f, -3f, -1);
        Fail.Play();
    }
}
