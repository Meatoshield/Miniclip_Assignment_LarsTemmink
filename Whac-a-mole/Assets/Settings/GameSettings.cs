using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    public DifficultySettings[] Difficulties;
}
