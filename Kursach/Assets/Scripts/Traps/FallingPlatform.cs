using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 0.5f; //Задержка перед падением
    private float destroyDelay = 2f; //Задержка перед удалением

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall()); //Если игрок наступил на платформу, запускаем корутин
        }
    }

    private IEnumerator Fall() //Интерфейс, дающий отстчёт перед падением платформы и удаляющий её
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
