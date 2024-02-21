using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamsManager : Singleton<TeamsManager>
{
    public Team currentTeam;
    public List<Team> teams;

    protected override void Awake()
    {
        base.Awake();
        currentTeam = new Team();
    }
}
