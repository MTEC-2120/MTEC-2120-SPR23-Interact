using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialog 
{
    void TalkTo(Transform transform);
    List<string> GetDialogTexts();
    Transform GetTransform();
}
