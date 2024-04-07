using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiraliYokEdici : MonoBehaviour
{
    [SerializeField] //Edit�rden eri�ebilmek i�in attribute
    GameObject asteroidPrefab; //Asteroidleri olu�turuyoruz

    GameObject uzayGemisi; //uzay gemisinin konum bilgisi i�in

    List<GameObject> asteroidList; //Asteroidleri kaydetmek i�in List olu�turdum.

    GameObject hedefAsteroid; //her seferinde hedefte bir adet asteroid olacak ondan bunu ekledim

    // Start is called before the first frame update
    void Start()
    {
        uzayGemisi = GameObject.FindGameObjectWithTag("Player");
        asteroidList = new List<GameObject>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //Asteroidleri var etme i�lemi
        {
            Vector3 position = Input.mousePosition; //Mouse pozisyonunu alal�m.
            position.z = -Camera.main.transform.position.z;//z ekseninini kameraya g�re ayarlayay�m.
            position = Camera.main.ScreenToWorldPoint(position);//pozisyonu -> Oyun ekran�n�n koordinatlar�na �evirelim

            GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);//Oyun objemize Instantiate yapaca��m bu sefer de�i�keni alaca��m
            //Instantiate kullanarak, bir prefab��n kopyas�n� veya herhangi bir objeyi sahneye ekleyebilirim, oyunumu dinamik hale getiririm b�ylelikle
            asteroidList.Add(asteroid); //Listenin i�ine kaydedelim
        }

        if(Input.GetMouseButtonDown(1)) //Mouse sa� tu�uyla uzay gemisinie en yak�n asteridtten ba�layarak yok etme i�lemeni yapal�m
        {
            HedefiYokEt();
        }
    }

    GameObject EnYakinAsteroid()
    {
        GameObject EnYakinAsteroid;
        float enYakinMesafe;

        if(asteroidList.Count == 0)
        {
            return null;
        }
        else
        {
            EnYakinAsteroid = asteroidList[0];
            enYakinMesafe = MesafeOlcer(EnYakinAsteroid);
        }

        foreach(GameObject ast in asteroidList)
        {
            float mesafe = MesafeOlcer(ast);
            if(mesafe < enYakinMesafe)
            {
                enYakinMesafe = mesafe;
                EnYakinAsteroid = ast;
            }
        }

        return EnYakinAsteroid;
    }

    float MesafeOlcer(GameObject hedef)
    {
        return Vector3.Distance(uzayGemisi.transform.position, hedef.transform.position); 
    }

    public void HedefiYokEt() //metot olu�turdum -> bunu public yapt�m ��nk� ilk asterod yok olduktan sonra s�ral� yok etme i�leminin devam etmesi i�in bu metodu d��ardan �a��rmam laz�m
    {
        hedefAsteroid = EnYakinAsteroid();
        if(hedefAsteroid != null)
        {
            hedefAsteroid.GetComponent<YokEdici>().AsteroidYokEdici(1);
            asteroidList.Remove(hedefAsteroid);
        }
    }
}
