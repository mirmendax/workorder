using System;
using System.IO;
using System.Reflection;
using oalib_v2;

namespace WorkOrder
{
    internal class Excel
    {
        private object oExcel = (object)null;
        public const string UID = "Excel.Application";
        private object WorkBooks;
        private object WorkBook;
        private object WorkSheets;
        private object WorkSheet;
        private object Range;
        private object Interior;

        public bool Visible
        {
            set
            {
                if (!value)
                    this.oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty, (Binder)null, this.oExcel, new object[1]
          {
             false
          });
                else
                    this.oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty, (Binder)null, this.oExcel, new object[1]
          {
             true
          });
            }
        }

        public Excel()
        {
            try
            {
                this.oExcel = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            }
            catch (Exception ex)
            {
                new Log("Excel module " + ex.Message);
            }
        }

        public void OpenDocument(string name)
        {
            this.WorkBooks = this.oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, (Binder)null, this.oExcel, (object[])null);
            this.WorkBook = this.WorkBooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, (Binder)null, this.WorkBooks, new object[2]
      {
        (object) name,
        (object) true
      });
            this.WorkSheets = this.WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, (Binder)null, this.WorkBook, (object[])null);
            this.WorkSheet = this.WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, (Binder)null, this.WorkSheets, new object[1]
      {
        (object) 1
      });
        }

        public void NewDocument()
        {
            this.WorkBooks = this.oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, (Binder)null, this.oExcel, (object[])null);
            this.WorkBook = this.WorkBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, (Binder)null, this.WorkBooks, (object[])null);
            this.WorkSheets = this.WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, (Binder)null, this.WorkBook, (object[])null);
            this.WorkSheet = this.WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, (Binder)null, this.WorkSheets, new object[1]
      {
        (object) 1
      });
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) "A1"
      });
        }

        public void CloseDocument()
        {
            this.WorkBook.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, (Binder)null, this.WorkBook, new object[1]
      {
        (object) true
      });
        }

        public void SaveDocument(string name)
        {
            if (File.Exists(name))
                this.WorkBook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, (Binder)null, this.WorkBook, (object[])null);
            else
                this.WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, (Binder)null, this.WorkBook, new object[1]
        {
          (object) name
        });
        }

        public void SetValue(string range, string value)
        {
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) range
      });
            this.Range.GetType().InvokeMember("Value", BindingFlags.SetProperty, (Binder)null, this.Range, new object[1]
      {
        (object) value
      });
        }

        public void SetMerge(string range, int Alignment)
        {
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) range
      });
            object[] args = new object[1]
      {
        (object) Alignment
      };
            this.Range.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, (Binder)null, this.Range, new object[1]
      {
        (object) true
      });
            this.Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, (Binder)null, this.Range, args);
        }

        public void SetOrientation(int Orientation)
        {
            object target = this.WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, (object[])null);
            target.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, (Binder)null, target, new object[1]
      {
        (object) Orientation
      });
        }

        public void SetColumnWidth(string range, double Width)
        {
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) range
      });
            this.Range.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, (Binder)null, this.Range, new object[1]
      {
        (object) Width
      });
        }

        public void SetRowHeight(string range, double Height)
        {
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) range
      });
            this.Range.GetType().InvokeMember("RowHeight", BindingFlags.SetProperty, (Binder)null, this.Range, new object[1]
      {
        (object) Height
      });
        }

        public void SetBorderStyle(string range, int Style)
        {
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) range
      });
            object[] args = new object[1]
      {
        (object) 1
      };
            object[] objArray = new object[1]
      {
        (object) 1
      };
            this.Range.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, (Binder)null, this.Range.GetType().InvokeMember("Borders", BindingFlags.GetProperty, (Binder)null, this.Range, (object[])null), args);
        }

        public string GetValue(string range)
        {
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) range
      });
            return this.Range.GetType().InvokeMember("Value", BindingFlags.GetProperty, (Binder)null, this.Range, (object[])null).ToString();
        }

        public void SetVerticalAlignment(string range, int Alignment)
        {
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) range
      });
            this.Range.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, (Binder)null, this.Range, new object[1]
      {
        (object) Alignment
      });
        }

        public void SetHorisontalAlignment(string range, int Alignment)
        {
            this.Range = this.WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, (Binder)null, this.WorkSheet, new object[1]
      {
        (object) range
      });
            this.Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, (Binder)null, this.Range, new object[1]
      {
        (object) Alignment
      });
        }
    }
}
