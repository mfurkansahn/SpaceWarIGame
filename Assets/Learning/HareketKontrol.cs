using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketKontrol : MonoBehaviour
{
    float colliderBoyYarim;
    float colliderEnYarim;

    // Start is called before the first frame update
    void Start()
    {
        //Uzay Gemisini hareket ettir
        //Uzay Gemisini RigidBody2d ile hareket ettir
        //Rigidbody2D myrigidbody2D = GetComponent<Rigidbody2D>();
        //myrigidbody2D.AddForce(new Vector2(3, 5), ForceMode2D.Impulse);  

        //Oyun objesini kuvvet uygula
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5,5), Random.Range(-5,5)), ForceMode2D.Impulse);
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        colliderBoyYarim = collider.size.y / 2;
        colliderEnYarim = collider.size.x / 2;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Kemerlerinizi ba�lay�n, hasar al�yoruz!");
    }


    // Update is called once per frame
    void Update()
    {
        //Asteroid mouse imlecini takip etsin
        //Vector3 position = Input.mousePosition;
        //position.z = -Camera.main.transform.position.z;
        //position = Camera.main.ScreenToWorldPoint(position);
        //transform.position = position;
        //EkrandaKal();
    }

    //Objenin oyun ekran�nda kalmas�na sa�la
    void EkrandaKal()
    {
        Vector3 position = transform.position;
        if (position.x - colliderEnYarim < EkranHesaplayicisi.Sol)
        {
            position.x = EkranHesaplayicisi.Sol + colliderEnYarim;
        }
        else if (position.x + colliderEnYarim > EkranHesaplayicisi.Sag)
        {
            position.x = EkranHesaplayicisi.Sag - colliderEnYarim;
        }
        if (position.y + colliderBoyYarim > EkranHesaplayicisi.Ust)
        {
            position.y = EkranHesaplayicisi.Ust - colliderBoyYarim;
        }
        else if (position.y - colliderBoyYarim < EkranHesaplayicisi.Alt)
        {
            position.y = EkranHesaplayicisi.Alt + colliderBoyYarim;
        }


        transform.position = position;
    }
}