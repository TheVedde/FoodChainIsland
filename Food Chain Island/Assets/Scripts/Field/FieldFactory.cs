using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldFactory : MonoBehaviour
{
    public static FieldFactory inst;
    public GameObject FieldPref;
    private void Awake()
    {
        inst = this;
    }


   public void InitiateFields() {
        for (int x = 0; x < 6; x++) {
            for (int z = 0; z < 6; z++) {
                GameObject field = Instantiate(FieldPref,new Vector3(x,0,z),Quaternion.Euler(90,90,0)) as GameObject;
                field.transform.parent = GameManager.inst.FieldsGameObject.transform;
                field.GetComponent<Field>().Prime(new Vector2Int(x, z));
                Utilities.map[x, z] = field.GetComponent<Field>();
            }
        }
    }
}
