using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFunction : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;

    void PlaySound(AudioClip whichSound)
    {
        menuButtonController.audioSource.PlayOneShot(whichSound);
    }
}
