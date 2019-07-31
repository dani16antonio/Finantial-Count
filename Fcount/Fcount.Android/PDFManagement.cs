using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fcount.Droid;
using Xamarin.Forms;
using Fcount.viewmodels.utils;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Fcount.models;

[assembly: Dependency(typeof(PDFManagement))]
namespace Fcount.Droid
{
    public class PDFManagement : Object, ICreatePDF
    {
        public async void Create(string message)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            graphics.DrawString(message, font, PdfBrushes.Black, new PointF(0, 0));
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);
            SaveAndroid androidSave = new SaveAndroid();
            await androidSave.SaveAndView("Cotización.pdf", "application/pdf", stream);
        }
    }
}