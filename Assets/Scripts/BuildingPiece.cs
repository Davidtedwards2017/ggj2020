using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPiece : MonoBehaviour
{
    public int Level = 0;
    public DamageLevel[] Damages;
    public SpriteRenderer Render;

    // Start is called before the first frame update
    void Start()
    {
        Render = GetComponent<SpriteRenderer>();
        LoadDamage(Level);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.relativeVelocity.magnitude);
        var current = Damages[Level];
        current.DamageTillNextLevel -= col.relativeVelocity.magnitude;

        if (Level < Damages.Length - 1 && current.DamageTillNextLevel <= 0)
        {
            Level++;
            LoadDamage(Level);
        }
    }

    public void LoadDamage(int level)
    {
        Render.sprite = Damages[level].Sprite;
    }

    [System.Serializable]
    public class DamageLevel
    {
        public float DamageTillNextLevel = 10;
        public Sprite Sprite;
        public EffectData[] Effects;
    }
}
