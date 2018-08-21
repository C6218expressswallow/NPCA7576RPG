using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Choicetoroading : MonoBehaviour {
    public Text[] texts;
    public GameObject obj;
    public Save save;
    int choice = 0;
    public int[] hp = new int[10];
    public int[] level = new int[10];
    public bool[] nowactives = new bool[10];
    private void Start()
    {
        save = obj.GetComponent<Save>();
        for(int j = 0; j < 10; j++)
        {
            string s = save.Load(j);
            if(s=="save data had breaked!")
            {
                j = -1;
            }
            if(s== "save data is nothing")
            {
                nowactives[j] = false;
            }
            texts[j].text = s;
        }
    }
    private void Update()
    {
        for(int i = 0; i < texts.Length;i++)
        {
            if (choice == i)
            {
                texts[i].color = Color.green;
            }
            else
            {
                texts[i].color = Color.yellow;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (choice != 0)
            {
                choice--;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (choice != (texts.Length - 1))
            {
                choice++;
            }
        }
    }
}
