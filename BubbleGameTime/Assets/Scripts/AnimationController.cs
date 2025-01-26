using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField]
    public List<GameObject> animations = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject anim in animations)
        {
            anim.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
