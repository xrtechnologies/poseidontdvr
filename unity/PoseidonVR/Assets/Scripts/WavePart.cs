using System;
using UnityEngine;

[Serializable]
public class WavePart
{
    // List of available enemy prefabs.
    // Must be inside Resources folder:
    // https://docs.unity3d.com/ScriptReference/Resources.Load.html

    public const string ENEMY_TYPE_CART = "Enemies/Cart";
    public const string ENEMY_TYPE_PLAYER = "Enemies/Player";

    // Definition
    public string EnemyType {get;set;}
    public int Amount { get; set; }
    public float DensityDelay { get; set; }
    public float Speed  { get; set; }
    public Vector3 Scale { get; set; }
}