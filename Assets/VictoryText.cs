using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryText : NetworkBehaviour
{

    [Networked, OnChangedRender(nameof(VictoryTextValueChanged))]
    public string VictoryTextValue { get; set; }
    public void VictoryTextValueChanged()
    {
        GetComponent<TextMeshPro>().text = VictoryTextValue;
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_ChangeText(string s)
    {
        Debug.Log(nameof(RPC_ChangeText) + " WAS CALLED");
        VictoryTextValue = s;
    }

    public override void Spawned()
    {
        base.Spawned();
        VictoryTextValueChanged();
    }
}
