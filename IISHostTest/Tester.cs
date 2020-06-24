using IISHostTest.PersonService;
using Pangea.Fingerprints.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISHostTest
{
    public class Tester
    {
 
        ReqService.RequestServiceClient _requestService;
        PersonService.PersonServiceClient _personalService;

        public Tester()
        {
      
            _requestService = new ReqService.RequestServiceClient();
            _personalService = new PersonService.PersonServiceClient();
        }

        public void RequestServiceTest(string id)
        {
            var request = _requestService.GetRequestByNum(id);
            if (request != null)
                Console.WriteLine(request.idenNum);
            else
                Console.WriteLine("Request not found");
        }

        public void SaveFingerprints()
        {
            Dictionary<FPIndexes, byte[]> fd = new Dictionary<FPIndexes, byte[]>();

            fd.Add(FPIndexes.LeftIndex, File.ReadAllBytes(@"C:\fingers\2455283964163_f_1.wsq"));
            fd.Add(FPIndexes.LeftLittle, File.ReadAllBytes(@"C:\fingers\2455283964163_f_2.wsq"));
            fd.Add(FPIndexes.LeftMiddle, File.ReadAllBytes(@"C:\fingers\2455283964163_f_3.wsq"));
            fd.Add(FPIndexes.LeftRing, File.ReadAllBytes(@"C:\fingers\2455283964163_f_4.wsq"));
            fd.Add(FPIndexes.LeftThumb, File.ReadAllBytes(@"C:\fingers\2455283964163_f_5.wsq"));
            fd.Add(FPIndexes.RightIndex, File.ReadAllBytes(@"C:\fingers\2455283964163_f_6.wsq"));
            fd.Add(FPIndexes.RightLittle, File.ReadAllBytes(@"C:\fingers\2455283964163_f_7.wsq"));
            fd.Add(FPIndexes.RightMiddle, File.ReadAllBytes(@"C:\fingers\2455283964163_f_8.wsq"));
            fd.Add(FPIndexes.RightRing, File.ReadAllBytes(@"C:\fingers\2455283964163_f_9.wsq"));
            fd.Add(FPIndexes.RightThumb, File.ReadAllBytes(@"C:\fingers\2455283964163_f_10.wsq"));
            try
            {
                //NGU.Services.PersonService ps = new 

                //_personalService.SaveFingerprints(6, 1, fd);
            }
            catch(Exception ex)
            {

            }            
        }
    }
}
