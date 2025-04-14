using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Block", menuName = "ScriptableObjects/Block")]
public class Block : ScriptableObject
{
    public Tile[] state;
    public float maxHealth;
    public GameObject vfxHit;
    public GameObject vfxDeath;
    public int blockType;


    public Tile GetState(float currentHealth)
    {
        float percent = Mathf.Clamp((currentHealth / maxHealth) * 100f, 0f, 100f);

        if (percent > 80f) return state[0];
        if (percent > 60f) return state[1];
        if (percent > 40f) return state[2];
        if (percent > 20f) return state[3];
        if (percent > 0f) return state[4];

        return state[4];
    }
}
