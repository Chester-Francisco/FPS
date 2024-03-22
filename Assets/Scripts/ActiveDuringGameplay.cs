using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDuringGameplay : MonoBehaviour
{
    private void Awake()
    {
        Messenger<bool>.AddListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger<bool>.AddListener(GameEvent.GAME_INACTIVE, OnGameInActive);

    }

    private void OnDestroy()
    {
        Messenger<bool>.RemoveListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger<bool>.RemoveListener(GameEvent.GAME_INACTIVE, OnGameInActive);
    }

    private void OnGameActive(bool isActive)
    {
        this.enabled = isActive;
    }

    private void OnGameInActive(bool isActive)
    {
        this.enabled = isActive;
    }
}
