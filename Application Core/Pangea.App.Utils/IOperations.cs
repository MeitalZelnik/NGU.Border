using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangea.App.Utils
{
    public interface IOperationAdd
    {
        void Add();
        bool CanExecute(object obj);
    }

    public interface IOperationClear
    {
        void Clear();
        bool CanExecute(object obj);
    }

    public interface IOperationSaveRequest
    {
        void Save();
        bool CanExecuteSaveRequest(object obj);
    }

    public interface IOperationSave
    {
        bool Save();
        bool CanExecute(object obj);
    }

    public interface IOperationPrint
    {
        void Print();
        bool CanExecute(object obj);
    }

    public interface IOperationDelete
    {
        void Delete();
        bool CanExecute(object obj);
    }

    public interface IOperationScan
    {
        void Scan();
        bool CanExecute(object obj);
    }

    public interface IOperationCancel
    {
        void Cancel();
        bool CanExecute(object obj);
    }

    public interface IOperationNew
    {
        void New();
        bool CanExecuteNew(object obj);
    }

    public interface IOperationTerminate
    {
        void Terminate();
        bool CanExecuteTerminate(object obj);
    }

    public interface IOperationSubmit
    {
        void Submit();
        bool CanExecuteSubmit(object obj);
    }

    public interface IOperationExport
    {
        void ExportToExcel();
        bool CanExecute(object obj);
    }

    public interface IOperationScanFromPaper
    {
        void ScanFromPaper();
        bool CanExecute(object obj);
    }

    public interface IOperationEnroll
    {
        void Enroll();
        bool CanExecute(object obj);
    }

    public interface IOperationBack
    {
        void Back();
        bool CanExecute(object obj);
    }

    public interface IOperationCaptureAll
    {
        void CaptureAll();
        bool CanExecute(object obj);
    }

    public interface IOperationCaptureMulti
    {
        void CaptureMulti();
        bool CanExecute(object obj);
    }
}
