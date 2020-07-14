﻿using System.Collections.Generic;
using System.Linq;
using AliceHook.Models;
using System.Diagnostics;

namespace AliceHook.Engine.Services
{
    public class ServiceYoutube : ServiceBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            if (state.Step != Step.None) return false;

            var keywords = new List<string>
            {
                "откр youtube",
                "Youtube"
            };

            var requestString = request.Request.Nlu.Tokens;
            return keywords.Any(kw =>
            {
                var tokens = kw.Split(" ");
                return tokens.All(requestString.ContainsStartWith);
            });
        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            //state.Step = Step.None;

            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "https://www.youtube.com/";
            proc.Start();

            return new SimpleResponse
            {
                Text = "Открываю"
            };   
        }
    }
}