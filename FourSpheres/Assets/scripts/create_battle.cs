using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_battle : MonoBehaviour {

    public float File_spacing = .6f;
    public int Distance_from_scrimage = 5;

    public int White_Ranks;
    public int White_Files;
    public int Total_White;
    public GameObject White;
    //public static int White_Total = 0;

    public int Black_Ranks;
    public int Black_Files;
    public int Total_Black;
    public GameObject Black;
    //public static int Black_Total = 0;

    //private Dictionary<string, int> count;


    void Awake()
    {
        //count = new Dictionary<string, int>();
        HUD_manager.White_Total = White_Ranks * White_Files;
        HUD_manager.Black_Total = Black_Ranks * Black_Files;

        get_combatants(White, Distance_from_scrimage, White_Ranks, White_Files);
        get_combatants(Black, -Distance_from_scrimage, Black_Ranks, Black_Files);
    }
	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    private void get_combatants(GameObject combatant, float scrimage_position, int ranks, int files)
    {
        for (int j = 0; j < ranks; j++)
        {
            float random_rank_spacing = (j * File_spacing) - (Random.Range(0, (File_spacing / 2)));
            float rank_spacing = (float)j + random_rank_spacing;

            for (int i = 0; i < files; i++)
            {
                float random_file_spacing = (i * File_spacing) - (Random.Range(0, (File_spacing / 2)));

                float file_spacing = (float)i + random_file_spacing;
                GameObject newest_recruit = Instantiate(combatant, new Vector3(scrimage_position + rank_spacing, 1.235205f, file_spacing), Quaternion.identity);
                //Debug.Log(count);
                //increase_combatant_count(newest_recruit, count); //count is private global
            }
        }
       
    }

    public void Start_Battle()
    {
        HUD_manager.White_Total = White_Ranks * White_Files;
        HUD_manager.Black_Total = Black_Ranks * Black_Files;
        Debug.Log("get the guys");
        get_combatants(White, Distance_from_scrimage, White_Ranks, White_Files);
        get_combatants(Black, -Distance_from_scrimage, Black_Ranks, Black_Files);
    }
}
