using AliceHook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AliceHook.Engine.Services;

namespace AliceHook.Engine
{
    public class State
    {
        public Step Step { get; set; } //= Step.None;
        public string TempUrl { get; set; }

        public string Userid { get; set; }

        private static readonly List<ServiceBase> Services = new List<ServiceBase>
        {
            new ServiceEnter(),
            new ServiceHelp(),
            new ServiceGmail(),
            new ServiceNews(),
            new ServiceTranslate(),
            new ServiceYoutubeSubs(),
            new ServiceYoutube(),
            new ServiceYoutubeSearch(),
            new ServiceNewmail(),
            new ServiceNewmailWho(),
            new ServiceNewmailSubject(),
            new ServiceNewmailSend(),
            new ServiceUnknown()
        };
        public AliceResponse HandleRequest(AliceRequest aliceRequest, State state)
        {
            AliceResponse response = null;
            if (!Services.Any(Service => Service.Run(aliceRequest, state, out response)))
            {
                throw new NotSupportedException("No default Service");
            }
            return response;
        }

    }
    public enum Step
    {
        None,
        NewMail,
        NewMailWho,
        NewMailWhat,
        AwaitForKeyword
    }  
}