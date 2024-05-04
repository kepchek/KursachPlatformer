using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    private static LevelMaster instance; //Создаём экземпляр класса
    public Vector2 lastCheckPointPos; //Переменная хранящая коорды последнего чекппоинта
    void Awake()
    {
        if(instance == null) //Если экземпляра нет, создаём его
        {
            instance = this;
            DontDestroyOnLoad(instance); //Экземпляр не удаляется при рестарте сцены
        }
        else
        {
            Destroy(gameObject); //Если экземпляр есть, то удаляем текущий игровой объект
                                 //Для избежания дублирования
        }
    }
}
