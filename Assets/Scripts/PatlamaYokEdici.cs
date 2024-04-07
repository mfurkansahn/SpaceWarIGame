using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaYokEdici : MonoBehaviour
{

    GeriSayimSayaci geriSayimSayaci;

    //SiraliYokEdici _siraliYokEdici; //Sýradaki asteroidin yok edilmesi için patlamanýn bittiðini bilmemiz gerekiyor

    // Start is called before the first frame update
    void Start()
    {
        geriSayimSayaci = gameObject.AddComponent<GeriSayimSayaci>();
        //_siraliYokEdici = Camera.main.GetComponent<SiraliYokEdici>(); //Bu bileþeni main kameradan almasý gerektiðini söyleyeceðiz
        geriSayimSayaci.ToplamSure = 1;
        geriSayimSayaci.Calistir();
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayimSayaci.Bitti)
        {
            //_siraliYokEdici.HedefiYokEt();
            Destroy(gameObject);
        }
    }
}
