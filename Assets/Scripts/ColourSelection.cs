using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ColourSelection : MonoBehaviour
{
    public GameObject[] spawns;

    public AudioSource[] QuestLines;
    public AudioSource BackgroundMusic;
    public AudioSource FailLine;

    public GameObject[] thingsPrefs;
    public GameObject quest;

    private DoubleClickClass forClick;

    enum Quests
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    void Start()
    {
        for(int i = 0; i< QuestLines.Length; i++)
        {
            QuestLines[i].volume = PlayerPrefs.GetFloat("voice");
        }
        BackgroundMusic.volume = PlayerPrefs.GetFloat("music");
        FailLine.volume = PlayerPrefs.GetFloat("voice");
        Init();
        forClick = new DoubleClickClass();
    }

    private string TranslateQuest(string title)
    {
        string translation = string.Empty;
        switch (title) 
        {
            case "Red":
                translation = "Красный";
                break;
            case "Blue":
                translation = "Синий";
                break;
            case "Green":
                translation = "Зелённый";
                break;
            case "Yellow":
                translation = "Жёлтый";
                break;
        }

        return translation;
    }

    public void Init()
    {
        int seed = Random.Range(0, 4);

        Quests currentQuest = (Quests)seed;
        QuestLines[seed].Play();
        quest.GetComponent<Text>().text = "Где " + TranslateQuest(currentQuest.ToString()) + " цвет?";

        List<int> numbers = new List<int>();
        numbers.Add(seed);
        while (numbers.Count != 2)
        {
            int a = Random.Range(0, thingsPrefs.Length);
            if (!numbers.Contains(a))
            {
                numbers.Add(a);
            }
        }

        
        int[] temp = RandomSpawn().ToArray();

        GameObject left = Instantiate(thingsPrefs[numbers[0]], new Vector3(spawns[temp[0]].transform.position.x, spawns[temp[0]].transform.position.y, -1), Quaternion.identity);
        
        GameObject right = Instantiate(thingsPrefs[numbers[1]], new Vector3(spawns[temp[1]].transform.position.x, spawns[temp[1]].transform.position.y, -1), Quaternion.identity);


        left.AddComponent<ItemClick>();
        ItemClick leftClick = left.GetComponent<ItemClick>();
        leftClick.SetQuestTitle(currentQuest.ToString());


        right.AddComponent<ItemClick>();
        ItemClick rightClick = right.GetComponent<ItemClick>();
        rightClick.SetQuestTitle(currentQuest.ToString());

        rightClick.setOp(left);
        leftClick.setOp(right);

        rightClick.setFailLine(FailLine);
        leftClick.setFailLine(FailLine);
    }

    private List<int> RandomSpawn()
    {
        List<int> numbers = new List<int>();
        while (numbers.Count != 2)
        {
            int a = Random.Range(0, 2);
            if (!numbers.Contains(a))
            {
                numbers.Add(a);
            }
        }
        return numbers;
    }

    public void MenuOutClick()
    {
        
        if (forClick.DoubleClick())
        {
            SceneManager.LoadScene("MainMenu");
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
}


