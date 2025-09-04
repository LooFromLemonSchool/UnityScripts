using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class PlayOnApproach : MonoBehaviour
{

    [Tooltip("The transform of the player")]
    public Transform player;

    [Tooltip("How close the player must be to start the sound")]
    public float triggerDistance = 3f;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.playOnAwake = false;
        _audio.loop = false; 
    }
    

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        float dist = Vector2.Distance(
            new Vector2(player.position.x, player.position.y),
            new Vector2(transform.position.x, transform.position.y)
        );

        if (dist <= triggerDistance)
        {
            if (!_audio.isPlaying)
                _audio.Play();
        }

        else
        {
            if (_audio.isPlaying)
                _audio.Stop();
        }
    }
}
