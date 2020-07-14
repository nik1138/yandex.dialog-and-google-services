

using AliceHook.Models;
using System.Diagnostics;



namespace AliceHook.Engine.Services
{
    public class ServiceNewmailSubject : ServiceBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            return state.Step == Step.NewMailWho;


        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            state.Step = Step.NewMailWhat;
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "Funki.exe";
            proc.StartInfo.Arguments = request.Request.Command;
            proc.Start();

            return new SimpleResponse
            {
                Text = "Что вы хотите написать?"
            };
        }
    }
}