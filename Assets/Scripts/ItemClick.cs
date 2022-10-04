using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    private string questTitle;
    public GameObject opposite;

    private ColourSelection next;
    private AudioSource Fail;

    public void SetQuestTitle (string title)
    {
        
        this.questTitle = title;
    }

    private void Start()
    {
        Debug.Log(questTitle);
    }
    public void setOp(GameObject gObject)
    {
        this.opposite = gObject;
    }

    public void setFailLine(AudioSource audioSource)
    {
        Fail = audioSource;
    }
    private void OnMouseDown()
    {

        
        if (tag == questTitle)
        {
            
            Destroy(opposite);
            Destroy(this.gameObject);

            next = FindObjectOfType<ColourSelection>();
            next.Init();
        }
        else
        {
            Fail.Play();
        }
       
    }
}
