  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatant_behaviour : MonoBehaviour {

    //public GameObject Player_target;
    public int Perception_distance = 10;
    public float Speed;
    public LayerMask mask;
    public int Weapon_range = 100;
    public int Attack_speed = 1;

    private float weapon_range;
    private bool in_melee;
    private float time_to_next_attack;
    private float start_time_to_next_attack;
    private GameObject target;
    private float distance_to_target;
    private float speed;
    //private int white_count = 0;
    //private int black_count = 0;

    void Start()
    {
        weapon_range = ((float)Weapon_range) / 10;
        start_time_to_next_attack = (1 / (float)Attack_speed) * 4;
        time_to_next_attack = start_time_to_next_attack;
        speed = Speed/30; //so objects start out moving

    }

    // Update is called once per frame
    void Update()
    {
        target = get_target();

        //check to make sure there is a target (they might all be dead)
        if (target != null && !in_melee)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            //how far away is the target?
            //get the distance between this combantant and the next in the list of combatants
            Vector3 diff = gameObject.transform.position - target.transform.position;
            distance_to_target = diff.sqrMagnitude;

            if (distance_to_target < weapon_range)
            {
                in_melee = true;
            }
        }
        

        //handle attacks if in melee
        if (in_melee)
        {
            time_to_next_attack = time_to_next_attack - Time.deltaTime;

            //attack according to attack speed
            if (time_to_next_attack < 0)
            {
                bool dead = melee_attack(target);
                if (dead)
                {
                    in_melee = false;
                    time_to_next_attack = start_time_to_next_attack;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(target != null && !in_melee) //both vars are private global
        {
            //move backwards out of collision
            //transform.position = Vector3.MoveTowards(transform.position, -target.transform.position, Speed);
            //randomize the rotation
            float rotation_amount = Random.Range(-1, 1);
            //rotate and move
            transform.RotateAround(target.transform.position, Vector3.up, rotation_amount);
        }

    }

    GameObject get_target()
    {

        //get a list of all colliders within line of sight of the combatant
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, Perception_distance, mask);

        GameObject closest_combatant = null;

        //set the first distance to infinity so the first combatant will be the closest no matter what until you have something to compare it to
        float distance = Mathf.Infinity;

        foreach (var combatant_collider in colliders)
        {
            //ignore self
            if (combatant_collider.name == this.name)
            {
                continue;
            }

            //ingore allies
            if (this.tag == combatant_collider.tag)
            {
                continue;
            }

            //check if combatant is dead
            if (combatant_collider == null)
            {
                continue;
            }



            //get the distance between this combantant and the next in the list of combatants
            Vector3 diff = combatant_collider.transform.position - this.transform.position;
            float curDistance = diff.sqrMagnitude;

            //compare this distance to that of the previous combatant, if it is closer, it becomes the current closest and it's distance is what is now compared
            if (curDistance < distance)
            {
                closest_combatant = combatant_collider.gameObject;
                distance = curDistance;
            }
        }
        return closest_combatant;

    }

    //melee atack
    private bool melee_attack(GameObject target)
    {
        //check to see if the target has already been killed
        if(target == null)
        {
            in_melee = false;
            return true; //target is dead
        }
        bool dead = false;

        int roll = Random.Range(0, 100);

        if (roll < 50)
        {
            Destroy(target);
            if(target.tag == "White")
            {
                //create_battle.White_Total--;
                HUD_manager.White_Total--;
            } else
            {
                //create_battle.Black_Total--;
                HUD_manager.Black_Total--;
            }
            Debug.Log(HUD_manager.White_Total);
            dead = true;
        }
        return dead; //the target isn't dead
    }
}
