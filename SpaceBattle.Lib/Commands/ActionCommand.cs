namespace SpaceBattle.Lib;

public class ActionCommand : ICommand {
    private Action<object[]> action;
    private object[] args;

    public ActionCommand(Action<object[]> action, params object[] args)
    {
        this.action = action;
        this.args = args;
    }

    public void Execute()
    {
        // try {
            action(args);
        // }

        // catch (Exception e) {
        //     IoC.Resolve<IStrategy>("Game.Exceptions.FindExcHandlerForActions", action, args, e);
        // }   
    }
}
