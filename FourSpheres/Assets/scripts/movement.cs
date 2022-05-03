using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    //public GameObject Player_target;
    public int Perception_distance = 10;
    public float Speed;
    public LayerMask mask;

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {
        GameObject target = get_target();

        //check to make sure there is a target (they might all be dead)
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed);
        }
    }

    GameObject get_target() {

        //get a list of all colliders within line of sight of the combatant
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, Perception_distance, mask);

        GameObject closest_combatant = null;

        //set the first distance to infinity so the first combatant will be the closest no matter what until you have something to compare it to
        float distance = Mathf.Infinity;

        foreach (var combatant_collider in colliders)
        {
            //ignore self
            if(combatant_collider.name == this.name)
            {
                continue;
            }

            //ingore allies
            if(this.tag == combatant_collider.tag)
            {
                continue;
            }

            //check if combatant is dead
            if(combatant_collider == null)
            {
                continue;
            }

            

            //get the distance between this combantant and the next in the list of combatants
            Vector3 diff = combatant_collider.transform.position - this.transform.position;
            float curDistance = diff.sqrMagnitude;

            //compare this distance to that of the previous combatant, if it is closer, it becomes the current closest and it's distance is what is now compared
            if(curDistance < distance)
            {
                closest_combatant = combatant_collider.gameObject;
                distance = curDistance;
            }
        }
        return closest_combatant;

    }
}
