using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Wave", order = 1)]
public class WaveScriptable : ScriptableObject
{
    public GameObject monster;
    public int nMonsters;
}
