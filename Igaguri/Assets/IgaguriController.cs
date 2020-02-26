using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgaguriController : MonoBehaviour
{

    public void shoot ( Vector3 dir )
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }


    void OnCollisionEnter( Collision other )
    {
        GetComponent<Rigidbody>().isKinematic = true; // 動き止める
        GetComponent<ParticleSystem>().Play();
        Vector2 IgaguriV = this.transform.position;
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().Coment(IgaguriV);

    }

    
    void Start()
    {
    
    }
  
}
