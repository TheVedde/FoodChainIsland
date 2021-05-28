using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image firstImage = null;
    public Image secondImage = null;
    public TMP_Text abilityText = null;
    public GameObject KillPanel = null;
    public TMP_Text HelpPanelText = null;
    public GameObject HelpPanel = null;
    public GameObject EndState = null;
    public TMP_Text ScoText = null;
    public TMP_Text FinishedMessage = null;
    
    public static GUIManager inst;
    
    private void Awake() {
        if (inst == null) {
            inst = this;
        }else {
            Destroy(gameObject);
        }
        KillPanel.SetActive(false);
    }
   /* private void OnGUI() {
        if (GUI.Button(new Rect(50,50,200,200),StateManager.currentState.StateName )) {
            Debug.Log("Never gonna give you up");
        }
    }*/ 

    public void DisplayAbilityText(string text) {
        HelpPanel.SetActive(true);
        abilityText.text +=  text;
        abilityText.enabled = true;
    }
    public void RemoveAbilityText() {
        HelpPanel.SetActive(false);
        abilityText.text = "Active Ability: ";
    }
    public void DisplayFirstImage(Card card) {
        firstImage.sprite = card.frontPicture;
        firstImage.color = new Color(255, 255, 255, 1);
        
    }
    
    public void DisplaySecondImage(Card card) {
        secondImage.sprite = card.frontPicture;
        secondImage.color = new Color(255, 255, 255, 1);
    }

    public void RemoveImage(string ImagePos) {
        if (ImagePos == "FirstImage") {
            firstImage.sprite = null;
            firstImage.color = new Color(255, 255, 255, 0);
        }else if( ImagePos == "SecondImage") {
            secondImage.sprite = null;
            secondImage.color = new Color(255, 255, 255, 0);
        }
    }

    public void ShowScore()
    {
        EndState.SetActive(true);
    }
   
}
