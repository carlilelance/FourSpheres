using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons { Hands, Short_sword };

public class melee : MonoBehaviour {


    public Weapons weapons = Weapons.Hands;
    public int Attack_speed = 1;
    public int Hit_rebound;

    private float hit_rebound = 1;

    //needed because InvokeRepeating can't pass parameters and the workaround sucks
    public GameObject Enemy = null;

    // Use this for initialization
    void Start()
    {
        hit_rebound = Hit_rebound / 10;
    }

    //// Update is called once per frame
    //void Update () {

    //}

    void OnCollisionEnter(Collision collision)
    {
        //get the movement script
        var collider_tag = collision.collider.tag;
        if(collider_tag != this.tag && collider_tag != "Terrain")
        {
            //enemies have collided
            //first stop them both
            //gameObject.GetComponent<movement>().enabled = false;
            gameObject.GetComponent<combatant_behaviour>().enabled = false;

            //now see if they make the first hit

            //enter attack loop based on their offense and the opponents defense
            Enemy = collision.collider.gameObject;
            InvokeRepeating("attack", (float)Attack_speed, (float)Attack_speed);
        }
    }

    void attack() //beware that enemy is a global out of necessity (see declaration)
    {
        //check to see if Enemy is already destroyed
        if(Enemy == null)
        {
            CancelInvoke();
            //gameObject.GetComponent<movement>().enabled = true;
            gameObject.GetComponent<combatant_behaviour>().enabled = true;
            return;
        }

        //knock the enemy back
        Enemy.transform.Translate(-Vector3.forward * hit_rebound);

        int roll = Random.Range(0, 100);

        if (roll < 50)
        {
            CancelInvoke();
            Destroy(Enemy);
            //start movement again
            gameObject.GetComponent<combatant_behaviour>().enabled = true;

        }
    }
}
