﻿namespace EvoSC.Modules.Evo.GeardownModule.Interfaces.Services;

public interface IGeardownSetupStateService
{
    /// <summary>
    /// True when the server is initially set up.
    /// </summary>
    public bool IsInitialSetup { get; }
    
    /// <summary>
    /// The name of the MatchSettings for the match that is currently set up.
    /// </summary>
    public string MatchSettingsName { get; }
    
    /// <summary>
    /// True when the server has finished the match setup.
    /// </summary>
    public bool SetupFinished { get; }
    
    /// <summary>
    /// True if the server is waiting for the match to start.
    /// </summary>
    public bool WaitingForMatchStart { get; }
    
    /// <summary>
    /// Set the initial setup state.
    /// </summary>
    /// <param name="matchSettingsName">Name of the match settings to use.</param>
    public void SetInitialSetup(string matchSettingsName);
    
    /// <summary>
    /// Set the finish setup state.
    /// </summary>
    public void SetSetupFinished();
    
    /// <summary>
    /// Set that the match has started.
    /// </summary>
    public void SetMatchStarted();
}
