using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);//При касании объекта/финиша, активируем меню
        }    
    }

    public void ExitButton()
    {
        Application.Quit();//При нажатии кнопки закрываем игру
    }
}
