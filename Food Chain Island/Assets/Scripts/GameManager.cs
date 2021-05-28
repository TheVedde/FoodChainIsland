using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    private void Awake() {
        if (inst == null) {
            inst = this;
        }else {
            Destroy(gameObject);
        }
    }
    
    public GameObject Background;
    public GameObject FieldsGameObject;
    public GameObject CardsGameObject;

    public void EndGame()
    {
        int cardsleft = 0;
        for (int i = 0; i < CardsGameObject.transform.childCount; i++)
        {
            cardsleft++;
        }
        StateManager.ChangeState(new EndState(cardsleft));
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
    
    void Start()
    {
        StateManager.ChangeState(new NeutralState());
        FieldFactory.inst.InitiateFields();
        CardFactory.inst.createCards();
        CardFactory.inst.IntiateWaterCards();
        FieldsGameObject.transform.position = new Vector3(0, 0, 0);
        CardsGameObject.transform.position = new Vector3(0, 0, 0);
        CardFactory.inst.CardsToFields();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StateManager.currentState.GoBack();
        }
    }


}
