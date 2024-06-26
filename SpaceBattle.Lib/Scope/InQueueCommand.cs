namespace SpaceBattle.Lib;

public class InQueueCommand : ICommand
{
    readonly Queue<ICommand> queue;
    readonly ICommand command;

    public InQueueCommand(Queue<ICommand> queue, ICommand command)
    {
        this.queue = queue;
        this.command = command;
    }
    
    public void Execute()
    {
        queue.Enqueue(command);
    }
}
