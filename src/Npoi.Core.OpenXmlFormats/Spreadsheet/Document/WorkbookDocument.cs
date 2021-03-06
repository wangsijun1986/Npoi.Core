﻿using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Npoi.Core.OpenXmlFormats.Spreadsheet
{
    public class WorkbookDocument
    {
        private CT_Workbook workbook = null;

        public WorkbookDocument()
        {
            workbook = new CT_Workbook();
        }

        public static WorkbookDocument Parse(XDocument xmlDoc, XmlNamespaceManager NameSpaceManager)
        {
            CT_Workbook obj = CT_Workbook.Parse(xmlDoc.Document.Root, NameSpaceManager);
            return new WorkbookDocument(obj);
        }

        public WorkbookDocument(CT_Workbook workbook)
        {
            this.workbook = workbook;
        }

        public CT_Workbook Workbook
        {
            get
            {
                return this.workbook;
            }
        }

        public void Save(Stream stream)
        {
            using (StreamWriter sw1 = new StreamWriter(stream))
            {
                workbook.Write(sw1);
            }
        }
    }
}