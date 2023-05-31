using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBoxLeft;
    [SerializeField] private TextMeshProUGUI textBoxRight;

    private int scoreLeft = 0;
    private int scoreRight = 0;

   public void AddScoreLeft()
   {
        scoreLeft++;
        textBoxLeft.text = scoreLeft.ToString("D2");
   }
   
   public void AddScoreRight() 
   {
        scoreRight++;
        textBoxLeft.text = scoreLeft.ToString("D2");
   }
}
