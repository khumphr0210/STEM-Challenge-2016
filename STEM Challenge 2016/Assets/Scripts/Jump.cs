using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Jump : EventTrigger
{
    public PlayerMovement jumpMove;

    void Start()
    {
        jumpMove = FindObjectOfType<PlayerMovement>();
    }
    public override void OnPointerDown(PointerEventData data)
    {
        jumpMove.Jump();
    }

    public void JumpMove()
    {
        //if (!PlayerMovement.isFalling)
        jumpMove.Jump();
    }
}
