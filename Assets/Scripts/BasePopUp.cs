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
        if(!IsActive())
        {
            gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPENED);
        }
        else
        {
            Debug.LogError(this + ".Open() - trying to open pop up that is active");
        }
       
    }

   virtual public void Close()
    {
        if(IsActive())
        {
            gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        } 
        else
        {
            Debug.LogError(this + ".Close() - trying to close pop up that is inactive");
        }
        
    }

    virtual public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
