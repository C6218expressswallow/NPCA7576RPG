using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choicetoroading : MonoBehaviour {
    public Text[] texts;
    int choice = 0;
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
