using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private LevelMaster LM;
    void Start()
    {
        LM = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelMaster>(); 
        transform.position = LM.lastCheckPointPos; //При старте уровня, перемещаем персонажа на коорды последнего чекпоинта
    }
}
