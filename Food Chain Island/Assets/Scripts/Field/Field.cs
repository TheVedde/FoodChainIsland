using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Field : MonoBehaviour
{
    public Vector2Int position;

    public Card Occupant = null;
    // Start is called before the first frame update

    public Field Prime(Vector2Int pos)
    {
        position = pos;
        return this;
    }
    
    private void OnMouseDown()
    {
        StateManager.currentState.OnMouseDown(this);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
