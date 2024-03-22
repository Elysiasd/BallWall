using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerToBallManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 force;
    private Vector2 mouseDownPos;
    private Vector2 mouseUpPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = Ball.Instance.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseUpPos = Input.mousePosition;
            force = mouseUpPos - mouseDownPos;
            rb.AddForce(force);
        }
    }
}
