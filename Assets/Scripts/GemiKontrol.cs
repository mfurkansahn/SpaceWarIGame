using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemiKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject kursunPrefab;

    [SerializeField]
    GameObject patlamaPrefab;

    const float uzayGemisiHareketGucu = 5;

    OyunKontrol oyunKontrol;

    // Start is called before the first frame update
    void Start()
    {
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;  //Gemimizin pozisyonunu kaydedelim 

        float yatayInput = Input.GetAxis("Horizontal");
        float dikeyInput = Input.GetAxis("Vertical");

        if (yatayInput != 0)
        {
            position.x += yatayInput * uzayGemisiHareketGucu * Time.deltaTime;
        }

        if (dikeyInput != 0) //de�i�tiriyorsa -1 , 0(sabit) , 1 
        {
            position.y += dikeyInput * uzayGemisiHareketGucu * Time.deltaTime;
        }

        transform.position = position;

        if (Input.GetButtonDown("Jump"))
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().Ates(); //Sesi bulmas� i�in yolu veriyoruz
            Vector3 kursunPozisyon = gameObject.transform.position; //kur�unun ald���m�z pozisyonu 
            kursunPozisyon.y += 1;
            Instantiate(kursunPrefab, kursunPozisyon, Quaternion.identity); //kur�un �o�al�m� (olu�turumu9

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().GemiPatlama(); //Sesi bulmas� i�in yolu veriyoruz
            oyunKontrol.OyunuBitir();
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
