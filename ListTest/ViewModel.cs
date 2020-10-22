using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using KJL_Tankstelle_Framework.Commands;

namespace ListTest
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Model model;

        public ViewModel(Model model)
        {
            this.model = model;
        }

        public List<TestVM> Properties
        {
            get
            {
                return new List<TestVM>(this.model.Properties.Select(p => new TestVM(p, this.PlusCommand, this.RemoveCommand)));
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new Command<TestVM>(test =>
                {
                    this.model.Properties.Remove(test.test);
                    this.FireChanged(nameof(this.Properties));
                });
            }
        }

        public ICommand PlusCommand
        {
            get
            {
                return new Command<TestVM>(test =>
                {
                    test.Property++;
                    this.FireChanged(nameof(this.Properties));
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command<object>(obj =>
                {
                    this.model.Properties.Add(new Test(this.Input));
                    this.FireChanged(nameof(this.Properties));
                });
            }
        }

        public int Input { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void FireChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TestVM
    {
        public Test test;

        public TestVM(Test test, ICommand plusCommand, ICommand removeCommand)
        {
            this.test = test;
            this.RemoveCommand = removeCommand;
            this.PlusCommand = plusCommand;
        }

        public int Property
        {
            get
            {
                return this.test.Property;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.test.Property = value;
            }
        }

        public ICommand RemoveCommand { get; set; }

        public ICommand PlusCommand { get; set; }
    } 
}
