using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnimFishing : MonoBehaviour
{
    public Fishing fishing;
    private Animator _animator;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F) && fishing.canAnnim) 
        {
            if (!_animator.GetBool("isFishing")){
                _animator.SetBool("isFishing", true);
            }else
            {
                _animator.SetBool("isFishing", false);
            }
        }
    }
}
