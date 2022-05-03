using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_knight : controller {

    public string Attack;
    public string Run;

    private float input_h;
    private float input_v;

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
       
        //get inputs to use for animations
        input_h = Input.GetAxis("Horizontal");
        input_v = Input.GetAxis("Vertical");
        anim.SetFloat("input_h", input_h);
        anim.SetFloat("input_v", input_v);

        //rotation

        transform.Rotate(0f, Input.GetAxis("Right_Horizontal") * TurnSpeed * Time.deltaTime, 0f);

        //movement  
        move = new Vector3(input_h, 0f, input_v);
        //move = new Vector3(0f, 0f, 0f);

        move.Normalize(); //takes care of diagonal movement so it doesn't double the speed

        move = transform.TransformDirection(move); //makes the character move forward in relative space instead of world space

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////animations

        //attack
        if (Input.GetButton("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("WK_heavy_infantry_08_attack_B"))
        {
            //force player to stop
            anim.Play("WK_heavy_infantry_08_attack_B", -1, 0f);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("WK_heavy_infantry_08_attack_B"))
        {
            move = Vector3.zero;
        }

        base.Update();

       
	}
}
