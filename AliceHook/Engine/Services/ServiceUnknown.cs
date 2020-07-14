using AliceHook.Models;

namespace AliceHook.Engine.Services
{
    public class ServiceUnknown : ServiceBase
    {
        protected override bool Check(AliceRequest request, State state)
        {
            return true;
        }

        protected override SimpleResponse Respond(AliceRequest request, State state)
        {
            state.Step = Step.None;
            return new SimpleResponse
            {
                Text = "Не поняла. Для того, чтобы вызвать список команд введите: \"список команд\""
            };
        }
    }
}