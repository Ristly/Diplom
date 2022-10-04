using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float Speed = 1;

    bool flagUp = false;
    bool flagRight = false;
    bool flagBottom = false;
    bool flagLeft = false;

    public GameObject componentRigidbody;
    private Rigidbody2D rb;

    private void Start()
    { 
        rb = componentRigidbody.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
        rb.velocity = Vector2.zero;

        if(flagUp) rb.velocity += Vector2.up * Speed;
        if(flagRight) rb.velocity += Vector2.right * Speed;
        if(flagBottom) rb.velocity += Vector2.down * Speed;
        if(flagLeft) rb.velocity += Vector2.left * Speed;
    }

    public void UpArrowPressed()
    {
        flagUp = true;
    }
    public void UpArrowUp()
    {
        flagUp = false;  
    }
    public void RightArrowPressed()
    {
        flagRight = true;
    }
    public void RightArrowUp()
    {
        flagRight = false;
    }
    public void BottomArrowPressed()
    {
        flagBottom = true;
    }
    public void BottomArrowUp()
    {
        flagBottom = false;
    }

    public void LeftArrowPressed()
    {
        flagLeft = true;
    }
    public void LeftArrowUp()
    {
        flagLeft = false;
    }
}
