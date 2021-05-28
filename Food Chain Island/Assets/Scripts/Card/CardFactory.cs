using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;

public class CardFactory : MonoBehaviour
{
    public GameObject BaseCard;
    
    public List<GameObject> CardList = new List<GameObject>();
    
    public static CardFactory inst;
    private void Awake() { inst = this; }
    public void createCards()
    {
        List<string> AnimalNames = new List<string>() {
            "Plant", "Ant", "Spider", "Mouse", "Lizard", "Rat", "Bat","Snake", "Racoon", "Fox", "Lynx", "Wolf", "Tiger", "Gator", "Lion", "Polar Bear" 
        };
        for (int i = 0; i < AnimalNames.Count; i++)
        {
            GameObject card = Instantiate(BaseCard, new Vector3(i, 0, i), Quaternion.Euler(90, 0, 0));
            card.GetComponent<Card>().Prime(i, AnimalNames[i],Resources.Load<Sprite>(AnimalNames[i].ToString()),AbilityExpert .inst.abilities[i]);
            card.GetComponentInChildren<SpriteRenderer>().sprite = card.GetComponent<Card>().frontPicture;
            card.transform.parent = GameManager.inst.CardsGameObject.transform;
            CardList.Add(card);
        }
    }
    
    
    
    public void CardsToFields() {
        int cardcount = 0;
        int x = 0;
        int y = 0;
        List<GameObject> rndList = CardList;
        
        Utilities.Shuffle(rndList);
        for(x = 1; x <= 5; x++) {
            if(cardcount >=  CardList.Count) {
                break;
            }else {
                for (y = 1; y < 5; y++)
                {
                    rndList[cardcount].GetComponent<Card>().Move(Utilities.map[x, y]);
                    cardcount++;
                }
            }
        }
    }
    public void IntiateWaterCards()
    {
        GameObject whaleTile = Instantiate(FieldFactory.inst.FieldPref,new Vector3(6.5f,0,0),Quaternion.Euler(90,90,0)) as GameObject;
        whaleTile.transform.parent = GameManager.inst.FieldsGameObject.transform;
        
        GameObject sharkTile = Instantiate(FieldFactory.inst.FieldPref,new Vector3(7.5f,0,0),Quaternion.Euler(90,90,0)) as GameObject;
        sharkTile.transform.parent = GameManager.inst.FieldsGameObject.transform;


        GameObject WhaleCard = Instantiate(BaseCard, new Vector3(6.5f,0,0f),Quaternion.Euler(90,0,0));
        WhaleCard.GetComponent<Card>().Prime(0, "Whale",Resources.Load<Sprite>("Whale"), null);
        WhaleCard.GetComponentInChildren<SpriteRenderer>().sprite = WhaleCard.GetComponent<Card>().frontPicture;
        WhaleCard.GetComponent<Card>().Ability = AbilityExpert.inst.WhaleAbility;
        WhaleCard.transform.parent = GameManager.inst.CardsGameObject.transform;
        WhaleCard.GetComponent<Card>().Move(whaleTile.GetComponent<Field>());
        

        GameObject SharkCard = Instantiate(BaseCard, new Vector3(7.5f,0,0),Quaternion.Euler(90,0,0));
        SharkCard.GetComponent<Card>().Prime(0, "Shark",Resources.Load<Sprite>("Shark"), null);
        SharkCard.GetComponentInChildren<SpriteRenderer>().sprite = SharkCard.GetComponent<Card>().frontPicture;
        SharkCard.GetComponent<Card>().Ability = AbilityExpert.inst.SharkAbility;
        SharkCard.GetComponent<Card>().Move(sharkTile.GetComponent<Field>());


        SharkCard.transform.parent = GameManager.inst.CardsGameObject.transform;

    }
   

}
