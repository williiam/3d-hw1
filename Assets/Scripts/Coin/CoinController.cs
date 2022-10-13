 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class CoinController : MonoBehaviour
 {
    public float moveSpeed = 0.05f;
    public float timeout = 4f;
    public Rigidbody2D rb;

     // Start is called before the first frame update
     void Start()
     {
        this.rb = this.GetComponent<Rigidbody2D>();
     }
 
     // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
     void FixedUpdate()
     {
         transform.Translate(0,-moveSpeed,0);
     }
     
     IEnumerator Timeout()
     {
        yield return new WaitForSeconds(timeout);
        if(!this.gameObject==null)
        {
            Destroy(this.gameObject);
        }
     }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collide trigger!");
        if(other.tag=="FLOOR" || other.tag=="RIVER" ){
            StartCoroutine(Timeout());
        }
    }
 }