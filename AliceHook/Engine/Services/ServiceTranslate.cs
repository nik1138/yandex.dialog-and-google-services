using System.Collections.Generic;
using System.Linq;
using AliceHook.Models;
using System.Diagnostics;

namespace AliceHook.Engine.Services
{
    public class ServiceTranslate : ServiceBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            if (state.Step != Step.None) return false;

            var keywords = new List<string>
            {
                "как переводится"
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
            int indexOfSubstring = request.Request.Command.IndexOf("переводится");
            string answer = request.Request.Command.Substring(indexOfSubstring + 12);

            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "https://translate.google.ru/?hl=ru#view=home&op=translate&sl=auto&tl=ru&text=" + answer;
            proc.Start();

            return new SimpleResponse
            {
                Text = "Открываю перевод"
            };            
        }
    }
}