//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="FHWN.ac.at">
// Copyright (c) Jakob Winkler. All rights reserved.
// </copyright>
// <summary>
// This is the class of command.
// </summary>
// <author>Jakob Winkler</author>
//-----------------------------------------------------------------------
namespace KJL_Tankstelle_Framework.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Represents the class of the command.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    [Serializable]
    public class Command<T> : ICommand
    {
        /// <summary>
        /// Represents the action of a command.
        /// </summary>
        [field: NonSerialized]
        private readonly Action<T> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public Command(Action<T> action)
        {
            this.action = action;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        [field: NonSerialized]
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command.
        /// </param>
        /// <returns>
        /// The state whether the command can execute or not.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command.
        /// </param>
        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }
    }
}
