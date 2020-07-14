

using AliceHook.Models;
using System.Diagnostics;



namespace AliceHook.Engine.Services
{
    public class ServiceNewmailSend : ServiceBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            return state.Step == Step.NewMailWhat;


        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            state.Step = Step.None;
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.FileName = "SendMail.exe";
            proc.StartInfo.Arguments = request.Request.Command;
            proc.Start();

            return new SimpleResponse
            {
                Text = "Отправлено."
            };
        }
    }
}