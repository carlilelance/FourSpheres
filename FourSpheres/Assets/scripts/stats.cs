using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

    public weapon_stats[] this_weapon_stats;

    public int Strength = 50;
    public int Right_arm_strength = 50;
    public int Left_arm_strength = 50;

    public int Agility = 50;
    public int Left_arm_agility = 50;
    public int Right_arm_agility = 50;

    public int Speed = 50;

    public int Defense = 50;

    public int Life = 50;

    //need calculated
    public int Attack_Speed = 0; //how many seconds the combatant must wait until it can attack again;

    //// Use this for initialization
    void Start()
    {
        //get attack speed
        Attack_Speed = get_attack_speed();
    }

    //// Update is called once per frame
    //void Update () {

    //}

    int get_attack_speed()
    {
        return 0;
    }
}
