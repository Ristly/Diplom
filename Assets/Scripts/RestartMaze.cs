using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMaze : MonoBehaviour
{

    private MazeSpawner generator;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log('k');
        Cell[] temp = FindObjectsOfType<Cell>();
        for (int i = 0; i < temp.Length; i++) Destroy(temp[i].gameObject);
        generator = FindObjectOfType<MazeSpawner>();
        generator.Init();

    }
}
