using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiraliYokEdici : MonoBehaviour
{
    [SerializeField] //Editörden eriþebilmek için attribute
    GameObject asteroidPrefab; //Asteroidleri oluþturuyoruz

    GameObject uzayGemisi; //uzay gemisinin konum bilgisi için

    List<GameObject> asteroidList; //Asteroidleri kaydetmek için List oluþturdum.

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
        if(Input.GetMouseButtonDown(0)) //Asteroidleri var etme iþlemi
        {
            Vector3 position = Input.mousePosition; //Mouse pozisyonunu alalým.
            position.z = -Camera.main.transform.position.z;//z ekseninini kameraya göre ayarlayayým.
            position = Camera.main.ScreenToWorldPoint(position);//pozisyonu -> Oyun ekranýnýn koordinatlarýna çevirelim

            GameObject asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);//Oyun objemize Instantiate yapacaðým bu sefer deðiþkeni alacaðým
            //Instantiate kullanarak, bir prefab’ýn kopyasýný veya herhangi bir objeyi sahneye ekleyebilirim, oyunumu dinamik hale getiririm böylelikle
            asteroidList.Add(asteroid); //Listenin içine kaydedelim
        }

        if(Input.GetMouseButtonDown(1)) //Mouse sað tuþuyla uzay gemisinie en yakýn asteridtten baþlayarak yok etme iþlemeni yapalým
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

    public void HedefiYokEt() //metot oluþturdum -> bunu public yaptým çünkü ilk asterod yok olduktan sonra sýralý yok etme iþleminin devam etmesi için bu metodu dýþardan çaðýrmam lazým
    {
        hedefAsteroid = EnYakinAsteroid();
        if(hedefAsteroid != null)
        {
            hedefAsteroid.GetComponent<YokEdici>().AsteroidYokEdici(1);
            asteroidList.Remove(hedefAsteroid);
        }
    }
}
