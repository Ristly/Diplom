using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeSpawner : MonoBehaviour
{
    public GameObject CellPref;
    public GameObject PlayerPrefab;

    public AudioSource QuestTrackLine;
    public AudioSource BackgroundTrackLine;
    public AudioSource FailLine;

    private DoubleClickClass forClick;


    void Start()
    {
        Init();
        Debug.Log(PlayerPrefs.GetFloat("voice"));
        QuestTrackLine.volume = PlayerPrefs.GetFloat("voice");
        BackgroundTrackLine.volume = PlayerPrefs.GetFloat("music");
        FailLine.volume = PlayerPrefs.GetFloat("voice");
        BackgroundTrackLine.Play();
        forClick = new DoubleClickClass();
    }
    public void Init()
    {
        QuestTrackLine.Play();
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GenerateMaze();
        PlayerPrefab.transform.position = new Vector3(-6f, -3f, -1);


        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPref, new Vector2(x*2 - 7, y*2 - 4f), Quaternion.identity).GetComponent<Cell>();

                c.WallLeft.SetActive(maze[x, y].WallLeft);
                c.WallBottom.SetActive(maze[x, y].WallBottom);

                if (maze[x, y].ExitX != null && maze[x, y].ExitY != null)
                {
                    //Debug.Log("R");
                    //Debug.Log("x->"+ x + " y->"+ y);
                    //Debug.Log(c.WallBottom.activeSelf+"bottom");
                    //Debug.Log(c.WallLeft.activeSelf + "left");

                    if (!c.WallBottom.activeSelf && y == maze.GetLength(1) - 1  || !c.WallBottom.activeSelf && y == 0)
                    {
                        c.BottomTp.SetActive(c.BottomTp);
                    }
                    else if (!c.WallLeft.activeSelf && x == maze.GetLength(0) - 1 || !c.WallLeft.activeSelf && x == 0)
                    {
                        c.LeftTp.SetActive(c.LeftTp);
                    }
                   
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene("MainMenu");
        }

    }

    public void MenuOutClick()
    {

        if (forClick.DoubleClick())
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
