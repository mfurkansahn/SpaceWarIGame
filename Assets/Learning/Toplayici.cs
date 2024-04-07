using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour
{
    [SerializeField] //Editörden ayarlamak için 
    GameObject yildizPrefab;

    List<GameObject> yildizlar = new List<GameObject>(); //Yildizlar Listesi oluþturdum kaç tane oluþturacaðýmýzý bilmiyoruz sonuçta ondan array yapmadým


    /// <summary>
    /// Hedefteki yýldýzý söyler.
    /// </summary>
    public GameObject HedefYildiz
    {
        get
        {
            if(yildizlar.Count > 0) //Yýldýzlar Listemizde toplanacak yýldýz var ise oluyor
            {
                return yildizlar[0]; //uzay gemimiz yýldýzlarý bizim eklediðimiz sýraya göre yok edeceði için 0
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
            position.z = -Camera.main.transform.position.z; //Z eksenini kameraya göre ayarlýyoruz
            Vector3 oyunDunyasiPozisyon = Camera.main.ScreenToWorldPoint(position); //pixellere göre gelen bu pozisyonu oyun dðnyasýnýn deðerlerine çevirmek lazým
            yildizlar.Add(Instantiate(yildizPrefab, oyunDunyasiPozisyon, Quaternion.identity)); //artýk yýldýz instantiate olur olmaz yildizlar listesine eklenecek
        }
    }


    /// <summary>
    /// Parametre olarak gönderilen yýldýzý yok eder.
    /// </summary>
    /// <param name="yokEdilecekYildiz"></param>
    public void YildizYokEt(GameObject yokEdilecekYildiz) //parametre olarak gameobject - bu yokEdilecekYildiz!ý Listin içinden çýkarmam lazým 
    {
        yildizlar.Remove(yokEdilecekYildiz);
        Destroy(yokEdilecekYildiz);
    }
}
