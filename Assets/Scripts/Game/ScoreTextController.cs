using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour {
   public int initialScore = 0;
   public int initialLife = 3;
   public int currScore;
   public int currLife;
   public Text text_;
   public Text game_over_text;

   public MaceSpawner maceSpawner;
   
   void Start() {
       text_ = this.GetComponent<Text>();
       currScore = initialScore;
       currLife = initialLife;
       text_.text = $"SCORE: {currScore.ToString()} \r\n LIFE: {currLife.ToString()}";
   }

   public void AddScoreAndDisplay() {
       currScore += 100;
       if(currScore>1000){
            maceSpawner.changeFrequency(2.5f);
       }
       text_.text = $"SCORE: {currScore.ToString()} \r\n LIFE: {currLife.ToString()}";
   }

   public void MinusScoreAndDisplay() {
       currLife -= 1;
       if(currLife<=0){
        text_.text =  $"GAME OVER😢";
        game_over_text.text = $"GAME OVER \r\n (restart in 5 seconds)";
        StartCoroutine(Timeout());
        return;
       }
       text_.text =  $"SCORE: {currScore.ToString()} \r\n LIFE: {currLife.ToString()}";
   }

    public void handleDropRiver(){
        currLife = 0;
        text_.text =  $"GAME OVER";
        game_over_text.text = $"I CANT SWIM QQ\r\n(restart in 5 seconds)";
        StartCoroutine(Timeout());
        return;
    }

IEnumerator Timeout()
    {
    yield return new WaitForSeconds(5);
    Restart();
    }

   public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        game_over_text.text = $"";
        currScore = initialScore;
        currLife = initialLife;
   }


}

