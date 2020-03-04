using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public GokuController player;
    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponentInParent<GokuController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    //Nếu chạm đất -> grounded = true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.grounded = true;
    }

    //Nếu đang trên mặt đất -> grounded = true
    private void OnTriggerStay2D(Collider2D collision)
    {
        player.grounded = true;
    }

    //Nếu thoát khỏi mặt đất -> grounded = true
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded = false;
    }
}
