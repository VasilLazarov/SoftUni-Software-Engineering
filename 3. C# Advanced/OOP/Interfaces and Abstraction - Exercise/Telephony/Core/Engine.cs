using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Core.Interfaces;
using Telephony.Models.Interfaces;
using Telephony.Models;
using Telephony.IO.Interfaces;
using Telephony.IO;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(" ");
            string[] websites = reader.ReadLine()
                .Split(" ");
            ICallable phone;
            foreach (string phoneNumber in phoneNumbers)
            {

                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();

                }
                else
                {
                    phone = new StationaryPhone();
                }
                try
                {
                    phone.Call(phoneNumber);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
            IBrowsable smartphone = new Smartphone();
            foreach (string website in websites)
            {

                try
                {
                    smartphone.Browse(website);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
