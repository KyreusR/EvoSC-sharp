﻿using EvoSC.Common.Controllers;
using EvoSC.Common.Controllers.Attributes;
using EvoSC.Common.Events.Attributes;
using EvoSC.Common.Remote;
using EvoSC.Common.Remote.EventArgsModels;
using EvoSC.Modules.Official.LiveRankingModule.Interfaces;
using GbxRemoteNet.Events;
using EvoSC.Common.Interfaces.Controllers;

namespace EvoSC.Modules.Official.LiveRankingModule.Controllers;

[Controller]
public class LiveRankingEventController : EvoScController<IEventControllerContext>
{
    private readonly ILiveRankingService _service;

    // You want to dependency inject the needed services here at the constructor
    public LiveRankingEventController(ILiveRankingService service)
    {
        _service = service;
    }

    [Subscribe(ModeScriptEvent.WayPoint)]
    public async Task OnPlayerWaypointAsync(object sender, WayPointEventArgs args)
    {
        await _service.OnPlayerWaypointAsync(args);
    }

    [Subscribe(ModeScriptEvent.GiveUp)]
    public async Task OnPlayerGiveUpAsync(object sender, PlayerUpdateEventArgs args)
    {
        await _service.OnPlayerGiveupAsync(args);
    }

    [Subscribe(ModeScriptEvent.StartRoundStart)]
    public async Task OnStartRoundAsync(object sender, RoundEventArgs args)
    {
        await _service.OnStartRoundAsync(args);
    }

    [Subscribe(ModeScriptEvent.EndMapStart)]
    public async Task OnEndMapAsync(object sender, MapEventArgs args)
    {
        await _service.OnEndMapAsync(args);
    }

    [Subscribe(ModeScriptEvent.PodiumStart)]
    public async Task OnPodiumStart(object sender, PodiumEventArgs args)
    {
        await _service.OnPodiumStartAsync(args);
    }

    [Subscribe(ModeScriptEvent.EndRoundStart)]
    public async Task OnEndRound(object sender, RoundEventArgs args)
    {
        await _service.OnEndRoundAsync(args);
    }

    [Subscribe(GbxRemoteEvent.BeginMatch)]
    public async Task OnBeginMatch(object sender, EventArgs args)
    {
        await _service.OnBeginMatchAsync();
    }

    [Subscribe(GbxRemoteEvent.EndMatch)]
    public async Task OnEndMatch(object sender, EndMatchGbxEventArgs args)
    {
        await _service.OnEndMatchAsync(args);
    }

    [Subscribe(GbxRemoteEvent.PlayerConnect)]
    public async Task OnPlayerConnect(object sender, PlayerConnectGbxEventArgs args)
    {
        await _service.SendManialink();
    }
}
