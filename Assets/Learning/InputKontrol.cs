using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefab;

    //GameObject[] asteroids = new GameObject[5]; Array
    List<GameObject> asteroidList = new List<GameObject>(); //List => kolaylýðý tanýmlarken kaç tane obje olacaðýný belirtmemize gerek yok 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log(Input.mousePosition);

            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);

            for (int i = 0; i < 20; i++)
            {
                asteroidList.Add(Instantiate(asteroidPrefab, position, Quaternion.identity));
            }


            //Array
            //asteroids[0] = Instantiate(asteroidPrefab, position, Quaternion.identity);
            //asteroids[1] = Instantiate(asteroidPrefab, position, Quaternion.identity);
            //asteroids[2] = Instantiate(asteroidPrefab, position, Quaternion.identity);
            //asteroids[3] = Instantiate(asteroidPrefab, position, Quaternion.identity);
            //asteroids[4] = Instantiate(asteroidPrefab, position, Quaternion.identity);
        }

        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("Pressed left click.");
        //}

        if (Input.GetMouseButtonDown(1)) //her týklamada bir kere çaðrýlsýn
        {
            //for (int i = 0; i < asteroids.Length; i++)
            //{
            //    Destroy(asteroids[i]); Array için
            //}

            //for (int i = 0; i < asteroidList.Count; i++)
            //{
            //    Destroy(asteroidList[i]); //Array için
            //}

            Debug.Log(asteroidList.Count);

            foreach(GameObject ast in asteroidList)
            {
                Destroy(ast);
            }

            asteroidList.Clear(); //sildikten sonra her týklayýþta baþtan sayýyor asteroidleri
        }

        //if (Input.GetMouseButton(2))
        //{
        //    for (int i = 0; i < asteroids.Length; i++)
        //    {
        //        Destroy(this.asteroids[i]);
        //    } 
        //}
    }
}
