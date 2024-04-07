using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject uzayGemisiPrefab; //Uzay Gemisi Prefab'ýný OyunKontrol scripti görmesini için GameObjesi ekliyorum
    GameObject uzayGemisi;

    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>(); //asteroidlerimizi ekliyoruz

    List<GameObject> asteroidList = new List<GameObject>(); //Ekranda kaç asterid olduðunu bilmemiz lazým prefab deðil ayrýca gameobject oluþturmak lazým bu komut satýrý gibi 

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
        uiKontrol.OyunuBasladi(); //Bu OyunuBaslat metodu çaðrýlýnca sen de OyunuBasladi metodunu çaðýr dedik.
        uzayGemisi = Instantiate(uzayGemisiPrefab); //Uzay Gemisi Prefab oyun baþladýðýnda oluþacak
        uzayGemisi.transform.position = new Vector3(0, EkranHesaplayicisi.Alt + 1.5f); //Uzay gemisinin Baþlangýç pozisyonunu ayarladýk
        AsteroidUret(5);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void AsteroidUret(int adet)
    {
        //her bir asteroidin konumu için gerekli
        Vector3 position = new Vector3();

        for (int i = 0; i < adet; i++)
        {
            position.z = -Camera.main.transform.position.z;
            //þimdi bu deðeri Oyun dünyasý koordinatlarýna çevirelim
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(EkranHesaplayicisi.Sol, EkranHesaplayicisi.Sag);
            position.y = EkranHesaplayicisi.Ust - 1;

            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity); //Ekran asteroid üretimi için bunu yazmamýz lazým ki prefab oluþsun
            asteroidList.Add(asteroid); //her daim yok olmamýþ kaç asteroid olduðunu bilmemiz lazým ondan buraya ekledik.
        }
    }

    public void AsteroidYokOldu(GameObject asteroid) //herhangibir dönüþ türü olmadýðý için void
    {
        uiKontrol.AsteroidYokOldu(asteroid); //UiKontrolden çaðýrdýk metodu

        asteroidList.Remove(asteroid);
        //Debug.Log(asteroidList.Count);

        if(asteroidList.Count <= zorluk)
        {
            zorluk++;
            AsteroidUret(zorluk * carpan);
        }
    }

    public void OyunuBitir() //UzayGemisi Yok olduðununda çaðrýlacak
    {
        foreach (GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().AsteroidYokEt(); //Tüm asteroidler yok olur
        }

        asteroidList.Clear(); //AsteroidList temizleniyor tüm asteroidler yok olduktan sonra
        zorluk = 1;

        uiKontrol.OyunBitti();
    }
}
