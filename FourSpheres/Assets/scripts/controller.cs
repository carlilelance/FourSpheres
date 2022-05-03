using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class controller : MonoBehaviour {

    protected CharacterController control;
    protected Animator anim;

    protected Vector3 move = Vector3.zero;

    public float MoveSpeed = 10f;
    public float TurnSpeed = 450f;

    // Use this for initialization
    public virtual void Start () {
        control = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        if (!control)
        {
            Debug.Log("knight_controller.Start() " + name + " has no CharacterController");
            enabled = false;
        }
        if (!anim)
        {
            Debug.Log("knight_controller.Star() " + name + " has not Animator");
        }
	}
	
	// Update is called once per frame
	public virtual void Update () {
        control.SimpleMove(move * MoveSpeed);
	}
}
