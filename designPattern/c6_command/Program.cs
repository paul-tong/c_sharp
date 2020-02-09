using System;

/*
Command Pattern:

-definition
encapsulates a request(command) as an object, thereby letting you parameterize other objects
with different requests/actions, queue or log requests, and support undoable operations.

-it contains several parts:
    The Receiver(light): knows how to perform the work needed to carry out the request. Any class can act as a Receiver.
    The Command(Command interface): declares an interface for all commands. A command is invoked through its 
        execute() method, which asks a receiver to perform an action. 
    The ConcreteCommand(LightOnCommand): defines a binding between an action and a Receiver. The Invoker makes 
        a request by calling execute() and the ConcreteCommand carries it out by 
        calling one or more actions on the Receiver.
    The Invoker(Controller): holds a command and at some point asks the command to carry out a request by calling its execute() method
    The Client(Main() method): is responsible for creating a ConcreteCommand and setting its Receive


-Macro Command
A series of commands can be strung together and executed in a sequence by another command object, sometimes called a macro command. 
It has no explicit receiver as the commands it sequences define their own receivers. The macro command is an example of the composite pattern.

-Caveats:
The command pattern is equivalent of a callback function in procedural languages as we parametrize objects with an action to perform
The command objects can also be queued for later execution.
The command interface can introduce an unexecute method, which reverses the actions of the execute method. The executed commands can 
    then be stored in a list and traversing the list forwards and backwards while invoking execute or unexecute can support redo and undo 
    respectively. The memento pattern can be helpful in storing the state a command needs to undo its effects.
The command interface can add methods to save and read from disk allowing logging of commands. In case of a crash the log can be read and 
    the commands re-executed in the same sequence to get the system back to the state just before the crash.
The command pattern offers a way to model transactions. A transaction consists of finer grained operations applied to data.    
*/
namespace c6_command
{
    // NOTE: the receiver -> the real world objects that actually react to the command
    // knows how to perform the work needed to carry out the request
    public class Light {
        public void On() {
            Console.WriteLine("Light on!");
        }

        public void Off() {
            Console.WriteLine("Light off!");
        }
    }

    // NOTE: command interface, contains Execute() method that triggers certain action,
    //  can also contain other related methods that muniputes the receiver object(eg, undo())
    public interface Command {
        void Execute(); // execute this command

        void Undo(); // undo this command
    }

    // NOTE: each action of the receiver needs to be escapulated as a concrete command
    // it needs to implement the command interface
    public class LightOnCommand: Command {

        // NOTE: need to has a real world recierver(object) as data member
        Light light;

        // construtor to set the receiver
        public LightOnCommand(Light l) {
            light = l;
        }

        // NOTE: implement execute method by invoking actions of the receiver
        public void Execute() {
            light.On();
        }

        // NOTE: undo the light on command -> can just turn the light off
        public void Undo() {
            light.Off();
        }
    }

    // NOTE: concrete command for the light off action
    public class LightOffCommand: Command {
        Light light;

        public LightOffCommand(Light l) {
            light = l;
        }

        public void Execute() {
            light.Off();
        }

        public void Undo() {
            light.On();
        }
    }

    // NOTE: a Invoker(controller) that contains the command in a slot
    // can trigger the slot to execute the command
    public class SimpleController {
        // a slot(the command the controller can trigger)
        private Command slot;

        // set the slot
        public void SetSlot(Command c) {
            slot = c;
        }

        // NOTE: trigger the command will invoke the Execute() method of the command
        public void TriggerCommand() {
            slot.Execute();
        } 

        // undo the command
        public void UndoCommand() {
            slot.Undo();
        }
    }

    class Program
    {
        // NOTE: Main function is acting as a Client
        // responsible for creating a ConcreteCommand and setting its Receiver
        // also responsible for creating Invokers(controllers)
        static void Main(string[] args)
        {
            // build receiver (light)
            Light light = new Light();

            // build commands
            LightOnCommand lightOn = new LightOnCommand(light); // set receiver(manipulated object) of the command
            LightOffCommand lightOff = new LightOffCommand(light);

            // build controllers
            SimpleController lightOnC = new SimpleController();
            lightOnC.SetSlot(lightOn); // set command(slot) of the controller

            SimpleController lightOffC = new SimpleController();
            lightOffC.SetSlot(lightOff);

            // invoke to execute the commands through controller
            lightOnC.TriggerCommand();
            lightOffC.TriggerCommand();
            lightOffC.UndoCommand();            
        }
    }
}
