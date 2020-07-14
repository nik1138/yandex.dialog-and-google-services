using AliceHook.Models;

namespace AliceHook.Engine.Services
{
    public class ServiceEnter : ServiceBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            return request.Request.Command == "";
        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            return new SimpleResponse
            {
                Text = "Привет, в этом навыке ты можешь управлять сервисами google. " +
                       "Для того, чтобы увидеть все комманды скажи \"список команд\""
            };
        }
    }
}