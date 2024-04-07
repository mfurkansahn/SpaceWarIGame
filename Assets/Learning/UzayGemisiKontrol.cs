using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKontrol : MonoBehaviour
{
    const float hareketGucu = 6;

    //eðer uzay gemimiz toplama iþlemine baþladýysa hedefteki yýldýz deðiþmeden yeni bi yýldýza gitmemeli (bunu kontrol edebilmek için boolean deðiþken oluþturalým)
    bool topluyor = false; //týklasak bile tekrardan hedeften çýkmamasý için
    GameObject hedef; //birde hedefi ayaralayabilmek için gameObjesi olmasý lazým

    //fizik kurallarýnýn çalýþmasýný saðlayan bileþene ihtiyacýmýz var onu ekleyelim
    Rigidbody2D myRigidBody2D;

    Toplayici toplayici; //Toplayýcý bileþenine (script'ine) ihtiyacýmýz olacak

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        toplayici = Camera.main.GetComponent<Toplayici>();
    }


    private void OnMouseDown()
    {
        if(!topluyor)
        {
            GitVeTopla();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == hedef) //bu gameobject hedefimizdeki yýldýz mý diye soruyoruz
        {
            toplayici.YildizYokEt(hedef);
            myRigidBody2D.velocity = Vector2.zero; //x ve y sýfýrlýyoruz
            GitVeTopla();
        }
    }

    void GitVeTopla()
    {
        hedef = toplayici.HedefYildiz;
        if(hedef != null)
        {
            Vector2 gidilecekYer = new Vector2(hedef.transform.position.x
                - transform.position.x, hedef.transform.position.y - transform.position.y);
            gidilecekYer.Normalize();//bu iki noktayý birleþtirmek için yazdým,
            myRigidBody2D.AddForce(gidilecekYer * hareketGucu , ForceMode2D.Impulse); //toplayýcý hazýr
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Vector3 position = transform.position;  //gemimizin positionu kaydedelim bir yere

        //float yatayInput = Input.GetAxis("Horizontal");
        //float dikeyInput = Input.GetAxis("Vertical");

        //if (yatayInput != 0)
        //{
        //    position.x += yatayInput * hareketGucu * Time.deltaTime;
        //}

        //if (dikeyInput != 0) //deðiþtiriyorsa -1 , 0(sabit) , 1 
        //{
        //    position.y += dikeyInput * hareketGucu * Time.deltaTime;
        //}

        //transform.position = position;

    }
}
