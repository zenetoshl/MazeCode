﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalVar : TerminalBlocks
{
    public string var;
    public string type;
    public string value;
   public override IEnumerator RunBlock(){
       yield return null;
    }
    public override void ToUI (){

    }
    public override void UpdateUI (bool isOk){

    }
    public override bool Compile (){
        return true;
    }
    public override bool Reset (){
        return true;
    }
    public override void SetNextBlock (){
        
    }
    public override TerminalBlocks GetNextBlock (){
        return null;
    }
    public override void HidefromCamera (){

    }
}
