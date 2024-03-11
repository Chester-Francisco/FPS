using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   virtual public void Open()
    {
        gameObject.SetActive(true);
    }

   virtual public void Close()
    {
        gameObject.SetActive(false);
    }

    virtual public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
