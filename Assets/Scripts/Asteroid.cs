using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab;

    OyunKontrol oyunKontrol; //Instance ASteroidYokOldu komutunu �a��rmak i�in

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rgb2D = GetComponent<Rigidbody2D>();//Objemize bir kuvvet ekleyebilmek i�in bunu yazmam laz�m

        oyunKontrol = Camera.main.GetComponent<OyunKontrol>(); //Bu objenin main kamerada ekli bile�eni temsil etti�ini s�yledim. 

        float asteroidYon = Random.Range(0f, 1.0f);
        if (asteroidYon < 0.5f)
        {
            rgb2D.AddForce(new Vector2(Random.Range(-2.5f, -1.0f), Random.Range(-2.5f, 1.0f)), ForceMode2D.Impulse);
            rgb2D.AddTorque(asteroidYon * 5.0f);
        }
        else
        {
            rgb2D.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rgb2D.AddTorque(-asteroidYon * 5.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Kursun")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().AsteroidPatlama(); //Sesi bulmas� i�in yolu veriyoruz
            oyunKontrol.AsteroidYokOldu(this.gameObject);
            AsteroidYokEt();
        }
    }

    public void AsteroidYokEt()
    {
        Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity); //asteroid konumunda patlama efekti olu�turma komutu
        //Debug.LogError("Yok edildi");
        Destroy(this.gameObject);
    }

}
