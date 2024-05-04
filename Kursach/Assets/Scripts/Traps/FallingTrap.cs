using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingTrap : MonoBehaviour
{
    private float destroyDelay = 3f; //Задержка перед удалением объекта
    [SerializeField] private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D other) //При триггере объекта, вызывается метод
    {
        if(other.gameObject.CompareTag("Player")) //Проверка игрового объекта, игрок ли это?
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Включение гравитации на ловушке
            Destroy(gameObject, destroyDelay); //Удаление ловушки через 3 секунды, после активации для оптимизации
        }
    }

}
