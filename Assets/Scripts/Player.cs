using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float speed = 0.01f;
    float stoptimer = 0.0f;
    private float begspeed;
    private bool heel = false, poison = false;
    public long HP = 100;
    public Text text;
    float onetime = 0;
	// Use this for initialization
	void Start () {
        begspeed = speed;
	}
    
    // Update is called once per frame
    void FixedUpdate () {
        onetime += Time.deltaTime;
        if (onetime > 1)
        {
            onetime = 0;
            if (heel)
            {
                HP+=3;
            }
            if (poison)
            {
                HP-=5;
               
            }
            if (HP < 10)
            {
                text.color = Color.red;
            }
            else if (HP < 20)
            {
                text.color = Color.yellow;
            }
            else
            {
                text.color = Color.green;
            }
        }
        if (HP <= 0)
        {
            SceneManager.LoadScene("game over");
        }
        text.text = "HP:" + HP;
        if (stoptimer >= 0)
        {
            stoptimer -= Time.deltaTime;
            if (stoptimer <= 0)
            {
                speed = begspeed;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.U))
        {
            transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.R))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.L))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        transform.rotation = Quaternion.identity;
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        tikei map = col.GetComponent<tikei>();
        if (map != null)
        {
            int a = map.breaking();
            if (a == 1)
            {
                stoptimer = 0.5f;
                speed = 0;
            }
            if (a == 2)
            {
                heel = true;
            }
            if (a == 3)
            {
                poison = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        tikei map = col.GetComponent<tikei>();
        int a = map.type;
        if (a == 2)
        {
            heel = false;
        }
        if (a == 3)
        {
            poison = false;
        }
    }
}
