 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class CoinSpawner : MonoBehaviour
 {
     public GameObject coinPrefab;
     public float initialY = 13;
     // Start is called before the first frame update
     void Start()
     {
         StartCoroutine(SpawnCoins());
     }
 
     IEnumerator SpawnCoins()
     {
         while(true)
         {
             float randomTime = Random.Range(2f,5f);
             float randomPosition = Random.Range(-10f,10f);
             
             yield return new WaitForSeconds(randomTime);
             Instantiate(coinPrefab,new Vector2(randomPosition,initialY),Quaternion.identity);
         }
     }

    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.Log("collide trigger!");
    //     if(other.tag=="FLOOR" || other.tag=="RIVER" ){
    //         Destroy(this.gameObject);
    //     }
    // }
     
 }