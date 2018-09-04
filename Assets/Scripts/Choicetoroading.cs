using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Choicetoroading : MonoBehaviour {
    public Text[] texts;
    public GameObject obj;
    public Save save;
    public Text back;
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
        for(int i = 0; i < (texts.Length+1);i++)
        {
            if (choice == i)
            {
                if (i == texts.Length)
                {
                    back.color = Color.green;
                }
                else
                {
                    texts[i].color = Color.green;
                }
            }
            else
            {
                if (i == texts.Length)
                { back.color = Color.yellow; }
                else
                { texts[i].color = Color.yellow; }
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
            if (choice != (texts.Length))
            {
                choice++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (choice < 10)//戻るボタンを押していないとき
            {
                if (nowactives[choice])
                {

                }
            }
            else
            {
                SceneManager.LoadScene("start");
            }
        }
    }
}
