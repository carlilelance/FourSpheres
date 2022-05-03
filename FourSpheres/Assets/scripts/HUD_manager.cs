using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_manager : MonoBehaviour {

    public static int White_Total = 0;
    public static int Black_Total = 0;
    public Text White_Total_Text;
    public Text Black_Total_Text;
    public create_battle Create_Battle_Script;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(White_Total > 0)
        {
            White_Total_Text.text = "White Count: " + White_Total.ToString();
        } else
        {
            White_Total_Text.text = "White Count: 0"; 
        }
        if(Black_Total > 0)
        {
        Black_Total_Text.text = "Black Count:" + Black_Total.ToString();
        } else
        {
            Black_Total_Text.text = "Black Count: 0";
        }
	}

    //public void Set_White_Ranks(int white_ranks)
    //{
    //    create_battle.White_Ranks = white_ranks;
    //}

    public void Restart_Battle() {
        //remove all white combatants
        GameObject[] white_combatants = GameObject.FindGameObjectsWithTag("White");
        foreach (var white_combatant in white_combatants)
        {
            Destroy(white_combatant);
        }
        //remove all black combatants
        GameObject[] black_combatants = GameObject.FindGameObjectsWithTag("Black");
        foreach (var black_combatant in black_combatants)
        {
            Destroy(black_combatant);
        }
        //run the create_battle script
        Create_Battle_Script.Start_Battle();
    }
}
