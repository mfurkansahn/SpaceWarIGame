using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Obje olu�turaca��z
        UzayGemisi gemi1 = new UzayGemisi(Random.Range(80,100));
        UzayGemisi gemi2 = new UzayGemisi(Random.Range(80, 100), "K�rm�z�");


        ////Objelere Metodu �a��rd�m
        gemi1.Hizlandirici();
        gemi2.Hizlandirici();

        gemi1.Yavaslatici();
        gemi2.Yavaslatici();


        //H�zl� giden kazans�n
        if(gemi1.MaksimumHiz > gemi2.MaksimumHiz)
        {
            Debug.Log("Gemi-1 h�zl� ��kt��");
        }

        else if(gemi2.MaksimumHiz > gemi1.MaksimumHiz)
        {
            Debug.Log("Gemi-2 fi�ek gibi");
        }
        else
        {
            Debug.Log("�ki geminin de h�z� e�it");
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

        //    Debug.Log("Sald�r� Alt�nday�z. D��man Say�s�: " + saldiranDusman);
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

        //    Debug.Log("Sald�r� Alt�nday�z. D��man Say�s�: " + saldiranDusman);
        //} while (saldiriDevam);



        //int yokEdilenAsteroidSay�s� = 5;
        //int OyuncuHp = 100;

        //if(yokEdilenAsteroidSay�s� == 5 && OyuncuHp <= 100)
        //{
        //    Debug.Log("Ba�lang�� i�in iyi");
        //}

        //if(yokEdilenAsteroidSay�s� > 20 && yokEdilenAsteroidSay�s� <= 30)
        //{
        //    Debug.Log("Tebrikler 1. oldunuz;");
        //}
        //else if(yokEdilenAsteroidSay�s� > 30 && yokEdilenAsteroidSay�s� <= 99)
        //{
        //    Debug.Log("2. oldunuz.");
        //}
        //else if(yokEdilenAsteroidSay�s� > 100 && yokEdilenAsteroidSay�s� != 150)
        //{
        //    Debug.Log("3. oldunuz.");
        //}
        //else
        //{
        //    Debug.Log("Maalesef kaybettiniz :(");
        //}

        //switch(yokEdilenAsteroidSay�s�)
        //{
        //    case 21:Debug.Log("G�zel ba�lang��");
        //        break;
        //    case 31:
        //        Debug.Log("�yi gidiyorsun");
        //        break;
        //    case 101:Debug.Log("Muhte�em");
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
