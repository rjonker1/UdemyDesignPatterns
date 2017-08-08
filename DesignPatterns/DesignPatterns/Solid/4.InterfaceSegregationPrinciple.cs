using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid
{
    //should not have functions it does not need
    //If interface is too big; break it up into smaller interfaces
    public class Document
    {
    }

    public interface IMachine
    {
        void Fax(Document document);
    }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMultifunctionDevice : IScanner, IPrinter
    {
        
    }


    public class MultiFunctionPrinter : IMultifunctionDevice
    {
        private IPrinter printer;

        private IScanner scanner;

        public MultiFunctionPrinter(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        //decorator pattern - delage methods to members
        public void Print(Document document)
        {
            //decorator
            printer.Print(document);
        }

        public void Scan(Document document)
        {
            //decorator
            scanner.Scan(document);
        }
    }

    //can only use some members
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document document)
        {
            //
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document document)
        {
            throw new NotImplementedException();
        }
    }
}
