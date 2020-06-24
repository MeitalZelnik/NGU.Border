using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace NGU.App.DTO
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class DTOBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        #region Undo

        private byte[] _dataForUndo = null;

        //public void PrepareForUndo()
        //{
        //    IFormatter formatter = new BinaryFormatter();
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        formatter.Serialize(stream, this);
        //        stream.Seek(0, 0);
        //        _dataForUndo = new byte[stream.Length];
        //        stream.Read(_dataForUndo, 0, _dataForUndo.Length);
        //    }
        //}

        //public DTOBase Undo()
        //{
        //    if (_dataForUndo != null)
        //        throw new Exception("PrepareForUndo must be activated before Undo");

        //    IFormatter formatter = new BinaryFormatter();
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        stream.Write(_dataForUndo, 0, _dataForUndo.Length);
        //        stream.Seek(0, 0);
        //        return (DTOBase)formatter.Deserialize(stream);
        //    }
        //}

        //public DTOBase Clone()
        //{
        //    var tmp = _dataForUndo;
        //    PrepareForUndo();
        //    var copy = Undo();
        //    _dataForUndo = tmp;
        //    return copy;
        //}

        #endregion
    }
}
