using AliceHook.Models;

namespace AliceHook.Engine.Services
{
    public class ServiceHelp : ServiceBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            return request.Request.Command == "список команд";
        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            return new SimpleResponse
            {
                Text = "Новое письмо, открой почту, открой youtube, найди на youtube, youtube подписки, " +
                       "как переводится, открой новости"
            };
        }
    }
}