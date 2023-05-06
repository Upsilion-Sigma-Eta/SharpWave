using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PjtSharpWave.Common;
namespace PjtSharpWave.Model
{
    public class Message : ObservableObjectBase<Message>
    {
        private string _textMessage;
        public string TextMessage
        {
            get 
            { 
                return _textMessage; 
            }
            set 
            { 
                _textMessage = value;
                OnPropertyChanged(p => p.TextMessage);
            }
        }

        private string _caption;
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(p => p.Caption);
            }
        }
    }
}
