 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class MaceSpawner : MonoBehaviour
 {
     public GameObject rockPrefab;
     public float initialY = 13;
     public float spawnFrequency = 4f;
     // Start is called before the first frame update
     void Start()
     {
         StartCoroutine(SpawnRocks());
     }

     public void changeFrequency(float newFrequency){
         spawnFrequency = newFrequency;
     }
 
     IEnumerator SpawnRocks()
     {
         while(true)
         {
             float randomTime = Random.Range(2f,spawnFrequency);
             float randomPosition = Random.Range(-10f,10f);
             
             yield return new WaitForSeconds(randomTime);
             Instantiate(rockPrefab,new Vector2(randomPosition,initialY),Quaternion.identity);
         }
     }
 }