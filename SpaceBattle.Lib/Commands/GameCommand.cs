namespace SpaceBattle.Lib;

public class GameCommand : ICommand
{
    object scope;
    BlockingCollection<ICommand> gameQueue;
    
    public GameCommand(object scope, BlockingCollection<ICommand> gameQueue)
    {
        this.scope = scope;
        this.gameQueue = gameQueue;
    }

    public void Execute()
    {
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", scope).Execute();

        IReceiver reciver = new ReceiverAdapter(gameQueue);

        var stopwatch = new Stopwatch();

        stopwatch.Start();

        while(stopwatch.ElapsedMilliseconds <= IoC.Resolve<int>("Game.Quantum.Get"))
        {
            var cmd = reciver.Receive();
                
            try {
                cmd.Execute();
            }
            catch (Exception e) {
                IoC.Resolve<ICommand>("Game.Exception.FindExceptionHandlerForCmd", cmd, e).Execute();
            }
        }

        stopwatch.Stop();
    }
}