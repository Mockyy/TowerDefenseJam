using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "ScriptableObject/Enemy", order = 1)]
public class Enemy : ScriptableObject
{
    public float hp;
    public float speed;
}
