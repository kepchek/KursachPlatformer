using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _force = 14f;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse); //Подкидываем игрока при наступании на батут
        }
    }
}
