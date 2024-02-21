using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team 
{
    public int id;
    public string teamName;
    public string description;

    public List<ICharacter> characters = new List<ICharacter>();
}
