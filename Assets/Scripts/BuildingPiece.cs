using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPiece : MonoBehaviour
{
    public int Level = 0;
    public DamageLevel[] Damages;
    public SpriteRenderer Render;
    public Rigidbody2D Rb;
    [SerializeField] GameObject BigExplode;
    [SerializeField] GameObject MedExplode;
    [SerializeField] GameObject SmallExplode;
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioClip[] crashClips;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource breakSource;


    // Start is called before the first frame update
    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
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

        if (col.otherCollider.tag == "Building" && col.relativeVelocity.magnitude >= 8.5f)
        {
            sfxSource.PlayOneShot(crashClips[Random.Range(0, 2)]);
            Debug.Log(col.relativeVelocity.magnitude);
        }
    }

    public void LoadDamage(int level)
    {
        Render.sprite = Damages[level].Sprite;
        if (level >= 1)
        {
            Instantiate(BigExplode, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 15, gameObject.transform.position.z), Quaternion.identity);
            breakSource.PlayOneShot(clips[Random.Range(0, 2)]);
        }
    }

    [System.Serializable]
    public class DamageLevel
    {
        public float DamageTillNextLevel = 10;
        public Sprite Sprite;
        public EffectData[] Effects;
    }
}
