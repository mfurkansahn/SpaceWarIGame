using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI kütüphanesi kullanmak için eklemem lazým

public class UIKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject oyunAdiText;

    [SerializeField]
    GameObject oyunBittiText;

    [SerializeField]
    Text oyunPuanText;

    [SerializeField]
    GameObject oynaButon;

    [SerializeField]
    Text oyunuGelistiren;

    int puan;

    // Start is called before the first frame update
    void Start()
    {
        ////Char
        //char cevap = 'E';
        //Debug.Log(cevap);

        ////String
        //string yanit = "Evet";
        //Debug.Log(yanit[0]);

        oyunBittiText.gameObject.SetActive(false); //Oyun baþýnda bunu gösterme dedik
        oyunuGelistiren.gameObject.SetActive(true);
        oyunPuanText.gameObject.SetActive(false);

    }

    public void OyunuBasladi()
    {
        puan = 0;
        oyunAdiText.gameObject.SetActive(false);
        oynaButon.gameObject.SetActive(false);
        oyunPuanText.gameObject.SetActive(true);
        oyunBittiText.gameObject.SetActive(false);
        oyunuGelistiren.gameObject.SetActive(false);
        PuaniGuncelle();
    }

    public void OyunBitti()
    {
        oyunBittiText.gameObject.SetActive(true);
        oynaButon.gameObject.SetActive(true);
    }

    void PuaniGuncelle()
    {
        oyunPuanText.text = "PUAN:" + puan;
    }

    public void AsteroidYokOldu(GameObject asteroid)
    {
        switch (asteroid.gameObject.name[8])
        {
            case '1':
                puan += 15;
                PuaniGuncelle();
                break;

            case '2':
                puan += 10;
                PuaniGuncelle();
                break;

            case '3':
                puan += 5;
                PuaniGuncelle();
                break;

            default:
                break;
        }
        //Debug.Log(asteroid.gameObject.name);
        //puan += 10;
        //PuaniGuncelle();
    }
}
