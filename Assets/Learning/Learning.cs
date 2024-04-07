using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Obje oluþturacaðýz
        UzayGemisi gemi1 = new UzayGemisi(Random.Range(80,100));
        UzayGemisi gemi2 = new UzayGemisi(Random.Range(80, 100), "Kýrmýzý");


        ////Objelere Metodu Çaðýrdým
        gemi1.Hizlandirici();
        gemi2.Hizlandirici();

        gemi1.Yavaslatici();
        gemi2.Yavaslatici();


        //Hýzlý giden kazansýn
        if(gemi1.MaksimumHiz > gemi2.MaksimumHiz)
        {
            Debug.Log("Gemi-1 hýzlý çýktýý");
        }

        else if(gemi2.MaksimumHiz > gemi1.MaksimumHiz)
        {
            Debug.Log("Gemi-2 fiþek gibi");
        }
        else
        {
            Debug.Log("Ýki geminin de hýzý eþit");
        }

        ////while
        //int saldiranDusman = 10;
        //bool saldiriDevam = true;

        //while (saldiriDevam)
        //{
        //    saldiranDusman--;

        //    if (saldiranDusman < 3)
        //    {
        //        saldiriDevam = false;
        //    }

        //    Debug.Log("Saldýrý Altýndayýz. Düþman Sayýsý: " + saldiranDusman);
        //}


        ////do  while
        //int saldiranDusman = 10;
        //bool saldiriDevam = false;

        //do
        //{
        //    saldiranDusman--;

        //    if (saldiranDusman < 3)
        //    {
        //        saldiriDevam = false;
        //    }

        //    Debug.Log("Saldýrý Altýndayýz. Düþman Sayýsý: " + saldiranDusman);
        //} while (saldiriDevam);



        //int yokEdilenAsteroidSayýsý = 5;
        //int OyuncuHp = 100;

        //if(yokEdilenAsteroidSayýsý == 5 && OyuncuHp <= 100)
        //{
        //    Debug.Log("Baþlangýç için iyi");
        //}

        //if(yokEdilenAsteroidSayýsý > 20 && yokEdilenAsteroidSayýsý <= 30)
        //{
        //    Debug.Log("Tebrikler 1. oldunuz;");
        //}
        //else if(yokEdilenAsteroidSayýsý > 30 && yokEdilenAsteroidSayýsý <= 99)
        //{
        //    Debug.Log("2. oldunuz.");
        //}
        //else if(yokEdilenAsteroidSayýsý > 100 && yokEdilenAsteroidSayýsý != 150)
        //{
        //    Debug.Log("3. oldunuz.");
        //}
        //else
        //{
        //    Debug.Log("Maalesef kaybettiniz :(");
        //}

        //switch(yokEdilenAsteroidSayýsý)
        //{
        //    case 21:Debug.Log("Güzel baþlangýç");
        //        break;
        //    case 31:
        //        Debug.Log("Ýyi gidiyorsun");
        //        break;
        //    case 101:Debug.Log("Muhteþem");
        //        break;
        //    default:Debug.Log("Kaybettin");
        //        break;
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
