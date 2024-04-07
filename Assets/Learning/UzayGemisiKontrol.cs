using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKontrol : MonoBehaviour
{
    const float hareketGucu = 6;

    //e�er uzay gemimiz toplama i�lemine ba�lad�ysa hedefteki y�ld�z de�i�meden yeni bi y�ld�za gitmemeli (bunu kontrol edebilmek i�in boolean de�i�ken olu�tural�m)
    bool topluyor = false; //t�klasak bile tekrardan hedeften ��kmamas� i�in
    GameObject hedef; //birde hedefi ayaralayabilmek i�in gameObjesi olmas� laz�m

    //fizik kurallar�n�n �al��mas�n� sa�layan bile�ene ihtiyac�m�z var onu ekleyelim
    Rigidbody2D myRigidBody2D;

    Toplayici toplayici; //Toplay�c� bile�enine (script'ine) ihtiyac�m�z olacak

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
        if(collision.gameObject == hedef) //bu gameobject hedefimizdeki y�ld�z m� diye soruyoruz
        {
            toplayici.YildizYokEt(hedef);
            myRigidBody2D.velocity = Vector2.zero; //x ve y s�f�rl�yoruz
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
            gidilecekYer.Normalize();//bu iki noktay� birle�tirmek i�in yazd�m,
            myRigidBody2D.AddForce(gidilecekYer * hareketGucu , ForceMode2D.Impulse); //toplay�c� haz�r
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

        //if (dikeyInput != 0) //de�i�tiriyorsa -1 , 0(sabit) , 1 
        //{
        //    position.y += dikeyInput * hareketGucu * Time.deltaTime;
        //}

        //transform.position = position;

    }
}
