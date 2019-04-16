using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppTest1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // model
        private TestData _testData;

        private void RaisePropertyChaged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // モデルとか依存関係のあるモジュールは引数で渡して明示的に依存関係を示す。
        public MainWindowViewModel(TestData testData)
        {
            _viewText = "";
            _testData = testData;
            AddCommand = new RelayCommand(addListData);
            BtnCommand = new RelayCommand<int>(selectAplay);
        }
        /// <summary>
        /// デザイナ用。呼び出し禁止。
        /// </summary>
        /// <param name="testData"></param>
        public MainWindowViewModel()
        {
            _viewText = "";
            _testData = TestData.Instance;
            AddCommand = new RelayCommand(addListData);
            BtnCommand = new RelayCommand<int>(selectAplay);
        }


        public ICommand BtnCommand { get; private set; }
        public ICommand AddCommand { get; private set; }


        public ObservableCollection<string> ListData
        {
            get { return _testData.Data; }
        }

        private string _viewText;
        public string ViewText
        {
            get { return _viewText; }
            set
            {
                if (value == _viewText) { return; }
                _viewText = value;
                RaisePropertyChaged();
            }
        }


        private void selectAplay(int index)
        {
            if ((0 <= index) && (index < ListData.Count))
            {
                ViewText = _testData.Data.ElementAt(index);
            }
        }

        private void addListData()
        {
            ListData.Add("add");
        }
    }
}
