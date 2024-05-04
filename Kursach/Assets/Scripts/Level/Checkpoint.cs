using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private LevelMaster LM;
    void Start()
    {
        LM = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>(); //ищём объект LM
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            LM.lastCheckPointPos = transform.position; //Передаём коорды чекпоинта объекту LM
        }
    }
}
