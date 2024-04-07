using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour
{
    [SerializeField] //Edit�rden ayarlamak i�in 
    GameObject yildizPrefab;

    List<GameObject> yildizlar = new List<GameObject>(); //Yildizlar Listesi olu�turdum ka� tane olu�turaca��m�z� bilmiyoruz sonu�ta ondan array yapmad�m


    /// <summary>
    /// Hedefteki y�ld�z� s�yler.
    /// </summary>
    public GameObject HedefYildiz
    {
        get
        {
            if(yildizlar.Count > 0) //Y�ld�zlar Listemizde toplanacak y�ld�z var ise oluyor
            {
                return yildizlar[0]; //uzay gemimiz y�ld�zlar� bizim ekledi�imiz s�raya g�re yok edece�i i�in 0
            }
            else
            {
                return null;
            }
        }
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z; //Z eksenini kameraya g�re ayarl�yoruz
            Vector3 oyunDunyasiPozisyon = Camera.main.ScreenToWorldPoint(position); //pixellere g�re gelen bu pozisyonu oyun d�nyas�n�n de�erlerine �evirmek laz�m
            yildizlar.Add(Instantiate(yildizPrefab, oyunDunyasiPozisyon, Quaternion.identity)); //art�k y�ld�z instantiate olur olmaz yildizlar listesine eklenecek
        }
    }


    /// <summary>
    /// Parametre olarak g�nderilen y�ld�z� yok eder.
    /// </summary>
    /// <param name="yokEdilecekYildiz"></param>
    public void YildizYokEt(GameObject yokEdilecekYildiz) //parametre olarak gameobject - bu yokEdilecekYildiz!� Listin i�inden ��karmam laz�m 
    {
        yildizlar.Remove(yokEdilecekYildiz);
        Destroy(yokEdilecekYildiz);
    }
}
