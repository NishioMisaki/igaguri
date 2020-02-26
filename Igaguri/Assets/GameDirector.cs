using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    GameObject coment;
    GameObject point;
    GameObject result;
    GameObject target;
    GameObject[] life = new GameObject[5];
   
    int Point = 0;
    int count = 0; // イガグリを投げた回数
    
    void Start()
    {
        this.coment = GameObject.Find("coment");
        this.target = GameObject.Find("target");
        this.point = GameObject.Find("point");
        this.result = GameObject.Find("result");
         
        for ( int i = 0; i<= 4; i++)
        {
            life[i] = GameObject.Find("igaguri-" + i);
        }

     
    }

    public void Coment ( Vector2 Igaguri )
    {
        Vector2 igaguri = Igaguri;
        Vector2 target;
        target.x = this.target.transform.position.x;
        target.y = this.target.transform.position.y + 6.5f;
        Vector2 dir = igaguri - target;
        float d = dir.magnitude;
        float r1 = 1.4f/2; //指標1
        float r2 = 2.3f/2; //指標2
        float r3 = 3.8f/2; //指標3

        if (0 <= d && d <= r1)
        {
            this.coment.GetComponent<Text>().text = "Excerent";
            this.Point += 3;
        }
        else if (r1 <= d && d <= r2)
        {
            this.coment.GetComponent<Text>().text = "Great";
            this.Point += 2;

        }
        else if (r2 <= d && d <= r3)
        {
            this.coment.GetComponent<Text>().text = "nice";
            this.Point += 1;
        }
        else
            this.Point += 0;

        this.point.GetComponent<Text>().text = this.Point.ToString("F0") + "point / 15 point";
        
        switch ( this.count ) {
            case 0: 
                Destroy(life[0]);
                break;
            case 1:
                Destroy(life[1]);
                break;
            case 2:
                Destroy(life[2]);
                break;
            case 3:
                Destroy(life[3]);
                break;
            case 4:
                { 
                    Destroy(life[4]);
                    this.point.GetComponent<Text>().text = " ";
                    this.result.GetComponent<Text>().text = this.Point.ToString("F0") + "point / 15 point";
                    SceneManager.LoadScene("StartScene");
                    break;
                }
            default:
                break;
        }
        this.count++;



    }
   
    }



