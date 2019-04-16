﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppTest1
{
    public class RelayCommand<T> : ICommand
    {
        private Action<T> _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> action)
        {
            _action = action;
        }


        public bool CanExecute(object parameter)
        {
            return _action != null;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke((T)parameter);
        }
    }

    public class RelayCommand : ICommand
    {
        private Action _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            _action = action;
        }


        public bool CanExecute(object parameter)
        {
            return _action != null;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }
    }
}
