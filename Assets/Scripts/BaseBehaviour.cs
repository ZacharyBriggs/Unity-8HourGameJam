﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public GameObject loseText;
    private void OnDestroy()
    {
        loseText.SetActive(true);
    }

}
