using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest1
{
    public sealed class TestData
    {
        private static TestData instance = new TestData();

        public static TestData Instance {
            get {
                return instance;
            }
        }

        private TestData()
        {
            Data = new ObservableCollection<string>();
            Data.Add("aaa");
            Data.Add("bbb");
            Data.Add("ccc");
            Data.Add("ddd");
        }
        
        public ObservableCollection<string> Data { get; set; }
    }
}
