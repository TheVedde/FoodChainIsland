using System;
using System.Collections;
 using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.Serialization;
 
 public delegate void MyAbilityDescription();
 
 public class Card : MonoBehaviour
 {
     public GameObject faceObject;
     public int number;
     public string name;
     public Sprite frontPicture;
     public MyAbilityDescription Ability;
     public Vector2Int pos;
     public Field MyField = null;
     public int Eaten = 0;


     public void Move(Field field)
     {
         field.Occupant = this;
         //
         MyField = field;
         transform.position = MyField.transform.position;
         pos = MyField.position;
     }
     public void MoveAnim(Field field)
     {
         field.Occupant = this;
         MyField = field;
         transform.DOJump(field.transform.position, 1f,1,1f,false).SetEase(Ease.OutQuint);
         pos = MyField.position;
     }
     private void OnMouseDown()
     {
        StateManager.currentState.OnMouseDown(this);
     }

     private void OnMouseEnter()
     {
         
         StateManager.currentState.OnMouseEnter(this);
     }

     private void OnMouseExit()
     {
      
         StateManager.currentState.OnMouseExit(this);
     }

     public Card Prime(int _number, string _name, Sprite front, MyAbilityDescription ability)
     {
         name = _name;
         gameObject.name = _name;
         number = _number;
         frontPicture = front;
         Ability = ability;
         return this;
     }
 }
 
 