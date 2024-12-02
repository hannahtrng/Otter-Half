using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    [SerializeField] public AudioSource DeathSound;
    [SerializeField] public AudioSource FightSound;
    [SerializeField] public AudioSource TakeDamageSound;
    [SerializeField] public AudioSource MovementSound;
    [SerializeField] public AudioSource TurnSound;
    public static SFXmanager Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        Instance = this;
    }
}
