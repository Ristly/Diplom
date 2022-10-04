using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FiguresSpawner : MonoBehaviour
{
    public GameObject[] slotSpawner;
    public GameObject[] slots;
    public GameObject[] figures;
    public GameObject[] figureSpawner;

    public AudioSource QuestTrackLine;
    public AudioSource QuestFailureTrackLine;
    public AudioSource RotationTrackLine;

    private DoubleClickClass forClick;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        Debug.Log(PlayerPrefs.GetFloat("voice"));
        QuestTrackLine.volume = PlayerPrefs.GetFloat("voice");
        QuestFailureTrackLine.volume = PlayerPrefs.GetFloat("voice");
        forClick = new DoubleClickClass();

    }

    public void Init()
    {
        QuestTrackLine.Play();
        List<int> numbers = new List<int>();
        while (numbers.Count != 3)
        {
            int a = Random.Range(0, figures.Length);
            if (!numbers.Contains(a))
            {
                numbers.Add(a);
            }
        }
        for (int i = 0;i < figureSpawner.Length;i++)
        {
            GameObject fig = Instantiate(figures[numbers[i]], new Vector2(figureSpawner[i].transform.position.x, figureSpawner[i].transform.position.y), Quaternion.identity);
            fig.AddComponent<Drag_shape>();

            GameObject slot = Instantiate(slots[numbers[i]], new Vector2(slotSpawner[i].transform.position.x, slotSpawner[i].transform.position.y), Quaternion.identity);
            slot.AddComponent<ShapeTrigger>();
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
