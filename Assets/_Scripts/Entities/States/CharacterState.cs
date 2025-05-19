using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class CharacterState : BaseState<Character> {
    public Character Character => Subject;    
    }
