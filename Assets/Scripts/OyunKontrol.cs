using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject uzayGemisiPrefab; //Uzay Gemisi Prefab'�n� OyunKontrol scripti g�rmesini i�in GameObjesi ekliyorum
    GameObject uzayGemisi;

    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>(); //asteroidlerimizi ekliyoruz

    List<GameObject> asteroidList = new List<GameObject>(); //Ekranda ka� asterid oldu�unu bilmemiz laz�m prefab de�il ayr�ca gameobject olu�turmak laz�m bu komut sat�r� gibi 

    [SerializeField]
    int zorluk = 1;

    [SerializeField]
    int carpan = 5;

    UIKontrol uiKontrol;

    // Start is called before the first frame update
    void Start()
    {
        uiKontrol = GetComponent<UIKontrol>();
    }

    public void OyunuBaslat()
    {
        uiKontrol.OyunuBasladi(); //Bu OyunuBaslat metodu �a�r�l�nca sen de OyunuBasladi metodunu �a��r dedik.
        uzayGemisi = Instantiate(uzayGemisiPrefab); //Uzay Gemisi Prefab oyun ba�lad���nda olu�acak
        uzayGemisi.transform.position = new Vector3(0, EkranHesaplayicisi.Alt + 1.5f); //Uzay gemisinin Ba�lang�� pozisyonunu ayarlad�k
        AsteroidUret(5);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void AsteroidUret(int adet)
    {
        //her bir asteroidin konumu i�in gerekli
        Vector3 position = new Vector3();

        for (int i = 0; i < adet; i++)
        {
            position.z = -Camera.main.transform.position.z;
            //�imdi bu de�eri Oyun d�nyas� koordinatlar�na �evirelim
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(EkranHesaplayicisi.Sol, EkranHesaplayicisi.Sag);
            position.y = EkranHesaplayicisi.Ust - 1;

            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity); //Ekran asteroid �retimi i�in bunu yazmam�z laz�m ki prefab olu�sun
            asteroidList.Add(asteroid); //her daim yok olmam�� ka� asteroid oldu�unu bilmemiz laz�m ondan buraya ekledik.
        }
    }

    public void AsteroidYokOldu(GameObject asteroid) //herhangibir d�n�� t�r� olmad��� i�in void
    {
        uiKontrol.AsteroidYokOldu(asteroid); //UiKontrolden �a��rd�k metodu

        asteroidList.Remove(asteroid);
        //Debug.Log(asteroidList.Count);

        if(asteroidList.Count <= zorluk)
        {
            zorluk++;
            AsteroidUret(zorluk * carpan);
        }
    }

    public void OyunuBitir() //UzayGemisi Yok oldu�ununda �a�r�lacak
    {
        foreach (GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().AsteroidYokEt(); //T�m asteroidler yok olur
        }

        asteroidList.Clear(); //AsteroidList temizleniyor t�m asteroidler yok olduktan sonra
        zorluk = 1;

        uiKontrol.OyunBitti();
    }
}
