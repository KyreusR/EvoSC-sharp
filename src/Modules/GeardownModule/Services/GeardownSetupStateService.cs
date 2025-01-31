﻿using EvoSC.Common.Services.Attributes;
using EvoSC.Common.Services.Models;
using EvoSC.Modules.Evo.GeardownModule.Interfaces.Services;

namespace EvoSC.Modules.Evo.GeardownModule.Services;

[Service(LifeStyle = ServiceLifeStyle.Singleton)]
public class GeardownSetupStateService : IGeardownSetupStateService
{
    private bool _initialSetup;
    private string _matchSettingsName = "";
    private readonly object _initialSetupLock = new();
    private bool _setupFinished;
    private readonly object _setupFinishedLock = new();
    private bool _waitingForMatchStart;
    private readonly object _waitingForMatchStartLock = new();

    public bool IsInitialSetup
    {
        get
        {
            lock (_initialSetupLock)
            {
                return _initialSetup;
            }
        }
    }

    public string MatchSettingsName
    {
        get
        {
            lock (_initialSetupLock)
            {
                return _matchSettingsName;
            }
        }
    }

    public bool SetupFinished
    {
        get
        {
            lock (_setupFinishedLock)
            {
                return _setupFinished;
            }
        }
    }

    public bool WaitingForMatchStart
    {
        get
        {
            lock (_waitingForMatchStartLock)
            {
                return _waitingForMatchStart;
            }
        }
    }

    public void SetInitialSetup(string matchSettingsName)
    {
        lock (_initialSetupLock)
        {
            _initialSetup = true;
            _matchSettingsName = matchSettingsName;
        }
        
        lock (_setupFinishedLock)
        {
            _setupFinished = false;
        }

        lock (_waitingForMatchStartLock)
        {
            _waitingForMatchStart = false;
        }
    }

    public void SetSetupFinished()
    {
        lock (_initialSetupLock)
        {
            _initialSetup = false;
        }

        lock (_setupFinishedLock)
        {
            _setupFinished = true;
        }

        lock (_waitingForMatchStartLock)
        {
            _waitingForMatchStart = true;
        }
    }

    public void SetMatchStarted()
    {
        lock (_waitingForMatchStartLock)
        {
            _waitingForMatchStart = false;
        }
    }
}
